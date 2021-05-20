using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using HalconDotNet;
using Rectangle = System.Drawing.Rectangle;

namespace Velociraptor
{
    class HalconProc
    {
        private HWindowControl hWindow;
        private HTuple HvDefaultWinHandle;

        private Point startPoint;
        private Point lastMousePos;
        private bool mousePressed = false;
        public Size WinSize { set; get; }
        private int img_part_width;
        private int img_part_height;
        private HObject my_img;
        public void DoThreshold(HObject img, int th, bool isDark = true)
        {
            HObject cur_img;
            HObject region;
            HOperatorSet.MedianImage(img, out cur_img, "square", 1, "mirrored");
            if (isDark)
            {
                HOperatorSet.Threshold(cur_img, out region, 0, th);
            }
            else
            {
                HOperatorSet.Threshold(cur_img, out region, th, 255);
            }

            HTuple h_channel;
            HOperatorSet.CountChannels(cur_img, out h_channel);
            if (h_channel == 1) Gray2Rgb(cur_img, out cur_img);
            int[] water_green = { 190, 225, 148 };
            HTuple color = new HTuple(water_green);
            HOperatorSet.OverpaintRegion(cur_img, region, color, "fill");
            Display(cur_img);
            //HOperatorSet.DispObj(cur_img, HvDefaultWinHandle);
            my_img = cur_img.Clone();
            cur_img.Dispose();
            region.Dispose();
        }
        public HalconProc()
        {
            startPoint = Point.Empty;
            lastMousePos = Point.Empty;
        }
        public void SetHWindow(HWindowControl win)
        {
            hWindow = win;
            HvDefaultWinHandle = hWindow.HalconWindow;
        }
        public void ConvertImage(byte[] img, int image_width, int image_height, ref HObject cur_img)
        {
            GCHandle hobject = GCHandle.Alloc(img, GCHandleType.Pinned);
            IntPtr pobject = hobject.AddrOfPinnedObject();
            if (cur_img != null)
            {
                cur_img.Dispose();
                cur_img = null;
            }
            HOperatorSet.GenImageInterleaved(out cur_img, pobject, "bgr",
                image_width, image_height, -1, "byte",
                image_width, image_height, 0, 0, -1, 0);
            Display(cur_img);
        }
        public HObject LoadImage(string fname)
        {
            HObject h_image;
            //free last image
            //Debug.WriteLine("Load Image " + fname);
            HOperatorSet.ReadImage(out h_image, fname);
            Display(h_image);
            my_img = h_image.Clone();
            return h_image;
        }

        public void Display(HObject img)
        {
            HTuple h_width, h_height;
            HOperatorSet.GetImageSize(img, out h_width, out h_height);
            img_part_height = h_height.I;
            img_part_width = h_width.I;
            startPoint = new Point(0, 0);
            int w = WinSize.Width;
            int h = WinSize.Height;
            //先恢復原本比例
            if (hWindow != null)
            {
                hWindow.Width = w;
                hWindow.Height = h;
            }
            double img_ratio = h_height.D / h_width.D;
            double win_ratio = (double)h / w;
            if(HvDefaultWinHandle!=null) HOperatorSet.SetPart(HvDefaultWinHandle, 0, 0, h_height, h_width);
            if (win_ratio < img_ratio)
            {
                hWindow.Width = (int)(h_width.D * h / h_height.D);
            }
            else if (win_ratio > img_ratio)
            {
                hWindow.Height = (int)(h_height.D * w / h_width.D);
            }
            if (HvDefaultWinHandle != null) HOperatorSet.ClearWindow(HvDefaultWinHandle);
            if (HvDefaultWinHandle != null) HOperatorSet.DispObj(img, HvDefaultWinHandle);
        }
        public void PrepareGrayImage(HObject img, out HObject gray_img)
        {
            HOperatorSet.GenEmptyObj(out gray_img);
            if (img == null)
            {
                gray_img.Dispose();
                gray_img = null;
                return;
            }
            HTuple h_channel;
            HOperatorSet.CountChannels(img, out h_channel);
            if (h_channel == 3)
                HOperatorSet.Rgb3ToGray(img, img, img, out gray_img);
            else
                gray_img = img.Clone();
            HOperatorSet.MedianImage(gray_img, out gray_img, "square", 1, "mirrored");
        }
        public void GetImageSize(HObject img, out int[] size)
        {
            HTuple h_width, h_height;
            HOperatorSet.GetImageSize(img, out h_width, out h_height);
            size = new int[2];
            size[0] = h_width;
            size[1] = h_height;
        }

        public void SegmentLines(HObject img, TuningData param, ref List<MyLine> keeper)
        {
            HObject h_region;
            HObject h_contour;
            HOperatorSet.Threshold(img, out h_region, param.ThresholdMin(), param.ThresholdMax());
            HOperatorSet.OpeningRectangle1(h_region, out h_region, 3, 3);
            HOperatorSet.Connection(h_region, out h_region);
            int t = h_region.CountObj();
            HTuple h_width, h_height;
            HOperatorSet.GetImageSize(img, out h_width, out h_height);
            HObject h_region1;
            HOperatorSet.SelectShape(h_region, out h_region1, "width"
                                    , "and", h_width * 0.8, h_width * 1.2);
            //HOperatorSet.SelectShape(h_region, out h_region1, "width"
            //                       , "and", 500, h_width * 1.2);
            t = h_region1.CountObj();
            HOperatorSet.SelectShape(h_region, out h_region, "height"
                                    , "and", h_height * 0.8, h_height * 1.2);
            //HOperatorSet.SelectShape(h_region, out h_region, "height"
            //                        , "and", 400, h_height * 1.2);
            t = h_region.CountObj();
            HOperatorSet.ConcatObj(h_region, h_region1, out h_region);
            t = h_region.CountObj();
            HOperatorSet.ClosingCircle(h_region, out h_region, 5);
            HObject h_skeleton;
            HOperatorSet.Skeleton(h_region, out h_skeleton);
            HOperatorSet.GenContoursSkeletonXld(h_skeleton, out h_contour, 1, "generalize2");

            t = h_contour.CountObj();

            HOperatorSet.UnionCollinearContoursXld(h_contour, out h_contour
                        , param.CollinearDistance, 10, 20, param.CollinearAngle
                        , "attr_keep");
            t = h_contour.CountObj();

            HOperatorSet.SelectContoursXld(h_contour, out h_contour, "contour_length"
                , param.SelectContourMinLength, 99999, 0, 0); //最大長度無須限制
            t = h_contour.CountObj();

            int hv_Number = h_contour.CountObj();
            HObject h_selected=null;
            HTuple hv_HvRow1, hv_HvRow2, hv_HvCol1, hv_HvCol2;
            HTuple hv_Nr, hv_Nc, hv_Dist;
            for (int i = 1; i <= hv_Number; i++) //htuple start from 1
            {
                h_selected = h_contour[i];
                //Normalized vector for line fitting:
                //r*hv_Nr + c*hv_Nc - hv_Dist = 0
                HOperatorSet.FitLineContourXld(h_selected, "regression", -1, 0, 5, 2,
                    out hv_HvRow1, out hv_HvCol1, out hv_HvRow2, out hv_HvCol2, out hv_Nr,
                    out hv_Nc, out hv_Dist);

                /*For rect fit
                HTuple hv_HvRow, hv_HvCol;
                HOperatorSet.GetContourXld(h_selected, out hv_HvRow, out hv_HvCol);
                int cnt = hv_HvCol1.DArr.Length;
                double[] x = { hv_HvCol1.DArr[0], hv_HvCol2.DArr[cnt - 1] };
                double[] y = { hv_HvRow1.DArr[0], hv_HvRow2.DArr[cnt - 1] };
                */
                //double radian = Math.Atan(-hv_Nc.D / hv_Nr.D);
                double[] x = { hv_HvCol1.D, hv_HvCol2.D };
                double[] y = { hv_HvRow1.D, hv_HvRow2.D };
                
                MyLine line = new MyLine(x, y);
                if (line.Wayward != Constants.WAY_NOTHING) keeper.Add(line);
            }
            h_contour.Dispose();
            h_region.Dispose();
            h_skeleton.Dispose();
            if (h_selected != null) h_selected.Dispose();
        }
        public void FindSmallestRect(HObject img, double[] x, double[] y
                                        , ref double[] side, ref double theta)
        {
            HTuple h_col, h_row;
            HOperatorSet.TupleGenConst(x.Length+1, 0, out h_col);
            HOperatorSet.TupleGenConst(y.Length+1, 0, out h_row);
            for (int i = 0; i < x.Length; i++)
            {
                h_col[i] = new HTuple(x[i]);
                h_row[i] = new HTuple(y[i]);
            }
            h_col[x.Length] = new HTuple(x[0]);
            h_row[y.Length] = new HTuple(y[0]);
            HObject h_region;
            HTuple phi, len1, len2;
            HOperatorSet.GenRegionPolygon(out h_region, h_row, h_col);
            HOperatorSet.SmallestRectangle2(h_region, out h_row, out h_col
                                          , out phi, out len1, out len2);
            side[0] = len1.D * 2;
            side[1] = len2.D * 2;
            if (phi < Math.PI/4 && phi > -Math.PI/4)
                theta = phi;
            else
            {
                if (phi < 0) theta = phi + Math.PI / 2;
                else theta = phi - Math.PI / 2;
            }
            HOperatorSet.GenRectangle2(out h_region, h_row, h_col, phi, len1, len2);
            HObject cur_img;
            HTuple h_channel;
            HOperatorSet.CountChannels(img, out h_channel);
            if (h_channel == 1) Gray2Rgb(img, out cur_img);
            else cur_img = img.Clone();
            int[] orange = { 238, 147, 40 };
            HTuple color = new HTuple(orange);
            if (color == null) color = new HTuple(orange);
            HOperatorSet.OverpaintRegion(cur_img, h_region, color, "fill");
            Display(cur_img);
            //HOperatorSet.DispObj(cur_img, HvDefaultWinHandle);
            my_img = cur_img.Clone();
            h_region.Dispose();
            cur_img.Dispose();
        }
        public void GrayProjection(HObject img, out List<double>[] projections)
        {
            HTuple h_horProjection, h_vertProjection;
            HObject h_rectangle;
            HTuple h_width, h_height;
            HOperatorSet.GetImageSize(img, out h_width, out h_height);
            HOperatorSet.GenRectangle1(out h_rectangle, 0, 0, h_height, h_width);
            HOperatorSet.GrayProjections(h_rectangle, img, "simple", out h_horProjection,
                out h_vertProjection);
            projections = new List<double>[2];
            projections[Constants.WAY_HORIZONTAL] = h_horProjection.DArr.ToList();
            projections[Constants.WAY_VERTICAL] = h_vertProjection.DArr.ToList();
            h_rectangle.Dispose();
        }
        public void DrawGrid(HObject img, List<MyLine>hlines, List<MyLine> vlines, HTuple color=null)
        {
            if (img == null) img = my_img;
            HTuple img_width, img_height;
            HOperatorSet.GetImageSize(img, out img_width, out img_height);
            HObject h_lines;
            HOperatorSet.GenEmptyObj(out h_lines);
            HTuple hv_HvRow, hv_HvCol;
            HObject h_fitline = null;
            for (int i = 0; i < hlines.Count; i++)
            {
                double[] pointsy = { hlines[i].InferAssociateCoor(0)
                                , hlines[i].InferAssociateCoor(img_width - 1)
                                , hlines[i].InferAssociateCoor(img_width - 1)+3
                                , hlines[i].InferAssociateCoor(0)+3
                                , hlines[i].InferAssociateCoor(0)
                };
                double[] pointsx = { 0, img_width - 1, img_width - 1, 0, 0 };
                hv_HvRow = new HTuple(pointsy);
                hv_HvCol = new HTuple(pointsx);
                HOperatorSet.GenContourPolygonXld(out h_fitline, hv_HvRow, hv_HvCol);
                HOperatorSet.ConcatObj(h_lines, h_fitline, out h_lines);
            }
            for (int i = 0; i < vlines.Count; i++)
            {
                double[] pointsy = { 0, img_height - 1, img_height - 1, 0, 0 };
                double[] pointsx = {vlines[i].InferAssociateCoor(0)
                                    , vlines[i].InferAssociateCoor(img_height - 1)
                                    , vlines[i].InferAssociateCoor(img_height - 1) + 3
                                    , vlines[i].InferAssociateCoor(0) + 3
                                    , vlines[i].InferAssociateCoor(0)
                };
                hv_HvRow = new HTuple(pointsy);
                hv_HvCol = new HTuple(pointsx);
                HOperatorSet.GenContourPolygonXld(out h_fitline, hv_HvRow, hv_HvCol);
                HOperatorSet.ConcatObj(h_lines, h_fitline, out h_lines);
            }

            HObject h_region;
            HOperatorSet.GenRegionContourXld(h_lines, out h_region, "filled");
            //畫上擬矩
            HTuple h_channel;
            HOperatorSet.CountChannels(img, out h_channel);
            HObject cur_img;
            if (h_channel == 1) Gray2Rgb(img, out cur_img);
            else cur_img = img.Clone();
            int[] orange = { 238, 147, 40 };
            int[] red = { 255, 0, 0 };
            if (color==null) color = new HTuple(orange);
            HOperatorSet.OverpaintRegion(cur_img, h_region, color, "fill");
            //如果找到角點，標出中心點位置
            if (hlines.Count >= 1 && vlines.Count >= 1)
            {
                HObject h_cross;
                //double t1 = hlines[(hlines.Count + 1) / 2 - 1].GetComparePropAvg();
                //double t2 = vlines[(vlines.Count + 1) / 2 - 1].GetComparePropAvg();
                //求十字長度
                double cross_len = 1200;
                if (hlines.Count > 1)
                {
                    cross_len = hlines[1].GetCompareProp(0) - hlines[0].GetCompareProp(0);
                }
                if (vlines.Count > 1)
                {
                    double temp = vlines[1].GetCompareProp(0) - vlines[0].GetCompareProp(0);
                    if (temp < cross_len) cross_len = temp;
                }
                cross_len /= 10;
                HOperatorSet.GenCrossContourXld(out h_cross
                    , hlines[(hlines.Count + 1) / 2 - 1].GetComparePropAvg()
                    , vlines[(vlines.Count + 1) / 2 - 1].GetComparePropAvg(), cross_len, 0);
                HOperatorSet.GenRegionContourXld(h_cross, out h_region, "margin");
                HOperatorSet.DilationCircle(h_region, out h_region, 5);
                color = new HTuple(red);
                HOperatorSet.OverpaintRegion(cur_img, h_region, color, "fill");
                h_cross.Dispose();
            }            
            Display(cur_img);
            //HOperatorSet.DispObj(cur_img, HvDefaultWinHandle);
            my_img = cur_img.Clone();
            h_region.Dispose();
            h_lines.Dispose();
            cur_img.Dispose();
            if (h_fitline != null) h_fitline.Dispose();
        }
        //****************************************************
        //Mouse Operations
        public void MouseDownHandle(object sender, HMouseEventArgs e)
        {
            mousePressed = true;
            lastMousePos = new Point((int)e.X, (int)e.Y);
        }
        public void MouseMoveHandle(object sender, HMouseEventArgs e)
        {
            if (!mousePressed) return;
            //Debug.WriteLine("-------------------------------");
            //Debug.WriteLine("Mouse:" + e.X.ToString(".##") + "," + e.Y.ToString(".##"));

            int x1 = lastMousePos.X - (int)e.X;
            int y1 = lastMousePos.Y - (int)e.Y;
            HTuple cur_width, cur_height;
            HOperatorSet.GetImageSize(my_img, out cur_width, out cur_height);
            int to_x = startPoint.X + x1;
            int to_y = startPoint.Y + y1;
            img_part_width = cur_width - to_x;
            img_part_height = cur_width - to_y;
            if (to_x > cur_width.I - 10)
            {
                to_x = cur_width.I - 10;
                img_part_width = 10;
            } 
            else if (to_x < 0)
            {
                to_x = 0;
                img_part_width = cur_width.I;
            }
            if (to_y > cur_height.I - 10)
            {
                to_x = cur_height.I - 10;
                img_part_height = 10;
            }
            else if (to_y < 0)
            {
                to_y = 0;
                img_part_height = cur_height.I;
            }
            Rectangle rect = hWindow.ImagePart;
            rect.X = to_x;
            rect.Y = to_y;
            hWindow.ImagePart = rect;

            //hWindow.ImagePart = new Rectangle(to_x, to_y, img_part_width, img_part_height);
            //HOperatorSet.SetPart(HvDefaultWinHandle, to_y, to_x, img_part_height, img_part_width);
            HOperatorSet.ClearWindow(HvDefaultWinHandle);            
            HOperatorSet.DispObj(my_img, HvDefaultWinHandle);

            lastMousePos = new Point((int)e.X, (int)e.Y);
            startPoint = new Point((int)to_x, (int)to_y);
            /*
            double y1 = startPoint.Y + (lastMousePos.X - e.X);
            double x1 = startPoint.X + (lastMousePos.Y - e.Y);
            if (x1 <= 0 && y1 <= 0) return;
            HTuple img_width, img_height;
            HOperatorSet.GetImageSize(my_img, out cur_width, out cur_height);
            if (x1 >= cur_width && y1 >= cur_height) return;
            if (x1 < 0) x1 = 0;
            if (y1 < 0) y1 = 0;
            double x2 = x1 + hWindow.Size.Width;
            double y2 = y1 + hWindow.Size.Height;
            Debug.WriteLine("part:" + x1.ToString(".##") + "," + y1.ToString(".##") 
                            + " : " + x2.ToString(".##") + "," + y2.ToString(".##"));
            Debug.WriteLine("startpoint:" + startPoint.X.ToString(".##") 
                            + "," + startPoint.Y.ToString(".##"));
            HOperatorSet.ClearWindow(HvDefaultWinHandle);
            HOperatorSet.SetPart(HvDefaultWinHandle, x1, y1, x2, y2);
            HOperatorSet.DispObj(my_img, HvDefaultWinHandle);

            lastMousePos = new Point((int)e.X, (int)e.Y);
            startPoint = new Point((int)x1, (int)y1);
            */
        }
        public void MouseUpHandle(object sender, HMouseEventArgs e)
        {
            mousePressed = false;
        }
        public void MouseLeaveHandle(object sender, EventArgs e)
        {
            mousePressed = false;
        }

        public void MouseWheelHandle(object sender, HMouseEventArgs e)
        {
            if (e.Delta == 0) return;
            //Get the position of the mouse on the target before zooming
            //Point targetZoomFocus1 = e.GetPosition(this.hWindowControl1);

            //scale factor is between 0.001 ~ 10
            if (e.Delta > 0)
            {
                img_part_height = (int)(img_part_height * 0.8);
                img_part_width = (int)(img_part_width * 0.8);
            }
            else
            {
                img_part_height = (int)(img_part_height * 1.2);
                img_part_width = (int)(img_part_width * 1.2);
            }
            Rectangle rect = hWindow.ImagePart;
            rect.Width = img_part_width;
            rect.Height = img_part_height;
            hWindow.ImagePart = rect;

            HOperatorSet.ClearWindow(HvDefaultWinHandle);
            HOperatorSet.DispObj(my_img, HvDefaultWinHandle);

            /*
            if (e.Delta == 0) return;
            //Get the position of the mouse on the target before zooming
            //Point targetZoomFocus1 = e.GetPosition(this.hWindowControl1);

            //scale factor is between 0.001 ~ 10
            if (e.Delta < 0)
            {
                if (targetScaleValue <= 0.201) return; 
                targetScaleValue = targetScaleValue - 0.2;
            } else
            {
                if (targetScaleValue >= 9.8) return;
                targetScaleValue = targetScaleValue + 0.2;
            }
            HObject disp_img;
            HOperatorSet.ZoomImageFactor(my_img, out disp_img
                                , targetScaleValue, targetScaleValue, "constant");
            HOperatorSet.ClearWindow(HvDefaultWinHandle);
            HOperatorSet.DispObj(disp_img, HvDefaultWinHandle);
            startPoint = Point.Empty;
            */
        }
        public void Gray2Rgb(HObject src, out HObject img)
        {
            HTuple width, height, ptr, type;
            HOperatorSet.GetImagePointer1(src, out ptr, out type, out width, out height);
            HOperatorSet.GenImage3(out img, type, width, height, ptr, ptr, ptr);
        }
    }
}
