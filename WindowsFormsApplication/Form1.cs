using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        private Point lastPoint;
        private int lastRotationAngle;
        private int lastBrightness;
        private int lastImageColor;
        private int lastContrast;
        private int lastScale;
        private bool isMouseDownWhileDrawing;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (openImageFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                lastPoint = Point.Empty;
                lastRotationAngle = 0;
                lastBrightness = 0;
                lastImageColor = 0;
                lastContrast = 0;
                lastScale = 10;
                isMouseDownWhileDrawing = false;
                trackBar_Brightness.Value = lastBrightness;
                trackBar_Contrast.Value = lastContrast;
                trackBar_Rotate.Value = lastRotationAngle;
                trackBar_AdjustColors.Value = lastImageColor;
                trackBar_Scale.Value = lastScale;
                checkBox_Pencil.Checked = false;
                pictureBox_Main.Image = Image.FromFile(openImageFileDialog.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveImageFileDialog.ShowDialog() != DialogResult.Cancel)
            {
                pictureBox_Main.Image.Save(saveImageFileDialog.FileName);
                MessageBox.Show("File \"" + saveImageFileDialog.FileName + "\" successfully saved");
            }
        }

        public static Bitmap RotateImage(Image inputImage, float angleDegrees, bool upsizeOk, 
                                   bool clipOk, Color backgroundColor)
      {
         // Test for zero rotation and return a clone of the input image
         if (angleDegrees == 0f)
            return (Bitmap)inputImage.Clone();

         // Set up old and new image dimensions, assuming upsizing not wanted and clipping OK
         int oldWidth = inputImage.Width;
         int oldHeight = inputImage.Height;
         int newWidth = oldWidth;
         int newHeight = oldHeight;
         float scaleFactor = 1f;

         // If upsizing wanted or clipping not OK calculate the size of the resulting bitmap
         if (upsizeOk || !clipOk)
         {
            double angleRadians = angleDegrees * Math.PI / 180d;

            double cos = Math.Abs(Math.Cos(angleRadians));
            double sin = Math.Abs(Math.Sin(angleRadians));
            newWidth = (int)Math.Round(oldWidth * cos + oldHeight * sin);
            newHeight = (int)Math.Round(oldWidth * sin + oldHeight * cos);
         }

         // If upsizing not wanted and clipping not OK need a scaling factor
         if (!upsizeOk && !clipOk)
         {
            scaleFactor = Math.Min((float)oldWidth / newWidth, (float)oldHeight / newHeight);
            newWidth = oldWidth;
            newHeight = oldHeight;
         }

         // Create the new bitmap object. If background color is transparent it must be 32-bit, 
         //  otherwise 24-bit is good enough.
         Bitmap newBitmap = new Bitmap(newWidth, newHeight, backgroundColor == Color.Transparent ? 
                                          PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
         newBitmap.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution);

         // Create the Graphics object that does the work
         using (Graphics graphicsObject = Graphics.FromImage(newBitmap))
         {
            graphicsObject.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphicsObject.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphicsObject.SmoothingMode = SmoothingMode.HighQuality;

            // Fill in the specified background color if necessary
            if (backgroundColor != Color.Transparent)
               graphicsObject.Clear(backgroundColor);

            // Set up the built-in transformation matrix to do the rotation and maybe scaling
            graphicsObject.TranslateTransform(newWidth / 2f, newHeight / 2f);

            if (scaleFactor != 1f)
               graphicsObject.ScaleTransform(scaleFactor, scaleFactor);

            graphicsObject.RotateTransform(angleDegrees);
            graphicsObject.TranslateTransform(-oldWidth / 2f, -oldHeight / 2f);

            // Draw the result 
            graphicsObject.DrawImage(inputImage, 0, 0);
         }

         inputImage.Dispose();
         return newBitmap;
      }

    private void trackBar_Rotate_MouseUp(object sender, MouseEventArgs e)
    {
        pictureBox_Main.Image = RotateImage(pictureBox_Main.Image, trackBar_Rotate.Value - lastRotationAngle, true, false, Color.Transparent);
        lastRotationAngle = trackBar_Rotate.Value;
    }

    private void checkBox_Pencil_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBox_Pencil.Checked)
        {
            pictureBox_Main.MouseDown += pictureBox_Main_MouseDownWhileDrawing;
            pictureBox_Main.MouseMove += pictureBox_Main_MouseMoveWhileDrawing;
            pictureBox_Main.MouseUp += pictureBox_Main_MouseUpWhileDrawing;
            
        }
        else
        {
            pictureBox_Main.MouseDown -= pictureBox_Main_MouseDownWhileDrawing;
            pictureBox_Main.MouseMove -= pictureBox_Main_MouseMoveWhileDrawing;
            pictureBox_Main.MouseUp -= pictureBox_Main_MouseUpWhileDrawing;
        }
    }

    private void pictureBox_Main_MouseDownWhileDrawing(object sender, MouseEventArgs e)
 
    {
        lastPoint = e.Location;
        lastPoint.X -= (pictureBox_Main.Width - pictureBox_Main.Image.Width) / 2;
        lastPoint.Y -= (pictureBox_Main.Height - pictureBox_Main.Image.Height) / 2;
        
        isMouseDownWhileDrawing = true;
 
    }

    private void pictureBox_Main_MouseMoveWhileDrawing(Object sender, MouseEventArgs e)
    {
        if (!isMouseDownWhileDrawing || lastPoint.IsEmpty || pictureBox_Main.Image == null) return;

        
        Point newPoint = e.Location;
        newPoint.X -= (pictureBox_Main.Width - pictureBox_Main.Image.Width) / 2;
        newPoint.Y -= (pictureBox_Main.Height - pictureBox_Main.Image.Height) / 2;

        using (Graphics g = Graphics.FromImage(pictureBox_Main.Image))
 
        {//we need to create a Graphics object to draw on the picture box, its our main tool
 
            //when making a Pen object, you can just give it color only or give it color and pen size
 
            g.DrawLine(new Pen(Color.Black, 2), lastPoint, newPoint);
            g.SmoothingMode = SmoothingMode.HighSpeed;
            //this is to give the drawing a more smoother, less sharper look
 
        }
 
        pictureBox_Main.Invalidate();//refreshes the picturebox
        lastPoint = newPoint;//keep assigning the lastPoint to the current mouse position
    }
    
    private void pictureBox_Main_MouseUpWhileDrawing(object sender, MouseEventArgs e)
 
    {
        isMouseDownWhileDrawing = false;
        lastPoint = Point.Empty;
    }

    private void trackBar_Brightness_MouseUp(object sender, MouseEventArgs e)
    {
        float delta = (float) ((trackBar_Brightness.Value - lastBrightness) * 0.01);
        float[][] colorMatrixElements =
        {
            new float[] {1f,0f,0f,0f,0f},
            new float[] {0f,1f,0f,0f,0f},
            new float[] {0f,0f,1f,0f,0f},
            new float[] {0f,0f,0f,1f,0f},
            new float[] {delta,delta,delta,0,1}
        };
        lastBrightness = trackBar_Brightness.Value;
        Image tmp = pictureBox_Main.Image;
        pictureBox_Main.Image = applyColorMatrix(new ColorMatrix(colorMatrixElements), pictureBox_Main.Image);
        tmp.Dispose();
        
    }

    private Image applyColorMatrix(ColorMatrix colorMatrix, Image image)
    {
        ImageAttributes imageAttributes = new ImageAttributes();
        imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        
        Bitmap bm_dest = new Bitmap(Convert.ToInt32(image.Width), Convert.ToInt32(image.Height));
        using (Graphics _g = Graphics.FromImage(bm_dest))
        {
            _g.DrawImage(image, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
        }
        return bm_dest;
    }

    private void trackBar_Contrast_MouseUp(object sender, MouseEventArgs e)
    {
        
        float delta = (float) (trackBar_Contrast.Value * 0.01);
        var contrast = (float)Math.Pow((100.0 + delta) / 100.0, 2);
        float[][] colorMatrixElements =
        {
            new float[] {1 + contrast,0f,0f,0f,0f},
            new float[] {0f,1 + contrast,0f,0f,0f},
            new float[] {0f,0f,1 + contrast,0f,0f},
            new float[] {0f,0f,0f,1f,0f},
            new float[] {0.1f, 0.1f, 0.1f, 0f,1f}
        };    

        lastContrast = trackBar_Contrast.Value;
        Image tmp = pictureBox_Main.Image;
        pictureBox_Main.Image = applyColorMatrix(new ColorMatrix(colorMatrixElements), pictureBox_Main.Image);
        tmp.Dispose();
    }


    private void trackBar_Scale_MouseUp(object sender, MouseEventArgs e)
    {
        float delta = (float) ((trackBar_Scale.Value - lastScale) * 0.1);
        Image tmp = pictureBox_Main.Image;
        pictureBox_Main.Image = scaleImage(pictureBox_Main.Image, delta);
        tmp.Dispose();
    }
    
    public Image scaleImage(Image image, float scale)
    {
        Bitmap bitmap = new Bitmap((int)(image.Width * (1 + scale)), (int)(image.Height * (1 + scale)));

        using (var graphics = Graphics.FromImage(bitmap))
        {
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);            
        }
        
        return bitmap;
    }

    private void trackBar_AdjustColors_MouseUp(object sender, MouseEventArgs e)
    {
        
        double delta = trackBar_AdjustColors.Value ;

        var color = ColorFromHSV(delta, 1, 1);
        
        float[][] colorMatrixElements =
        {
            new float[] {color.R / 360f,0f,0f,0f,0f},
            new float[] {0f,color.G / 360f,0f,0f,0f},
            new float[] {0f,0f,color.B / 360f,0f,0f},
            new float[] {0f,0f,0f,1f,0f},
            new float[] {0.1f,0.1f,0.1f,0,1}
        };
        lastBrightness = trackBar_Brightness.Value;
        Image tmp = pictureBox_Main.Image;
        pictureBox_Main.Image = applyColorMatrix(new ColorMatrix(colorMatrixElements), pictureBox_Main.Image);
        tmp.Dispose();
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