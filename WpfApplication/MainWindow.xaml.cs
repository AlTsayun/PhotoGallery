using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Color = System.Drawing.Color;
using DataFormats = System.Windows.DataFormats;
using DragEventArgs = System.Windows.DragEventArgs;
using Image = System.Windows.Controls.Image;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using Point = System.Windows.Point;
using SystemColors = System.Windows.SystemColors;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private Point currentPoint;
        BitmapSource backupBitmap;
        delegate byte[] ByteEffect(byte[] source);
        

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Control_OnOpenFileClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image files (*.png)|*.png| All files (*.*)|*.*",
                CheckFileExists = true
            };
            if (dialog.ShowDialog() == true)
            {
                openFile(dialog.FileName);
            }
        }


        private void openFile(string fileFullName)
        {
            brightnessSlider.Value = 0;
            rotateImageSlider.Value = 0;
            adjustColorsSlider.Value = 0;
            contrastSlider.Value = 0;
            scaleSlider.Value = 1;
            canvasWithImage.Children.RemoveRange(0, canvasWithImage.Children.Count);
            canvasWithImage.Children.Add(viewedImage);

            viewedImage.Source = new BitmapImage(new Uri(fileFullName));
            canvasWithImage.Width = viewedImage.Source.Width;
            canvasWithImage.Height = viewedImage.Source.Height;
        }

        private void Control_OnSaveFileClick(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Image files (*.png)|*.png| All files (*.*)|*.*",
                CheckFileExists = false
            };
            if (dialog.ShowDialog() == true)
            {
                WriteToPng(canvasWithImage, dialog.FileName);
            }
        }

        public void WriteToPng(UIElement element, string filename)
        {
            var rect = new Rect(element.RenderSize);
            var visual = new DrawingVisual();

            using (var dc = visual.RenderOpen())
            {
                dc.DrawRectangle(new VisualBrush(element), null, rect);
            }

            var bitmap =
                new RenderTargetBitmap(
                    (int) rect.Width, (int) rect.Height, 96, 96, PixelFormats.Default);
            bitmap.Render(visual);

            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var file = File.OpenWrite(filename))
            {
                encoder.Save(file);
            }
        }


        private void CanvasWithImage_OnMouseDownWhileDrawing(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(canvasWithImage);
        }

        private void CanvasWithImage_OnMouseMoveWhileDrawing(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var line = new Line
                {
                    Stroke = SystemColors.HighlightBrush,
                    X1 = currentPoint.X,
                    Y1 = currentPoint.Y,
                    X2 = e.GetPosition(canvasWithImage).X,
                    Y2 = e.GetPosition(canvasWithImage).Y
                };

                line.MouseMove += Line_OnMouseMoveWhileDrawing;

                currentPoint = e.GetPosition(canvasWithImage);

                canvasWithImage.Children.Add(line);
            }
        }

        private void Line_OnMouseMoveWhileDrawing(object sender, MouseEventArgs e)
        {
            if (btnErase.IsChecked == true)
            {
                canvasWithImage.Children.Remove((Line) sender);
            }
        }

        private void BtnDraw_OnChecked(object sender, RoutedEventArgs e)
        {
            btnErase.IsChecked = false;
            canvasWithImage.MouseDown += CanvasWithImage_OnMouseDownWhileDrawing;
            canvasWithImage.MouseMove += CanvasWithImage_OnMouseMoveWhileDrawing;
        }

        private void BtnDraw_OnUnchecked(object sender, RoutedEventArgs e)
        {
            canvasWithImage.MouseDown -= CanvasWithImage_OnMouseDownWhileDrawing;
            canvasWithImage.MouseMove -= CanvasWithImage_OnMouseMoveWhileDrawing;
        }

        private void BtnErase_OnChecked(object sender, RoutedEventArgs e)
        {
            btnDraw.IsChecked = false;
        }

        private void BtnErase_OnUnchecked(object sender, RoutedEventArgs e)
        {
        }

        private void CanvasWithImage_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                openFile(((string[]) e.Data.GetData(DataFormats.FileDrop))[0]);
            }
        }

        private void RotateImageSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var transform = new RotateTransform(e.NewValue)
            {
                CenterX = canvasWithImage.ActualWidth / 2,
                CenterY = canvasWithImage.ActualHeight / 2
            };
            canvasWithImage.LayoutTransform = transform;
        }

        [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH",
            MessageId = "type: System.Byte[]")]
        private void BrightnessSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (viewedImage.Source != null)
            {
                applyBitmapEffect(viewedImage, bytes => BrightnessByteEffect(bytes,  (int) (e.NewValue - e.OldValue)));
            }

        }

        
        
        private byte[] BrightnessByteEffect(byte[] source, int value)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (i % 4 != 3)
                {
                    var newVal = source[i] + value; 
                    if ((newVal <= byte.MaxValue) && (newVal > byte.MinValue))
                    {
                        source[i] = (byte)(newVal);
                    }
                    else
                    {
                        if (source[i] + value > byte.MaxValue)
                        {
                            source[i] = byte.MaxValue;
                        }
                        else
                        {
                            source[i] = byte.MinValue;
                        }
                    }
                }
            }

            return source;
        }

        private void ScaleSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (viewedImage.Source != null)
            {
                var xCoef = (e.NewValue + 10) / 10;
                var yCoef = (e.NewValue + 10) / 10;
                var transform = new ScaleTransform(xCoef, yCoef);
                viewedImage.RenderTransform = transform;
                canvasWithImage.Width = viewedImage.Source.Width * xCoef;
                canvasWithImage.Height = viewedImage.Source.Height * yCoef;
            }

        }

        private void applyBitmapEffect(Image image, ByteEffect effect)
        {
            BitmapSource bitmapSource = (BitmapSource) image.Source;
            
            int height = bitmapSource.PixelHeight;
            int width  = bitmapSource.PixelWidth;
            int stride = width * ((bitmapSource.Format.BitsPerPixel + 7) / 8);

            byte[] bytes = new byte[height * stride];
            bitmapSource.CopyPixels(bytes, stride, 0);

            bytes= effect(bytes);
            image.Source = BitmapImage.Create(
                bitmapSource.PixelWidth,
                bitmapSource.PixelHeight,
                bitmapSource.DpiX,
                bitmapSource.DpiY,
                bitmapSource.Format,
                bitmapSource.Palette,
                bytes,
                ((bitmapSource.PixelWidth * bitmapSource.Format.BitsPerPixel + 31) / 32) * 4
            );
        }

        private void ContrastSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {   
            if (viewedImage.Source != null)
            {
                applyBitmapEffect(viewedImage, bytes => ContrastByteEffect(bytes, Math.Pow((100.0 + e.NewValue) / 100.0, 2)));
            }
        }

        private byte[] ContrastByteEffect(byte[] source, double value)
        {
            for (int i = 0; i < source.Length; i++)
            {
                if (i % 4 != 3)
                {
                    var newVal = ((((source[i] / 255.0) - 0.5) * value) + 0.5) * 255.0; 
                    if ((newVal <= byte.MaxValue) && (newVal > byte.MinValue))
                    {
                        source[i] = (byte)(newVal);
                    }
                    else
                    {
                        if (source[i] + value > byte.MaxValue)
                        {
                            source[i] = byte.MaxValue;
                        }
                        else
                        {
                            source[i] = byte.MinValue;
                        }
                    }
                }
            }

            return source;
        }

        private void AdjustColorsSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (viewedImage.Source != null)
            {
                applyBitmapEffect(viewedImage, bytes => AdjustColorsByteEffect(bytes,  (int) (e.NewValue - e.OldValue)));
            }
        }

        private byte[] AdjustColorsByteEffect(byte[] source, int value)
        {   
            for (int i = 0; i < source.Length; i = i + 4)
            {
                Color oldColor = Color.FromArgb(source[i], source[i + 1], source[i + 2]);
               
                double colorHue;
                double colorSaturation;
                double colorValue;
                
                ColorToHSV(oldColor, out colorHue, out colorSaturation, out colorValue);
                var newColor = ColorFromHSV(colorHue + value, colorSaturation, colorValue);
                
                source[i] = newColor.R;
                source[i + 1] = newColor.G;
                source[i + 2] = newColor.B;
            }

            return source;
        }
        public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1d - (1d * min / max);
            value = max / 255d;
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
    }

}