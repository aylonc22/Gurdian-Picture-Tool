using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Syncfusion.WinForms.Controls;
using System.Threading;

namespace Gurdian_Picture_Tool
{
    public partial class Form2 : SfForm
    {
        static Settings settings = Settings.Instance;
        #region Pars       
        static Pen crpPen = new Pen(Color.Red, 5);
        static Pen crpPen2 = new Pen(Color.Red, 5);
        static int crpX, crpY;
        static int crpX2, crpY2;
        static int width1, height1, width2, height2;
        static string saveFile, bmName;
        bool shouldMove = false;
        bool shouldLeft = false;
        bool shouldRight = false;
        bool shouldTop = false;
        bool shouldBot = false;
        int moveX = -1;
        int moveY = -1;
        bool shouldMove2 = false;
        bool shouldLeft2 = false;
        bool shouldRight2 = false;
        bool shouldTop2 = false;
        bool shouldBot2 = false;
        int moveX2 = -1;
        int moveY2 = -1;


        Bitmap bm;
        static string bmPath;
        Bitmap bmfull;
        static string bmFullPath;
        Bitmap bmfull1;
        Bitmap bmfull2;
        #endregion
        public Form2(Bitmap bm, Bitmap bmfull, string bmName, string bmPath, string bmFullPath, string saveFile)
        {
            InitializeComponent();
            this.Style.Border.Color = Color.FromArgb(194, 140, 23);
            init(bm, bmfull, bmName, bmPath, bmFullPath, saveFile);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                Directory.CreateDirectory(saveFile + "\\10x3");
                Directory.CreateDirectory(saveFile + "\\4x5");
                Directory.CreateDirectory(saveFile + "\\Card_Light");
                Directory.CreateDirectory(saveFile + "\\Full_Light");
                DoubleCheck();
                Bitmap bm10X3 = (Bitmap)bmfull.Clone(new Rectangle(crpX, crpY, width1, height1), bmfull.PixelFormat);
                Bitmap bm4X5 = (Bitmap)bmfull.Clone(new Rectangle(crpX2, crpY2, width2, height2), bmfull.PixelFormat);
                string bm10X3Input = saveFile + "\\10x3" + bmName + "temp.Png";
                string bm4X5Input = saveFile + "\\4x5" + bmName + "temp.Png";
                bm10X3.Save(bm10X3Input, System.Drawing.Imaging.ImageFormat.Png);
                bm4X5.Save(bm4X5Input, System.Drawing.Imaging.ImageFormat.Png);
                JsWrap(bm10X3Input, saveFile + "\\10x3",true,true);
                JsWrap(bm4X5Input, saveFile + "\\4x5",true,true);
                JsWrap(bmFullPath, saveFile + "\\Full_Light", false,true);
                JsWrap(bmPath, saveFile + "\\Card_Light", false);
                this.Cursor = Cursors.Default;
                this.Close();
            }
            catch
            {
                DialogResult dialogResult = MessageBox.Show("Try Again?", "Failed", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    Form1.FailedImages.Add(bmName);
                    this.Close();
                }
            }
        }
        #region PictureBox1's Functionallity
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    double ratioW = 10d / 3d;
                    double ratioH = 3d / 10d;
                    if (shouldMove)
                    {
                        this.pictureBox1.Refresh();
                        crpX = crpX + getReverseRatio(e.X) - getReverseRatio(moveX);
                        crpY = crpY + getReverseRatio(e.Y, true) - getReverseRatio(moveY, true);

                        crpX = crpX + width1 > bmfull.Width ? (bmfull.Width - width1) : crpX;
                        crpX = crpX < 0 ? 0 : crpX;
                        crpY = crpY + height1 > bmfull.Height ? (bmfull.Height - height1) : crpY;
                        crpY = crpY < 0 ? 0 : crpY;
                        this.bmfull1 = (Bitmap)bmfull.Clone();
                        this.pictureBox1.Image = bmfull1;
                        Graphics graphics = Graphics.FromImage(bmfull1);
                        graphics.DrawRectangle(crpPen, crpX, crpY, width1, height1);
                        graphics.Dispose();
                    }
                    else
                    if (shouldLeft)
                    {
                        this.pictureBox1.Refresh();
                        int crpX_temp = crpX;
                        int width1_temp = width1;
                        int height1_temp = height1;
                        crpX = crpX + getReverseRatio(e.X) - getReverseRatio(moveX);
                        if (crpX > 0)
                        {
                            width1 = width1 + (crpX_temp - crpX);
                            height1 = (int)((double)width1 * ratioH);
                            if (height1 + crpY > bmfull.Height)
                            {
                                height1 = height1_temp;
                                crpX = crpX_temp;
                                width1 = width1_temp;
                            }
                        }
                        if (crpX <= 0)
                            crpX = 0;


                        this.bmfull1 = (Bitmap)bmfull.Clone();
                        this.pictureBox1.Image = bmfull1;
                        Graphics graphics = Graphics.FromImage(bmfull1);
                        graphics.DrawRectangle(crpPen, crpX, crpY, width1, height1);
                        graphics.Dispose();
                    }
                    else
                    if (shouldRight)
                    {
                        this.pictureBox1.Refresh();
                        int width1_temp = width1;
                        int height1_temp = height1;
                        width1 = width1 + getReverseRatio(e.X) - getReverseRatio(moveX);
                        height1 = (int)((double)width1 * ratioH);
                        if (height1 + crpY > bmfull.Height)
                        {
                            height1 = height1_temp;
                            width1 = width1_temp;
                        }
                        if (crpX + width1 > bmfull.Width)
                            width1 = width1_temp;


                        this.bmfull1 = (Bitmap)bmfull.Clone();
                        this.pictureBox1.Image = bmfull1;
                        Graphics graphics = Graphics.FromImage(bmfull1);
                        graphics.DrawRectangle(crpPen, crpX, crpY, width1, height1);
                        graphics.Dispose();
                    }
                    else
                    if (shouldBot)
                    {
                        this.pictureBox1.Refresh();
                        int width1_temp = width1;
                        int height1_temp = height1;
                        height1 = height1 + getReverseRatio(e.Y) - getReverseRatio(moveY);
                        width1 = (int)((double)height1 * ratioW);
                        if (height1 + crpY > bmfull.Height)
                        {
                            height1 = height1_temp;
                            width1 = width1_temp;
                        }
                        if (crpX + width1 > bmfull.Width)
                            width1 = width1_temp;


                        this.bmfull1 = (Bitmap)bmfull.Clone();
                        this.pictureBox1.Image = bmfull1;
                        Graphics graphics = Graphics.FromImage(bmfull1);
                        graphics.DrawRectangle(crpPen, crpX, crpY, width1, height1);
                        graphics.Dispose();
                    }
                    else
                    if (shouldTop)
                    {
                        this.pictureBox1.Refresh();
                        int crpY_temp = crpY;
                        int width1_temp = width1;
                        int height1_temp = height1;
                        crpY = crpY + getReverseRatio(e.Y) - getReverseRatio(moveY);
                        width1 = (int)((double)height1 * ratioW);
                        if (crpY > 0)
                        {
                            height1 = height1 + (crpY_temp - crpY);
                            if (height1 + crpY > bmfull.Height)
                            {
                                height1 = height1_temp;
                                width1 = width1_temp;
                            }
                        }
                        if (crpX + width1 > bmfull.Width)
                            width1 = width1_temp;
                        if (crpY < 0)
                        {
                            crpY = 0;
                            height1 = height1_temp;
                        }

                        this.bmfull1 = (Bitmap)bmfull.Clone();
                        this.pictureBox1.Image = bmfull1;
                        Graphics graphics = Graphics.FromImage(bmfull1);
                        graphics.DrawRectangle(crpPen, crpX, crpY, width1, height1);
                        graphics.Dispose();
                    }
                }              
                if ((getRatio(crpY, true) <= e.Y + 5 && getRatio(crpY, true) >= e.Y - 5) ||  (getRatio(crpY + height1, true) <= e.Y + 5 && getRatio(crpY + height1, true) >= e.Y - 5))
                    this.Cursor = Cursors.SizeNS;
                else
                    if ((getRatio(crpX) <= e.X + 5 && getRatio(crpX) >= e.X - 5) || (getRatio(crpX + width1) <= e.X + 5 && getRatio(crpX + width1) >= e.X - 5))
                    this.Cursor = Cursors.SizeWE;
                else
                    if (getRatio(crpY, true) < e.Y && getRatio(crpY + height1, true) > e.Y && getRatio(crpX) < e.X && getRatio(crpX + width1) > e.X)
                    this.Cursor = Cursors.SizeAll;
                else
                    this.Cursor = Cursors.Default;
                moveX = e.X;
                moveY = e.Y;
            }
            catch
            {
                init(bm, bmfull, bmName, bmPath, bmFullPath, saveFile, "bm1");
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.shouldMove = false;
            this.shouldLeft = false;
            this.shouldRight = false;
            this.shouldTop = false;
            this.shouldBot = false;
            this.moveX = -1;
            this.moveY = -1;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = (Bitmap)bmfull.Clone(new Rectangle(crpX, crpY, width1, height1), bmfull.PixelFormat);
                this.pictureBox4.Image = bm;
            }
            catch
            {
                init(bm, bmfull, bmName, bmPath, bmFullPath, saveFile, "bm1");
            }

        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           
            if ( getRatio(crpY, true) <= e.Y + 5 && getRatio(crpY, true) >= e.Y - 5)
                shouldTop = true;
            else
           if (getRatio(crpY + height1, true) <= e.Y + 5 && getRatio(crpY + height1, true) >= e.Y - 5)
                shouldBot = true;
            else
           if (getRatio(crpX) <= e.X + 5 && getRatio(crpX) >= e.X - 5)
                shouldLeft = true;
            else
           if (getRatio(crpX + width1) <= e.X + 5 && getRatio(crpX + width1) >= e.X - 5)
                shouldRight = true;
            else
                 if (getRatio(crpY, true) < e.Y && getRatio(crpY + height1, true) > e.Y && getRatio(crpX) < e.X && getRatio(crpX + width1) > e.X)
                     shouldMove = true;
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            if (!shouldMove && !shouldLeft && !shouldRight && !shouldTop && !shouldBot)
                this.Cursor = Cursors.Default;
        }
        #endregion
        #region PictureBox2's Functionallity
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    double ratioW = 4d / 5d;
                    double ratioH = 5d / 4d;
                    if (shouldMove2)
                    {
                        this.pictureBox2.Refresh();
                        crpX2 = crpX2 + getReverseRatio(e.X) - getReverseRatio(moveX2);
                        crpY2 = crpY2 + getReverseRatio(e.Y, true) - getReverseRatio(moveY2, true);

                        crpX2 = crpX2 + width2 > bmfull.Width ? (bmfull.Width - width2) : crpX2;
                        crpX2 = crpX2 < 0 ? 0 : crpX2;
                        crpY2 = crpY2 + height2 > bmfull.Height ? (bmfull.Height - height2) : crpY2;
                        crpY2 = crpY2 < 0 ? 0 : crpY2;
                        this.bmfull2 = (Bitmap)bmfull.Clone();
                        this.pictureBox2.Image = bmfull2;
                        Graphics graphics = Graphics.FromImage(bmfull2);
                        graphics.DrawRectangle(crpPen2, crpX2, crpY2, width2, height2);
                        graphics.Dispose();
                    }
                    else
                    if (shouldLeft2)
                    {
                        this.pictureBox2.Refresh();
                        int crpX2_temp = crpX2;
                        int width2_temp = width2;
                        int height2_temp = height2;
                        crpX2 = crpX2 + getReverseRatio(e.X) - getReverseRatio(moveX2);
                        if (crpX2 > 0)
                        {
                            width2 = width2 + (crpX2_temp - crpX2);
                            height2 = (int)((double)width2 * ratioH);
                            if (height2 + crpY2 > bmfull.Height)
                            {
                                height2 = height2_temp;
                                crpX2 = crpX2_temp;
                                width2 = width2_temp;
                            }
                        }
                        if (crpX2 <= 0)
                            crpX2 = 0;


                        this.bmfull2 = (Bitmap)bmfull.Clone();
                        this.pictureBox2.Image = bmfull2;
                        Graphics graphics = Graphics.FromImage(bmfull2);
                        graphics.DrawRectangle(crpPen2, crpX2, crpY2, width2, height2);
                        graphics.Dispose();
                    }
                    else
                    if (shouldRight2)
                    {
                        this.pictureBox2.Refresh();
                        int width2_temp = width2;
                        int height2_temp = height2;
                        width2 = width2 + getReverseRatio(e.X) - getReverseRatio(moveX2);
                        height2 = (int)((double)width2 * ratioH);
                        if (height2 + crpY2 > bmfull.Height)
                        {
                            height2 = height2_temp;
                            width2 = width2_temp;
                        }
                        if (crpX2 + width2 > bmfull.Width)
                            width2 = width2_temp;


                        this.bmfull2 = (Bitmap)bmfull.Clone();
                        this.pictureBox2.Image = bmfull2;
                        Graphics graphics = Graphics.FromImage(bmfull2);
                        graphics.DrawRectangle(crpPen2, crpX2, crpY2, width2, height2);
                        graphics.Dispose();
                    }
                    else
                    if (shouldBot2)
                    {
                        this.pictureBox2.Refresh();
                        int width2_temp = width2;
                        int height2_temp = height2;
                        height2 = height2 + getReverseRatio(e.Y) - getReverseRatio(moveY2);
                        width2 = (int)((double)height2 * ratioW);
                        if (height2 + crpY2 > bmfull.Height)
                        {
                            height2 = height2_temp;
                            width2 = width2_temp;
                        }
                        if (crpX2 + width2 > bmfull.Width)
                            width2 = width2_temp;


                        this.bmfull2 = (Bitmap)bmfull.Clone();
                        this.pictureBox2.Image = bmfull2;
                        Graphics graphics = Graphics.FromImage(bmfull2);
                        graphics.DrawRectangle(crpPen2, crpX2, crpY2, width2, height2);
                        graphics.Dispose();
                    }
                    else
                    if (shouldTop2)
                    {
                        this.pictureBox2.Refresh();
                        int crpY2_temp = crpY2;
                        int width2_temp = width2;
                        int height2_temp = height2;
                        crpY2 = crpY2 + getReverseRatio(e.Y) - getReverseRatio(moveY2);
                        width2 = (int)((double)height2 * ratioW);
                        if (crpY2 > 0)
                        {
                            height2 = height2 + (crpY2_temp - crpY2);
                            if (height2 + crpY2 > bmfull.Height)
                            {
                                height2 = height2_temp;
                                width2 = width2_temp;
                            }
                        }
                        if (crpX2 + width2 > bmfull.Width)
                            width2 = width2_temp;
                        if (crpY2 < 0)
                        {
                            crpY2 = 0;
                            height2 = height2_temp;
                        }

                        this.bmfull2 = (Bitmap)bmfull.Clone();
                        this.pictureBox2.Image = bmfull2;
                        Graphics graphics = Graphics.FromImage(bmfull2);
                        graphics.DrawRectangle(crpPen2, crpX2, crpY2, width2, height2);
                        graphics.Dispose();
                    }
                }
                if ((getRatio(crpY2, true) <= e.Y + 5 && getRatio(crpY2, true) >= e.Y - 5) || (getRatio(crpY2 + height2, true) <= e.Y + 5 && getRatio(crpY2 + height2, true) >= e.Y - 5))
                    this.Cursor = Cursors.SizeNS;
                else
                    if ((getRatio(crpX2) <= e.X + 5 && getRatio(crpX2) >= e.X - 5) || (getRatio(crpX2 + width2) <= e.X + 5 && getRatio(crpX2 + width2) >= e.X - 5))
                    this.Cursor = Cursors.SizeWE;
                else
                    if (getRatio(crpY2, true) < e.Y && getRatio(crpY2 + height2, true) > e.Y && getRatio(crpX2) < e.X && getRatio(crpX2 + width2) > e.X)
                    this.Cursor = Cursors.SizeAll;
                else
                    if (!shouldMove)
                    this.Cursor = Cursors.Default;
                moveX2 = e.X;
                moveY2 = e.Y;
            }
            catch
            {
                init(bm, bmfull, bmName, bmPath, bmFullPath, saveFile, "bm2");
            }
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (!shouldMove2)
                this.Cursor = Cursors.Default;
            shouldLeft2 = false;
            shouldRight2 = false;
            shouldTop2 = false;
            shouldBot2 = false;
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {            
            if (getRatio(crpY2, true) <= e.Y + 5 && getRatio(crpY2, true) >= e.Y - 5)
                shouldTop2 = true;
            else
            if (getRatio(crpY2 + height2, true) <= e.Y + 5 && getRatio(crpY2 + height2, true) >= e.Y - 5)
                shouldBot2 = true;
            else
            if (getRatio(crpX2) <= e.X + 5 && getRatio(crpX2) >= e.X - 5)
                shouldLeft2 = true;
            else
            if (getRatio(crpX2 + width2) <= e.X + 5 && getRatio(crpX2 + width2) >= e.X - 5)
                shouldRight2 = true;
            else
                if (getRatio(crpY2, true) < e.Y && getRatio(crpY2 + height2, true) > e.Y && getRatio(crpX2) < e.X && getRatio(crpX2 + width2) > e.X)
                shouldMove2 = true;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = (Bitmap)bmfull.Clone(new Rectangle(crpX2, crpY2, width2, height2), bmfull.PixelFormat);
                this.pictureBox4.Image = bm;
            }
            catch
            {
                init(bm, bmfull, bmName, bmPath, bmFullPath, saveFile, "bm2");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            init(bm, bmfull, bmName, bmPath, bmFullPath, saveFile, "bm2");
        }
        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            this.shouldMove2 = false;
            this.shouldLeft2 = false;
            this.shouldRight2 = false;
            this.shouldTop2 = false;
            this.shouldBot2 = false;
            this.moveX2 = -1;
            this.moveY2 = -1;
        }
        #endregion
        #region Methods
        #region Bitmap PictureBox Ratios
        /// <summary>
        /// from picturebox pixel to full image pixel
        /// false for height true for width
        /// </summary>
        /// <param name="par"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private int getReverseRatio(int par, bool flag = false)
        {
            double y = (double)bmfull.Height / (double)this.pictureBox1.Height;
            double x = (double)bmfull.Width / (double)this.pictureBox1.Width;
            return flag ? (int)(y * par) : (int)(x * par);
        }
        /// <summary>
        /// from full image pixel to picturebox pixel
        /// false for height true for width
        /// </summary>
        /// <param name="par"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        private int getRatio(int par, bool flag = false)
        {
            double y = (double)this.pictureBox1.Height / (double)bmfull.Height;
            double x = (double)this.pictureBox1.Width / (double)bmfull.Width;
            return flag ? (int)(y * par) : (int)(x * par);
        }
        #endregion
        #region static
        private static void DoubleCheck()
        {
            string check_10x3_png = saveFile + "\\10x3" + bmName + ".png";
            string check_4x5_png = saveFile + "\\4x5" + bmName + ".png";
            string check_card_png = saveFile + "\\Card_Light" + bmName + ".png";
            string check_full_png = saveFile + "\\Full_Light" + bmName + ".png";
            string check_10x3_jpg = saveFile + "\\10x3" + bmName + ".jpg";
            string check_4x5_jpg = saveFile + "\\4x5" + bmName + ".jpg";
            string check_card_jpg = saveFile + "\\Card_Light" + bmName + ".jpg";
            string check_full_jpg = saveFile + "\\Full_Light" + bmName + ".jpg";
            if (File.Exists(check_10x3_png))
                File.Delete(check_10x3_png);
            if (File.Exists(check_4x5_png))
                File.Delete(check_4x5_png);
            if (File.Exists(check_card_png))
                File.Delete(check_card_png);
            if (File.Exists(check_full_png))
                File.Delete(check_full_png);
            if (File.Exists(check_10x3_jpg))
                File.Delete(check_10x3_jpg);
            if (File.Exists(check_4x5_jpg))
                File.Delete(check_4x5_jpg);
            if (File.Exists(check_card_jpg))
                File.Delete(check_card_jpg);
            if (File.Exists(check_full_jpg))
                File.Delete(check_full_jpg);
        }
        private static void MakeRect(Bitmap bitmap, bool flag = false)
        {
            //4x5{y:1023 x:819} 10x3{y:479 x:1600}    defualt card       
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                if (flag)
                {
                    crpX = crpX + width1 > bitmap.Width ? (bitmap.Width - width1) : crpX;
                    crpY = crpY + height1 > bitmap.Height ? (bitmap.Height - height1) : crpY;
                    if (crpX < 0)
                        crpX = 0;

                    graphics.DrawRectangle(crpPen, new Rectangle(crpX, crpY, width1, height1));
                }
                else
                {

                    crpX2 = crpX2 + width2 > bitmap.Width ? (bitmap.Width - width2) : crpX2;
                    crpY2 = crpY2 + height2 > bitmap.Height ? (bitmap.Height - height2) : crpY2;
                    if (crpX2 < 0)
                        crpX2 = 0;
                    graphics.DrawRectangle(crpPen2, new Rectangle(crpX2, crpY2, width2, height2));
                }
                graphics.Dispose();
            }
        }
        public static void Apply(Bitmap bm, Bitmap bmfull, string BmName, string bmPath, string bmFullPath, string saveFile)
        {            
            try
            {
                if (bmfull.Width == 2048 && bmfull.Height == 1024)
                {
                    width1 = 1600;
                    height1 = 479;
                }
                else
               if (bmfull.Width == 1024 && bmfull.Height == 1024)
                {
                    width1 = 1024;
                    height1 = 307;
                }
                else
                {
                    width1 = 1490;
                    height1 = 447;
                }
                Bitmap bmfull1 = (Bitmap)bmfull.Clone(); ;
                Bitmap bmfull2 = (Bitmap)bmfull.Clone();
                Emgu.CV.Util.VectorOfPoint points;

                points = Fbim.GetFbim(bm, bmfull);
                int point2X = points[2].X;
                int point3X = points[3].X;
                int point3Y = points[3].Y;
                if (point2X > bmfull.Width)
                    point2X = bmfull.Width;
                if (point2X < 0)
                    point2X = 0;
                if (point3X > bmfull.Width)
                    point3X = bmfull.Width;
                if (point3X < 0)
                    point3X = 0;
                if (point3Y > bmfull.Height)
                    point3Y = bmfull.Height;
                if (point3Y < 0)
                    point3Y = 0;
                width2 = (point2X - point3X);
                height2 = (int)((double)1.25 * width2);
                if (height2 > bmfull.Height)
                    height2 = bmfull.Height;
                crpX = point3X;
                crpX2 = point3X;
                crpY = point3Y;
                crpY2 = point3Y;


                bmName = BmName;
                MakeRect(bmfull1, true);
                MakeRect(bmfull2);
                Directory.CreateDirectory(saveFile + "\\10x3");
                Directory.CreateDirectory(saveFile + "\\4x5");
                Directory.CreateDirectory(saveFile + "\\Card_Light");
                Directory.CreateDirectory(saveFile + "\\Full_Light");
                DoubleCheck();
                Bitmap bm10X3 = (Bitmap)bmfull.Clone(new Rectangle(crpX, crpY, width1, height1), bmfull.PixelFormat);
                Bitmap bm4X5 = (Bitmap)bmfull.Clone(new Rectangle(crpX2, crpY2, width2, height2), bmfull.PixelFormat);
                string bm10X3Input = saveFile + "\\10x3" + bmName + "temp.png";
                string bm4X5Input = saveFile + "\\4x5" + bmName + "temp.png";
                bm10X3.Save(bm10X3Input, System.Drawing.Imaging.ImageFormat.Png);
                bm4X5.Save(bm4X5Input, System.Drawing.Imaging.ImageFormat.Png);
                JsWrap(bm10X3Input, saveFile + "\\10x3");
                JsWrap(bm4X5Input, saveFile + "\\4x5");
                JsWrap(bmFullPath, saveFile + "\\Full_Light", false,true);
                JsWrap(bmPath, saveFile + "\\Card_Light", false);
            }
            catch { Form1.FailedImages.Add(BmName); }

        }
        #endregion
        private void init(Bitmap bm, Bitmap bmfull, string BmName, string BmPath, string BmFullPath, string SaveFile, string checker = "")
        {
            try
            {
                if (!checker.Equals(""))
                    this.Cursor = Cursors.WaitCursor;
                if (checker.Equals("bm1") || checker.Equals(""))
                {
                    if (bmfull.Width == 2048 && bmfull.Height == 1024)
                    {
                        width1 = 1600;
                        height1 = 479;
                    }
                    else
                   if (bmfull.Width == 1024 && bmfull.Height == 1024)
                    {
                        width1 = 1024;
                        height1 = 307;
                    }
                    else
                    {
                        width1 = 1490;
                        height1 = 447;
                    }
                }
                //Bitmap cropped = bm.Clone(new Rectangle(bm.Width / 2 - 75, 100, 130, bm.Height / 2 - 125), bm.PixelFormat);            
                var points = Fbim.GetFbim(bm, bmfull);
                int point2X = points[2].X;
                int point3X = points[3].X;
                int point3Y = points[3].Y;
                this.bm = bm;
                this.bmfull = bmfull;
                bmFullPath = BmFullPath;
                bmPath = BmPath;
                if (checker.Equals("bm1") || checker.Equals(""))
                    this.bmfull1 = (Bitmap)bmfull.Clone();
                if (checker.Equals("bm2") || checker.Equals(""))
                    this.bmfull2 = (Bitmap)bmfull.Clone();
                this.pictureBox1.Image = bmfull1;
                this.pictureBox3.Image = bm;
                this.pictureBox2.Image = bmfull2;
                saveFile = SaveFile;
                bmName = BmName;
                if (point2X > bmfull.Width)
                    point2X = bmfull.Width;
                if (point2X < 0)
                    point2X = 0;
                if (point3X > bmfull.Width)
                    point3X = bmfull.Width;
                if (point3X < 0)
                    point3X = 0;
                if (point3Y > bmfull.Height)
                    point3Y = bmfull.Height;
                if (point3Y < 0)
                    point3Y = 0;
                if (checker.Equals("bm2") || checker.Equals(""))
                {
                    width2 = (point2X - point3X);
                    height2 = (int)((double)1.25 * width2);
                    if (height2 > bmfull.Height)
                        height2 = bmfull.Height;
                    crpX2 = point3X;
                    crpY2 = point3Y;
                    MakeRect(bmfull2);
                }
                if (checker.Equals("bm1") || checker.Equals(""))
                {
                    crpX = point3X;
                    crpY = point3Y;
                    MakeRect(bmfull1, true);
                }
                if (!checker.Equals(""))
                    this.Cursor = Cursors.Default;
            }
            catch { Form1.FailedImages.Add(BmName); this.Close(); }
        }
        #region Js Wrapper  
        /// <summary>
        ///  flag = false jpg convert
        ///  flag = true png compress
        ///  js is not able to script through file name with space
        /// </summary>
        /// <param name="flag"></param>
        private static void JsWrap(string input, string output, bool _temp = true,bool full = false)
        {
            bool flag = settings.format.Equals("png");
            string name = bmName;
            if (full)
                name += "-full";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
           startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";            
            startInfo.WorkingDirectory = settings.js;
            if (flag)
            {
                double fs = new FileInfo(input).Length / 1024;
                int pngQuality = (int)(((double)settings.pngQualityInKB / fs) * 100.0);
                if (pngQuality > 100)
                    pngQuality = 100;
                if (pngQuality < 6)
                    pngQuality = 6;
                startInfo.Arguments = "/C node index " + input + " png " + output + " " + name + " " + pngQuality.ToString();
            }
            else
                startInfo.Arguments = "/C  node index "+ input + " jpg " + output + " " + name + " " + settings.jpgQuality + " " + settings.r + " " + settings.g + " " + settings.b;
            process.StartInfo = startInfo;
            process.Start();
            if (_temp)
            {
                var t = new Thread(() =>
                {

                    bool temp = true;
                    while (temp)
                    {
                        Thread.Sleep(200);
                        if ((flag && File.Exists(output + name + ".png")) || (!flag && File.Exists(output + name + ".jpg")))
                        {
                            try
                            {
                                File.Delete(input);
                                temp = false;
                            }
                            catch { }
                        }
                    }
                });
                t.Start();
            }
        }
        #endregion
        #endregion
        #region Hover Buttons
        private void button3_Click(object sender, EventArgs e)
        {
            init(bm, bmfull, bmName, bmPath, bmFullPath, saveFile, "bm1");
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        #endregion
    }
}
