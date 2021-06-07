using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace Velociraptor.ImageProc
{
    class FindScribe
    {
        int _img_height = 3036, _img_width = 4024;//影像寬與高
        List<List<Point>> Hor_Line = new List<List<Point>>();
        List<List<Point>> Ver_Line = new List<List<Point>>();
        List<List<Point>> centerpoint_list = new List<List<Point>>();
        List<Point> _target_points = new List<Point>();
        Point NearestIntersectPointToCenter;
        public double AngleAverage { get; private set; }
        public double WidthAverage { get; private set; }
        public double HeightAverage { get; private set; }
        public int[] MoveToCenterXYinPixel { get; private set; }
        public double ratio = 0.15;
        public double Ratio { get { return ratio; } set { } }
        public int minHeight { get { return (int)(_img_height * ratio); } }
        public int maxHeight { get { return (int)(_img_height * (1 - ratio)); } }
        public int minWidth { get { return (int)(_img_width * ratio); } }
        public int maxWidth { get { return (int)(_img_width * (1 - ratio)); } }

        public void FineTune(Bitmap bitmap, int threshold, double[] die_size)
        {

        }
        public void FindAngle(Bitmap bitmap, int threshold, double[]die_size)
        {
            _img_height = bitmap.Height;
            _img_width = bitmap.Width;
            FastPixel _fast_pixel = new FastPixel(); //宣告快速繪圖物件
            _fast_pixel.image = bitmap;
            _fast_pixel.Bmp2RGB(bitmap); //讀取RGB亮度陣列
            _fast_pixel.array_Gray = _fast_pixel.array_Green;//灰階陣列為綠光陣列
            WidthAverage = die_size[0];
            HeightAverage = die_size[1];

            byte[,] array_Outline = GetScribeLine(_fast_pixel, threshold);
            if (Targets(array_Outline, _fast_pixel.image_width, _fast_pixel.image_height, die_size) == false)
            {
                threshold = 4;
                array_Outline = GetScribeLine(_fast_pixel, threshold);
                for (int i = 0; i < 4; i++)
                {
                    array_Outline = GetScribeLine(_fast_pixel, threshold + 2 * i);
                    if (Targets(array_Outline, _fast_pixel.image_width, _fast_pixel.image_height, die_size) == true)
                    {
                        return;
                    }
                }

            }
        }

        private double TwoPointFindDistance(Point FirstP, Point SecondP)
        {
            int x = Math.Abs(SecondP.X - FirstP.X);
            int y = Math.Abs(SecondP.Y - FirstP.Y);
            return Math.Sqrt(x * x + y * y);
        }

        public Bitmap DoThreshold(Bitmap bitmap, int threshold)
        {
            _img_height = bitmap.Height;
            _img_width = bitmap.Width;
            FastPixel _fast_pixel = new FastPixel(); //宣告快速繪圖物件
            _fast_pixel.image = bitmap;
            _fast_pixel.Bmp2RGB(bitmap); //讀取RGB亮度陣列
            _fast_pixel.array_Gray = _fast_pixel.array_Green;//灰階陣列為綠光陣列

            byte[,] array_Outline = GetScribeLine(_fast_pixel, threshold);
            return _fast_pixel.BWImg(array_Outline);
        }
        //建立切割道陣列
        private byte[,] GetScribeLine(FastPixel f, int offset)
        {
            byte[,] b = f.array_Green;
            byte[,] Q = new byte[f.image_width, f.image_height];
            for (int i = 1; i < f.image_width - 1; i++)
            {
                for (int j = 1; j < f.image_height - 1; j++)
                {
                    if ((-offset < b[i - 1, j] - b[i, j] && b[i - 1, j] - b[i, j] < offset) &&
                        (-offset < b[i + 1, j] - b[i, j] && b[i + 1, j] - b[i, j] < offset) &&
                        (-offset < b[i, j - 1] - b[i, j] && b[i, j - 1] - b[i, j] < offset) &&
                        (-offset < b[i, j + 1] - b[i, j] && b[i, j + 1] - b[i, j] < offset) &&
                        (-offset < b[i - 1, j - 1] - b[i, j] && b[i - 1, j - 1] - b[i, j] < offset) &&
                        (-offset < b[i - 1, j + 1] - b[i, j] && b[i - 1, j + 1] - b[i, j] < offset) &&
                        (-offset < b[i + 1, j - 1] - b[i, j] && b[i + 1, j - 1] - b[i, j] < offset) &&
                        (-offset < b[i + 1, j + 1] - b[i, j] && b[i + 1, j + 1] - b[i, j] < offset))
                    {
                        Q[i, j] = 1;
                    }
                }
            }
            return Q;
        }
        private bool Targets(byte[,] array_Outline, int nx, int ny, double[] die_size)
        {
            ArrayList D = new ArrayList();
            ArrayList C = getTargets(array_Outline, nx, ny); //建立目標物件集合
            //過濾長寬不夠之物件
            for (int k = 0; k < C.Count; k++)
            {
                TgInfo T = (TgInfo)C[k];
                if (T.height > maxHeight && T.width > maxWidth) D.Add(T);
                if (T.height > maxHeight && T.width < minWidth) D.Add(T);
                if (T.height < minHeight && T.width > maxWidth) D.Add(T);
            }
            C = D;
            //依長寬排序
            for (int i = 0; i < 10; i++)
            {
                for (int j = i + 1; j < C.Count; j++)
                {
                    TgInfo T = (TgInfo)C[i], G = (TgInfo)C[j];
                    if (T.width + T.height < G.width + G.height)
                    {
                        C[i] = G; C[j] = T;
                    }
                }
            }
            if (C.Count == 0)
            {
                return false;
                throw new AvvaException("找不到切割道交點");
            }
            Filter(C, nx, ny, die_size);
            return true;
        }
        private ArrayList getTargets(byte[,] q, int nx, int ny)
        {
            ArrayList A = new ArrayList();
            byte[,] b = (byte[,])q.Clone();//建立輪廓點陣列副本
            for (int i = 1; i < nx - 1; i++)
            {
                for (int j = 1; j < ny - 1; j++)
                {
                    if (b[i, j] == 0) continue;
                    TgInfo G = new TgInfo();
                    G.xmn = i; G.xmx = i; G.ymn = j; G.ymx = j; G.P = new List<Point>();
                    ArrayList nc = new ArrayList();//每一輪搜尋的起點集合
                    nc.Add(new Point(i, j));//輸入之搜尋起點
                    G.P.Add(new Point(i, j));
                    b[i, j] = 0;//清除此起點之輪廓點標記
                    do
                    {
                        ArrayList nb = (ArrayList)nc.Clone();//複製此輪之搜尋起點集合
                        nc = new ArrayList();// 清除準備蒐集下一輪搜尋起點之集合
                        for (int m = 0; m < nb.Count; m++)
                        {
                            Point p = (Point)nb[m];//搜尋起點
                            //在此點周邊3X3區域內找輪廓點
                            for (int ii = p.X - 1; ii <= p.X + 1; ii++)
                            {
                                for (int jj = p.Y - 1; jj <= p.Y + 1; jj++)
                                {
                                    //if (ii - 1 >= 0 && jj - 1 >= 0 &&ii+1<=f.ny&&jj+1<=f.nx) continue;
                                    //if (b[ii, jj] == 1 && b[ii - 1, jj] == 1 && b[ii + 1, jj] == 1 && b[ii, jj - 1] == 1 && b[ii, jj + 1] == 1&& b[i - 1, j-1] == 1&& b[i - 1, j+1] == 1&& b[i + 1, j-1] == 1&& b[i + 1, j+1] == 1) continue;//非輪廓點忽略
                                    if (b[ii, jj] == 0) continue;//非輪廓點忽略
                                    Point k = new Point(ii, jj);//建立點物件
                                    nc.Add(k);//本輪搜尋新增的輪廓點
                                    G.P.Add(k);
                                    G.np += 1;//點數累計
                                    if (ii < G.xmn) G.xmn = ii;
                                    if (ii > G.xmx) G.xmx = ii;
                                    if (jj < G.ymn) G.ymn = jj;
                                    if (jj > G.ymx) G.ymx = jj;
                                    b[ii, jj] = 0;//清除輪廓點點標記
                                }
                            }
                        }
                    } while (nc.Count > 0);//此輪搜尋有新發現輪廓點時繼續搜尋
                    //if (Z[i - 1, j] == 1) continue;//排除白色區塊的負目標，起點左邊是黑點
                    G.width = G.xmx - G.xmn + 1;//寬度計算
                    G.height = G.ymx - G.ymn + 1;//高度計算
                    A.Add(G);//加入有效目標集合
                }
            }
            return A; //回傳目標物件集合
        }
        private void Filter(ArrayList C, int nx, int ny, double[] die_size)
        {
            int top_x_add_all = 0;
            int left_y_add_all = 0;
            int right_y_add_all = 0;
            int down_x_add_all = 0;
            int counter = 0;
            List<float> angle_List = new List<float>();
            TgInfo _target = (TgInfo)C[0];
            _target.left_point_list = new List<Point>();
            _target.right_point_list = new List<Point>();
            _target.top_point_list = new List<Point>();
            _target.down_point_list = new List<Point>();
            _target.left_centerpoint_list = new List<Point>();
            _target.right_centerpoint_list = new List<Point>();
            _target.top_centerpoint_list = new List<Point>();
            _target.down_centerpoint_list = new List<Point>();
            Ver_Line.Clear();
            Hor_Line.Clear();
            //輪廓點內補滿 
            byte[,] Tbin = Fill(_target.P, nx, ny);
            #region 找出左右上下點集合
            for (int m = 0; m < _target.P.Count; m++)
            {
                Point p = (Point)_target.P[m];
                if (p.X == 1 || p.X == 2)
                {
                    _target.left_point_list.Add(p);
                }
                if (p.X == _img_width - 1 || p.X == _img_width - 2)
                {
                    _target.right_point_list.Add(p);
                }
                if (p.Y == 1 || p.Y == 2)
                {
                    _target.top_point_list.Add(p);
                }
                if (p.Y == _img_height - 1 || p.Y == _img_height - 2)
                {
                    _target.down_point_list.Add(p);
                }
            }
            _target.left_point_list = _target.left_point_list.OrderBy(p => p.Y).ToList();
            _target.right_point_list = _target.right_point_list.OrderBy(p => p.Y).ToList();
            _target.top_point_list = _target.top_point_list.OrderBy(p => p.X).ToList();
            _target.down_point_list = _target.down_point_list.OrderBy(p => p.X).ToList();
            #endregion
            #region 左右上下 center point list
            #region 左 center point list
            for (int l = 1; l < _target.left_point_list.Count; l++)
            {
                if (l == 1)
                {
                    left_y_add_all = _target.left_point_list[0].Y;
                    counter = 1;
                }
                if ((_target.left_point_list[l].Y - _target.left_point_list[l - 1].Y) < 9)
                {
                    left_y_add_all = left_y_add_all + _target.left_point_list[l].Y;
                    counter = counter + 1;
                }
                else
                {
                    left_y_add_all = left_y_add_all / counter;
                    _target.left_centerpoint_list.Add(new Point(_target.xmn, left_y_add_all));
                    left_y_add_all = _target.left_point_list[l].Y;
                    counter = 1;
                }
                if (l == _target.left_point_list.Count - 1)
                {
                    left_y_add_all = left_y_add_all / counter;
                    _target.left_centerpoint_list.Add(new Point(_target.xmn, left_y_add_all));
                    left_y_add_all = 0;
                    counter = 0;
                }
            }
            #endregion
            #region 右 center point list
            for (int l = 1; l < _target.right_point_list.Count; l++)
            {
                if (l == 1)
                {
                    right_y_add_all = _target.right_point_list[0].Y;
                    counter = 1;
                }
                if ((_target.right_point_list[l].Y - _target.right_point_list[l - 1].Y) < 9)
                {
                    right_y_add_all = right_y_add_all + _target.right_point_list[l].Y;
                    counter = counter + 1;
                }
                else
                {
                    right_y_add_all = right_y_add_all / counter;

                    _target.right_centerpoint_list.Add(new Point(_target.xmx, right_y_add_all));
                    right_y_add_all = _target.right_point_list[l].Y;
                    counter = 1;
                }
                if (l == _target.right_point_list.Count - 1)
                {
                    right_y_add_all = right_y_add_all / counter;
                    _target.right_centerpoint_list.Add(new Point(_target.xmx, right_y_add_all));
                    right_y_add_all = 0;
                    counter = 0;
                }
            }
            #endregion
            #region 上 center point list
            for (int l = 1; l < _target.top_point_list.Count; l++)
            {
                if (l == 1)
                {
                    top_x_add_all = _target.top_point_list[0].X;
                    counter = 1;
                }
                if ((_target.top_point_list[l].X - _target.top_point_list[l - 1].X) < 9)
                {
                    top_x_add_all = top_x_add_all + _target.top_point_list[l].X;
                    counter = counter + 1;
                }
                else
                {
                    top_x_add_all = top_x_add_all / counter;
                    _target.top_centerpoint_list.Add(new Point(top_x_add_all, _target.ymn));
                    top_x_add_all = _target.top_point_list[l].X;
                    counter = 1;
                }
                if (l == _target.top_point_list.Count - 1)
                {
                    top_x_add_all = top_x_add_all / counter;
                    _target.top_centerpoint_list.Add(new Point(top_x_add_all, _target.ymn));
                    top_x_add_all = 0;
                    counter = 0;
                }
            }
            #endregion
            #region 下 center point list
            for (int l = 1; l < _target.down_point_list.Count; l++)
            {
                if (l == 1)
                {
                    down_x_add_all = _target.down_point_list[0].X;
                    counter = 1;
                }
                if ((_target.down_point_list[l].X - _target.down_point_list[l - 1].X) < 9)
                {
                    down_x_add_all = down_x_add_all + _target.down_point_list[l].X;
                    counter = counter + 1;
                }
                else
                {

                    down_x_add_all = down_x_add_all / counter;
                    _target.down_centerpoint_list.Add(new Point(down_x_add_all, _target.ymx));
                    down_x_add_all = _target.down_point_list[l].X;
                    counter = 1;
                }
                if (l == _target.down_point_list.Count - 1)
                {
                    down_x_add_all = down_x_add_all / counter;
                    _target.down_centerpoint_list.Add(new Point(down_x_add_all, _target.ymx));
                    down_x_add_all = 0;
                    counter = 0;
                }
            }
            #endregion
            #endregion
            #region 刪除重複點
            for (int i = _target.left_centerpoint_list.Count - 1; i > 0; i--)
            {
                if (_target.left_centerpoint_list[i].Y == _target.left_centerpoint_list[i - 1].Y)
                    _target.left_centerpoint_list.Remove(_target.left_centerpoint_list[i]);
            }
            for (int i = _target.right_centerpoint_list.Count - 1; i > 0; i--)
            {
                if (_target.right_centerpoint_list[i].Y == _target.right_centerpoint_list[i - 1].Y)
                    _target.right_centerpoint_list.Remove(_target.right_centerpoint_list[i]);
            }
            for (int i = _target.top_centerpoint_list.Count - 1; i > 0; i--)
            {
                if (_target.top_centerpoint_list[i].X == _target.top_centerpoint_list[i - 1].X)
                    _target.top_centerpoint_list.Remove(_target.top_centerpoint_list[i]);
            }
            for (int i = _target.down_centerpoint_list.Count - 1; i > 0; i--)
            {
                if (_target.down_centerpoint_list[i].X == _target.down_centerpoint_list[i - 1].X)
                    _target.down_centerpoint_list.Remove(_target.down_centerpoint_list[i]);
            }
            #endregion
            #region 找水平與垂直線
            //找水平線
            for (int w = 0; w < _target.left_centerpoint_list.Count; w++)
            {
                for (int s = 0; s < _target.right_centerpoint_list.Count; s++)
                {
                    List<Point> Point_Set = new List<Point>();
                    int error_point = 0;
                    for (int r = _target.xmn; r < _target.xmx + 1; r++)
                    {
                        Point p_H = new Point();
                        p_H = Point.Round(GetHorizontalLineY(_target.left_centerpoint_list[w], _target.right_centerpoint_list[s], r));
                        if (Tbin[r, p_H.Y] != 1)
                        {
                            //PointInLine = false;
                            //break; 
                            error_point = error_point + 1;
                        }
                    }
                    if (error_point < minWidth)
                    {
                        Point_Set.Add(_target.left_centerpoint_list[w]);
                        Point_Set.Add(_target.right_centerpoint_list[s]);
                        Hor_Line.Add(Point_Set);
                    }
                }
            }
            // 找垂直線
            for (int w = 0; w < _target.top_centerpoint_list.Count; w++)
            {
                for (int s = 0; s < _target.down_centerpoint_list.Count; s++)
                {
                    List<Point> Point_Set = new List<Point>();
                    int error_point = 0;
                    for (int r = _target.ymn; r < _target.ymx + 1; r++)
                    {
                        Point p_H = new Point();
                        p_H = Point.Round(GetVerticalLineX(_target.top_centerpoint_list[w], _target.down_centerpoint_list[s], r));
                        if (Tbin[p_H.X, r] != 1)
                        {
                            //PointInLine = false;
                            //break;
                            error_point = error_point + 1;
                        }
                    }
                    if (error_point < minHeight)
                    {
                        Point_Set.Add(_target.top_centerpoint_list[w]);
                        Point_Set.Add(_target.down_centerpoint_list[s]);
                        Ver_Line.Add(Point_Set);
                    }
                }
            }
            #endregion
            if (Hor_Line.Count == 0 && Ver_Line.Count == 0)
                throw new AvvaException("影像中沒有切割道或交點");

            //只找到垂直切割道
            if (Ver_Line.Count != 0 && Hor_Line.Count == 0)
            {
                for (int i = 0; i < Ver_Line.Count; i++)
                    angle_List.Add(Angle(Ver_Line[i][0], Ver_Line[i][1], new Point(Ver_Line[i][0].X, Ver_Line[i][0].Y + 1)));
            }
            //只找到水平切割道
            else if (Ver_Line.Count == 0 && Hor_Line.Count != 0)
            {
                for (int i = 0; i < Hor_Line.Count; i++)
                {
                    angle_List.Add(Angle(Hor_Line[i][0], Hor_Line[i][1], new Point(Hor_Line[i][0].X + 1, Hor_Line[i][0].Y)));
                }
            }
            //找直線交點
            else
            {
                List<List<Point>> intersect_list = new List<List<Point>>();
                for (int h = 0; h < Hor_Line.Count; h++)
                {
                    List<Point> intersect_row = new List<Point>();
                    for (int s = 0; s < Ver_Line.Count; s++)
                    {
                        Point centerpoint = Point.Round(GetIntersection(Hor_Line[h][0], Hor_Line[h][1], Ver_Line[s][0], Ver_Line[s][1]));
                        angle_List.Add(Angle(centerpoint, Hor_Line[h][1], new Point(centerpoint.X + 1, centerpoint.Y)));
                        intersect_row.Add(centerpoint);
                    }
                    intersect_list.Add(intersect_row);
                }
                FindDieSize(die_size, intersect_list);
                MoveToCenterXYinPixel = GetNearestIntersectPointToCenterDistance(intersect_list);
            }
            AngleAverage = angle_List.Average();
            _target_points = _target.P;
            
        }
        private byte[,] Fill(List<Point> a, int nx, int ny)
        {
            byte[,] Tbin = new byte[nx, ny];//選取目標的二值化陣列
            for (int n = 0; n < a.Count; n++)
            {
                Point p = (Point)a[n];
                Tbin[p.X, p.Y] = 1;//起點
                Tbin[p.X + 1, p.Y] = 1;
                Tbin[p.X - 1, p.Y] = 1;
                Tbin[p.X, p.Y + 1] = 1;
                Tbin[p.X, p.Y - 1] = 1;
                Tbin[p.X + 1, p.Y + 1] = 1;
                Tbin[p.X + 1, p.Y - 1] = 1;
                Tbin[p.X - 1, p.Y + 1] = 1;
                Tbin[p.X - 1, p.Y - 1] = 1;
            }
            return Tbin;
        }
        private void FindDieSize(double[] dieSize, List<List<Point>> intersects)
        {
            double width = dieSize[0];
            double height = dieSize[1];
            List<double> Width_List = new List<double>();
            List<double> Height_List = new List<double>();
            double DieSizeDifference = 0.1 * width;
            //Find Width
            for (int r = 0; r < intersects.Count; r++)
            {
                for (int c = 0; c < intersects[r].Count - 1; c++)//3條線算2個距離
                {
                    width = TwoPointFindDistance(intersects[r][c], intersects[r][c + 1]);
                    if (Math.Abs(width - dieSize[0]) < DieSizeDifference)//計算距離跟給的距離差距不大就視為正確
                        Width_List.Add(width);
                }
            }
            if (Width_List.Count > 0) WidthAverage = Width_List.Average();

            //Find Height
            DieSizeDifference = 0.1 * height;
            for (int r = 0; r < intersects.Count - 1; r++)
            {
                for (int c = 0; c < intersects[r].Count; c++)
                {
                    height = TwoPointFindDistance(intersects[r][c], intersects[r + 1][c]);
                    if (Math.Abs(height - dieSize[1]) < DieSizeDifference)//計算距離跟給的距離差距不大就視為正確
                        Height_List.Add(height);
                }
            }
            if (Height_List.Count > 0) HeightAverage = Height_List.Average();
        }
        public static PointF GetIntersection(PointF lineFirstStar, PointF lineFirstEnd, PointF lineSecondStar, PointF lineSecondEnd)
        {
            /*
             * L1，L2都存在斜率的情況：
             * 直線方程L1: ( y - y1 ) / ( y2 - y1 ) = ( x - x1 ) / ( x2 - x1 ) 
             * => y = [ ( y2 - y1 ) / ( x2 - x1 ) ]( x - x1 ) + y1
             * 令 a = ( y2 - y1 ) / ( x2 - x1 )
             * 有 y = a * x - a * x1 + y1   .........1
             * 直線方程L2: ( y - y3 ) / ( y4 - y3 ) = ( x - x3 ) / ( x4 - x3 )
             * 令 b = ( y4 - y3 ) / ( x4 - x3 )
             * 有 y = b * x - b * x3 + y3 ..........2
             * 
             * 如果 a = b，則兩直線平等，否則， 聯解方程 1,2，得:
             * x = ( a * x1 - b * x3 - y1 + y3 ) / ( a - b )
             * y = a * x - a * x1 + y1
             * 
             * L1存在斜率, L2平行Y軸的情況：
             * x = x3
             * y = a * x3 - a * x1 + y1
             * 
             * L1 平行Y軸，L2存在斜率的情況：
             * x = x1
             * y = b * x - b * x3 + y3
             * 
             * L1與L2都平行Y軸的情況：
             * 如果 x1 = x3，那麼L1與L2重合，否則平等
             * 
            */
            float a = 0, b = 0;
            int state = 0;
            if (lineFirstStar.X != lineFirstEnd.X)
            {
                a = (lineFirstEnd.Y - lineFirstStar.Y) / (lineFirstEnd.X - lineFirstStar.X);
                state |= 1;
            }
            if (lineSecondStar.X != lineSecondEnd.X)
            {
                b = (lineSecondEnd.Y - lineSecondStar.Y) / (lineSecondEnd.X - lineSecondStar.X);
                state |= 2;
            }
            switch (state)
            {
                case 0: //L1與L2都平行Y軸
                    {
                        if (lineFirstStar.X == lineSecondStar.X)
                        {
                            //throw new Exception("兩條直線互相重合，且平行於Y軸，無法計算交點。");
                            return new PointF(0, 0);
                        }
                        else
                        {
                            //throw new Exception("兩條直線互相平行，且平行於Y軸，無法計算交點。");
                            return new PointF(0, 0);
                        }
                    }
                case 1: //L1存在斜率, L2平行Y軸
                    {
                        float x = lineSecondStar.X;
                        float y = (lineFirstStar.X - x) * (-a) + lineFirstStar.Y;
                        return new PointF(x, y);
                    }
                case 2: //L1 平行Y軸，L2存在斜率
                    {
                        float x = lineFirstStar.X;
                        //網上有相似代碼的，這一處是錯誤的。你可以對比case 1 的邏輯 進行分析
                        //源code:lineSecondStar * x + lineSecondStar * lineSecondStar.X + p3.Y;
                        float y = (lineSecondStar.X - x) * (-b) + lineSecondStar.Y;
                        return new PointF(x, y);
                    }
                case 3: //L1，L2都存在斜率
                    {
                        if (a == b)
                        {
                            // throw new Exception("兩條直線平行或重合，無法計算交點。");
                            return new PointF(0, 0);
                        }
                        float x = (a * lineFirstStar.X - b * lineSecondStar.X - lineFirstStar.Y + lineSecondStar.Y) / (a - b);
                        float y = a * x - a * lineFirstStar.X + lineFirstStar.Y;
                        return new PointF(x, y);
                    }
            }
            // throw new Exception("不可能發生的情況");
            return new PointF(0, 0);
        }
        public static PointF GetHorizontalLineY(PointF Point1, PointF Point2, int x)
        {
            /*
               y=mx+b             
            */
            float m = 0, b = 0;
            m = (Point2.Y - Point1.Y) / (Point2.X - Point1.X);
            b = Point1.Y - m * Point1.X;
            if (float.IsInfinity(m))
            {
                return new PointF(0, 0);
            }
            return new PointF(x, m * x + b);
        }
        public static PointF GetVerticalLineX(PointF Point1, PointF Point2, int y)
        {
            /*
               y=mx+b             
            */
            float m = 0, b = 0;
            if (Point2.X == Point1.X)
            {
                return new PointF(Point1.X, y);
            }
            m = (Point2.Y - Point1.Y) / (Point2.X - Point1.X);
            b = Point1.Y - m * Point1.X;
            if (float.IsInfinity(m))
            {
                return new PointF(0, 0);
            }
            return new PointF((y - b) / m, y);
        }
        public static float Angle(Point cen, Point first, Point second)
        {
            float dx1, dx2, dy1, dy2;
            float angle;

            dx1 = first.X - cen.X;
            dy1 = first.Y - cen.Y;

            dx2 = second.X - cen.X;

            dy2 = second.Y - cen.Y;

            float c = (float)Math.Sqrt(dx1 * dx1 + dy1 * dy1) * (float)Math.Sqrt(dx2 * dx2 + dy2 * dy2);

            if (c == 0) return -1;

            angle = (float)((Math.Acos((dx1 * dx2 + dy1 * dy2) / c)) * (180 / Math.PI));//radian To Degree


            return (second.Y > first.Y) ? angle : -angle;
        }
        public void Draw(ref Bitmap bmp)
        {
            Console.WriteLine("FS_Draw:" + Thread.CurrentThread.ManagedThreadId.ToString());
            for (int m = 0; m < _target_points.Count; m++)
            {
                Point p = _target_points[m];
                bmp.SetPixel(p.X, p.Y, Color.Black);
            }
            // Draw a line between the points.
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < Ver_Line.Count; i++)
            {
                g.DrawLine(new Pen(Color.Red, 5), Ver_Line[i][0], Ver_Line[i][1]);
            }
            for (int i = 0; i < Hor_Line.Count; i++)
            {
                g.DrawLine(new Pen(Color.Red, 5), Hor_Line[i][0], Hor_Line[i][1]);
            }
            //找直線交點
            Point centerpoint = new Point();
            if (Ver_Line.Count > 0 && Hor_Line.Count > 0)
            {
                for (int h = 0; h < Hor_Line.Count; h++)
                {
                    for (int s = 0; s < Ver_Line.Count; s++)
                    {
                        List<Point> centerPoint_Set = new List<Point>();
                        centerpoint = Point.Round(GetIntersection(Hor_Line[h][0], Hor_Line[h][1], Ver_Line[s][0], Ver_Line[s][1]));
                        centerPoint_Set.Add(centerpoint);
                        centerPoint_Set.Add(Hor_Line[h][0]);
                        centerPoint_Set.Add(Hor_Line[h][1]);
                        centerPoint_Set.Add(Ver_Line[s][0]);
                        centerPoint_Set.Add(Ver_Line[s][1]);
                        centerpoint_list.Add(centerPoint_Set);
                    }
                }
                for (int i = 0; i < centerpoint_list.Count; i++)
                {
                    g.DrawLine(new Pen(Color.Red), centerpoint_list[i][0], new Point(centerpoint_list[i][0].X + 20, centerpoint_list[i][0].Y));
                    g.DrawLine(new Pen(Color.Red), centerpoint_list[i][0], new Point(centerpoint_list[i][0].X - 20, centerpoint_list[i][0].Y));
                    g.DrawLine(new Pen(Color.Red), centerpoint_list[i][0], new Point(centerpoint_list[i][0].X, centerpoint_list[i][0].Y + 20));
                    g.DrawLine(new Pen(Color.Red), centerpoint_list[i][0], new Point(centerpoint_list[i][0].X, centerpoint_list[i][0].Y - 20));
                }
            }
        }
        #region GetNearestIntersectPointToCenterDistance
        public int[] GetNearestIntersectPointToCenterDistance(List<List<Point>> intersect_list)
        {
            FastPixel _fast_pixel = new FastPixel(); //宣告快速繪圖物件
            int[] PointToCenterXYinPixel = { 0, 0 };
            double PointToCenterDistance = Math.Sqrt(_fast_pixel.image_width * _fast_pixel.image_width + _fast_pixel.image_height * _fast_pixel.image_height);
            Point CenterPoint = new Point(_fast_pixel.image_width / 2, _fast_pixel.image_height / 2);
            Point NearestCenterPoint = CenterPoint;
            for (int i = 0; i < intersect_list.Count; i++)
            {
                if (TwoPointFindDistance(intersect_list[i][0], CenterPoint) < PointToCenterDistance)
                {
                    PointToCenterDistance = TwoPointFindDistance(intersect_list[i][0], CenterPoint);
                    NearestCenterPoint = intersect_list[i][0];
                }
            }
            PointToCenterXYinPixel[0] = CenterPoint.X - NearestCenterPoint.X;
            PointToCenterXYinPixel[1] = CenterPoint.Y - NearestCenterPoint.Y;
            return PointToCenterXYinPixel;
        }
        #endregion
    }
}
