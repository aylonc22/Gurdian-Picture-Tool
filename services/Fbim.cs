using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gurdian_Picture_Tool
{
    /// <summary>
    /// Feature Based Image Matching using EmguCV library
    /// </summary>
    public static class Fbim
    {
        public static Bitmap ApplyFbim(Bitmap cropped, Bitmap bmfull)
        {
            try
            {
                if (cropped == null || bmfull == null)
                    return null;

                var imgScene = new Bitmap(bmfull).ToImage<Bgr, byte>();
                var template = new Bitmap(cropped).ToImage<Gray, byte>();

                var vp = ProcessImage(template, imgScene.Convert<Gray, byte>());

                if (vp != null)
                {
                    CvInvoke.Polylines(imgScene, vp, true, new MCvScalar(0, 0, 255), 5);
                    return imgScene.AsBitmap();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");

            }
            return null;
        }

        public static VectorOfPoint GetFbim(Bitmap cropped, Bitmap bmfull)
        {
            try
            {
                if (cropped == null || bmfull == null)
                    return null;

                var imgScene = new Bitmap(bmfull).ToImage<Bgr, byte>();
                var template = new Bitmap(cropped).ToImage<Gray, byte>();

                var vp = ProcessImage(template, imgScene.Convert<Gray, byte>());

                return vp;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.ToString(), "Exception");

            }
            return null;
        }

        private static VectorOfPoint ProcessImage(Image<Gray, byte> template, Image<Gray, byte> sceneImage)
        {
            try
            {
                VectorOfPoint finalPoints = null;
                Mat homography = null;
                VectorOfKeyPoint templateKeyPoints = new VectorOfKeyPoint();
                VectorOfKeyPoint sceneKeyPoints = new VectorOfKeyPoint();
                Mat templateDescriptor = new Mat();
                Mat sceneDescriptor = new Mat();

                Mat mask;
                int k = 2;
                double uniquenessthreshold = 0.80;
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

                Brisk featureDetector = new Brisk();
                featureDetector.DetectAndCompute(template, null, templateKeyPoints, templateDescriptor, false);
                featureDetector.DetectAndCompute(sceneImage, null, sceneKeyPoints, sceneDescriptor, false);

                BFMatcher matcher = new BFMatcher(DistanceType.Hamming);
                matcher.Add(templateDescriptor);
                matcher.KnnMatch(sceneDescriptor, matches, k);

                mask = new Mat(matches.Size, 1, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));

                Features2DToolbox.VoteForUniqueness(matches, uniquenessthreshold, mask);
                int count = Features2DToolbox.VoteForSizeAndOrientation(templateKeyPoints, sceneKeyPoints, matches, mask, 1.5, 20);
                if (count >= 4)
                {
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(templateKeyPoints, sceneKeyPoints, matches, mask, 5);
                    Rectangle rect = new Rectangle(Point.Empty, template.Size);
                    PointF[] pts = new PointF[]
                    {
                        new PointF(rect.Left, rect.Bottom),
                        new PointF(rect.Right, rect.Bottom),
                        new PointF(rect.Right, rect.Top),
                        new PointF(rect.Left, rect.Top),
                    };
                    pts = CvInvoke.PerspectiveTransform(pts, homography);
                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    finalPoints = new VectorOfPoint(points);
                }


                return finalPoints;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
