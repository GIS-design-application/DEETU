using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using DEETU.Geometry;
using DEETU.Core;
using DEETU.Tool;

namespace DEETU.Map
{
    internal static class GeoMapDrawingTools
    {
        #region 程序集方法
        internal static void DrawGeometry(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoGeometry geometry, GeoSymbol symbol)
        {
            if (extent == null)
                return;
            if (geometry == null)
                return;
            if (symbol == null)
                return;
            if (geometry.GetType() == typeof(GeoPoint))
            {
                GeoPoint sPoint = (GeoPoint)geometry;
                DrawPoint(g, extent, mapScale, dpm, mpu, sPoint, symbol);
            }
            else if (geometry.GetType() == typeof(GeoMultiPolyline))
            {
                GeoMultiPolyline sMultiPolyline = (GeoMultiPolyline)geometry;
                DrawMultiPolyline(g, extent, mapScale, dpm, mpu, sMultiPolyline, symbol);
            }
            else if (geometry.GetType() == typeof(GeoMultiPolygon))
            {
                GeoMultiPolygon sMultiPolygon = (GeoMultiPolygon)geometry;
                DrawMultiPolygon(g, extent, mapScale, dpm, mpu, sMultiPolygon, symbol);
            }
        }

        //绘制点
        internal static void DrawPoint(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoPoint point, GeoSymbol symbol)
        {
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
            {
                GeoSimpleMarkerSymbol sSymbol = (GeoSimpleMarkerSymbol)symbol;
                if (sSymbol.Visible == true)
                    DrawPointBySimpleMarker(g, extent, mapScale, dpm, mpu, point, sSymbol);
            }
        }

        //绘制线段
        internal static void DrawLine(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoPoint point1, GeoPoint point2, GeoSymbol symbol)
        {
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
            {
                GeoSimpleLineSymbol sSymbol = (GeoSimpleLineSymbol)symbol;
                if (sSymbol.Visible == true)
                    DrawLineBySimpleLine(g, extent, mapScale, dpm, mpu, point1, point2, sSymbol);
            }
        }

        //绘制点集合（多点）
        internal static void DrawPoints(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoPoints points, GeoSymbol symbol)
        {
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleMarkerSymbol)
            {
                GeoSimpleMarkerSymbol sSymbol = (GeoSimpleMarkerSymbol)symbol;
                if (sSymbol.Visible == true)
                {
                    Int32 sPointCount = points.Count;
                    for (Int32 i = 0; i <= sPointCount - 1; i++)
                    {
                        GeoPoint sPoint = points.GetItem(i);
                        DrawPointBySimpleMarker(g, extent, mapScale, dpm, mpu, sPoint, sSymbol);
                    }
                }
            }
        }

        //绘制矩形
        internal static void DrawRectangle(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoRectangle rectangle, GeoSymbol symbol)
        {
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
            {
                GeoSimpleFillSymbol sSymbol = (GeoSimpleFillSymbol)symbol;
                if (sSymbol.Visible == true)
                {
                    DrawRectangleBySimpleFill(g, extent, mapScale, dpm, mpu, rectangle, sSymbol);
                }
            }
        }

        //绘制简单折线
        internal static void DrawPolyline(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoPoints points, GeoSymbol symbol)
        {
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
            {
                GeoSimpleLineSymbol sSymbol = (GeoSimpleLineSymbol)symbol;
                if (sSymbol.Visible == true)
                {
                    DrawPolylineBySimpleLine(g, extent, mapScale, dpm, mpu, points, sSymbol);
                }
            }
        }

        //绘制简单多边形
        internal static void DrawPolygon(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoPoints points, GeoSymbol symbol)
        {
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
            {
                GeoSimpleFillSymbol sSymbol = (GeoSimpleFillSymbol)symbol;
                if (sSymbol.Visible == true)
                {
                    DrawPolygonBySimpleFill(g, extent, mapScale, dpm, mpu, points, sSymbol);
                }
            }
        }

        //绘制复合折线
        internal static void DrawMultiPolyline(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoMultiPolyline multiPolyline, GeoSymbol symbol)
        {
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
            {
                GeoSimpleLineSymbol sSymbol = (GeoSimpleLineSymbol)symbol;
                if (sSymbol.Visible == true)
                    DrawMultiPolylineBySimpleLine(g, extent, mapScale, dpm, mpu, multiPolyline, sSymbol);
            }
        }

        //绘制复合多边形
        internal static void DrawMultiPolygon(Graphics g, GeoRectangle extent, double mapScale, double dpm, double mpu, GeoMultiPolygon multiPolygon, GeoSymbol symbol)
        {
            if (symbol.SymbolType == GeoSymbolTypeConstant.SimpleFillSymbol)
            {
                GeoSimpleFillSymbol sSymbol = (GeoSimpleFillSymbol)symbol;
                if (sSymbol.Visible == true)
                    DrawMultiPolygonBySimpleFill(g, extent, mapScale, dpm, mpu, multiPolygon, sSymbol);
            }
        }

        //绘制注记
        internal static void DrawLabel(Graphics g, double dpm, PointF OriPoint, string labelText, GeoTextSymbol textSymbol)
        {
            SmoothingMode sSmoothMode = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //说明，OriPoint：绘制原点（即注记左上点）
            SolidBrush sTextBrush = new SolidBrush(textSymbol.FontColor);
            float dpi = g.DpiY;
            var maskWidth = textSymbol.MaskWidth * dpi / 72;
            var textWidth = textSymbol.Font.Size * dpi / 72;
            Pen sMaskPen = new Pen(textSymbol.MaskColor, (float)maskWidth);
            if (textSymbol.UseMask == true)
            {   //需要描边
                GraphicsPath sGraphicPath = new GraphicsPath();
                sGraphicPath.AddString(labelText, textSymbol.Font.FontFamily, (Int32)textSymbol.Font.Style, (float)textWidth, OriPoint, StringFormat.GenericDefault);
                g.DrawPath(sMaskPen, sGraphicPath);
                g.FillPath(sTextBrush, sGraphicPath);
                sGraphicPath.Dispose();
            }
            else
            {   //不需要描边
                g.DrawString(labelText, textSymbol.Font, sTextBrush, OriPoint);
            }
            sTextBrush.Dispose();
            sMaskPen.Dispose();
            g.SmoothingMode = sSmoothMode;
        }

        internal static Color[][] GetColors()
        {
            List<Color[]> sColors = new List<Color[]>();

            // 1
            sColors.Add(new List<Color> { Color.Green, Color.Red}.ToArray());
            // 2
            sColors.Add(new List<Color> { Color.Cyan, Color.Red }.ToArray());
            // 3
            sColors.Add(new List<Color> { Color.Green, Color.Snow }.ToArray());
            // 4
            sColors.Add(new List<Color> { Color.FromArgb(212, 239, 247), Color.FromArgb(0, 57, 245) }.ToArray());
            // 5
            sColors.Add(new List<Color> { Color.FromArgb(173, 255, 217), Color.FromArgb(0, 157, 21) }.ToArray());
            // 6
            sColors.Add(new List<Color> { Color.FromArgb(255, 184, 184), Color.FromArgb(200, 0, 0) }.ToArray());
            // 7
            sColors.Add(new List<Color> { Color.FromArgb(116, 78, 230), Color.FromArgb(230, 78, 78) }.ToArray());
            // 8
            sColors.Add(new List<Color> { Color.FromArgb(78, 106, 230), Color.FromArgb(78, 230, 78) }.ToArray());
            // 9
            sColors.Add(new List<Color> { Color.FromArgb(243, 247, 166), Color.FromArgb(227, 219, 0) }.ToArray());
            // 10
            sColors.Add(new List<Color> { Color.FromArgb(255, 243, 79), Color.FromArgb(255, 0, 0) }.ToArray());

            return sColors.ToArray();
        }
        #endregion

        #region 私有函数

        //采用简单点符号绘制点
        private static void DrawPointBySimpleMarker(Graphics g, GeoRectangle extent, double mapScale, double dpm,
            double mpu, GeoPoint point, GeoSimpleMarkerSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            PointF sScreenPoint = new PointF();
            sScreenPoint.X = (float)((point.X - sOffsetX) * mpu / mapScale * dpm);
            sScreenPoint.Y = (float)((sOffsetY - point.Y) * mpu / mapScale * dpm);
            //（2）计算符号大小
            float sSize = (float)(symbol.Size / 1000 * dpm);     //符号大小，像素
            if (sSize < 1)
                sSize = 1;
            //（3）定义绘制区域并绘制
            Rectangle sDrawingArea = new Rectangle((Int32)(sScreenPoint.X - sSize / 2), (Int32)(sScreenPoint.Y - sSize / 2), (Int32)sSize, (Int32)sSize);
            DrawSimpleMarker(g, sDrawingArea, dpm, symbol);
        }

        //采用简单线符号绘制线段
        private static void DrawLineBySimpleLine(Graphics g, GeoRectangle extent, double mapScale, double dpm,
            double mpu, GeoPoint point1, GeoPoint point2, GeoSimpleLineSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            PointF sScreenPoint1 = new PointF();
            PointF sScreenPoint2 = new PointF();
            sScreenPoint1.X = (float)((point1.X - sOffsetX) * mpu / mapScale * dpm);
            sScreenPoint1.Y = (float)((sOffsetY - point1.Y) * mpu / mapScale * dpm);
            sScreenPoint2.X = (float)((point2.X - sOffsetX) * mpu / mapScale * dpm);
            sScreenPoint2.Y = (float)((sOffsetY - point2.Y) * mpu / mapScale * dpm);
            //（2）绘制
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawLine(sPen, sScreenPoint1, sScreenPoint2);
            sPen.Dispose();
        }

        //采用简单线符号绘制简单折线
        private static void DrawPolylineBySimpleLine(Graphics g, GeoRectangle extent, double mapScale, double dpm,
            double mpu, GeoPoints points, GeoSimpleLineSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            GraphicsPath sGraphicPath = new GraphicsPath();     //用于屏幕绘制
            Int32 sPointCount = points.Count;  //顶点数目
            PointF[] sScreenPoints = new PointF[sPointCount];
            for (Int32 j = 0; j <= sPointCount - 1; j++)
            {
                PointF sScreenPoint = new PointF();
                GeoPoint sCurPoint = points.GetItem(j);
                sScreenPoint.X = (float)((sCurPoint.X - sOffsetX) * mpu / mapScale * dpm);
                sScreenPoint.Y = (float)((sOffsetY - sCurPoint.Y) * mpu / mapScale * dpm);
                sScreenPoints[j] = sScreenPoint;
            }
            sGraphicPath.AddLines(sScreenPoints);
            //（2）绘制
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawPath(sPen, sGraphicPath);
            sPen.Dispose();
        }

        //采用简单线符号绘制复合折线
        private static void DrawMultiPolylineBySimpleLine(Graphics g, GeoRectangle extent, double mapScale, double dpm,
            double mpu, GeoMultiPolyline multiPolyline, GeoSimpleLineSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            Int32 sPartCount = multiPolyline.Parts.Count;        //简单折线的数目
            GraphicsPath sGraphicPath = new GraphicsPath();     //定义复合多边形，用于屏幕绘制
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                Int32 sPointCount = multiPolyline.Parts.GetItem(i).Count;  //当前简单折线的顶点数目
                PointF[] sScreenPoints = new PointF[sPointCount];
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    PointF sScreenPoint = new PointF();
                    GeoPoint sCurPoint = multiPolyline.Parts.GetItem(i).GetItem(j);
                    sScreenPoint.X = (float)((sCurPoint.X - sOffsetX) * mpu / mapScale * dpm);
                    sScreenPoint.Y = (float)((sOffsetY - sCurPoint.Y) * mpu / mapScale * dpm);
                    sScreenPoints[j] = sScreenPoint;
                }
                sGraphicPath.AddLines(sScreenPoints);
                sGraphicPath.StartFigure();
            }
            //（2）绘制
            Pen sPen = new Pen(symbol.Color, (float)(symbol.Size / 1000 * dpm));
            sPen.DashStyle = (DashStyle)symbol.Style;
            g.DrawPath(sPen, sGraphicPath);
            sPen.Dispose();
        }

        //采用简单填充符号绘制矩形
        private static void DrawRectangleBySimpleFill(Graphics g, GeoRectangle extent, double mapScale, double dpm,
            double mpu, GeoRectangle rectangle, GeoSimpleFillSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标并生成矩形
            Point sTopLeftPoint = new Point(), sBottomRightPoint = new Point();
            sTopLeftPoint.X = (Int32)((rectangle.MinX - sOffsetX) * mpu / mapScale * dpm);
            sTopLeftPoint.Y = (Int32)((sOffsetY - rectangle.MaxY) * mpu / mapScale * dpm);
            sBottomRightPoint.X = (Int32)((rectangle.MaxX - sOffsetX) * mpu / mapScale * dpm);
            sBottomRightPoint.Y = (Int32)((sOffsetY - rectangle.MinY) * mpu / mapScale * dpm);
            Int32 sWidth = sBottomRightPoint.X - sTopLeftPoint.X;
            Int32 sHeight = sBottomRightPoint.Y - sTopLeftPoint.Y;
            Rectangle sRect = new Rectangle(sTopLeftPoint.X, sTopLeftPoint.Y, sWidth, sHeight);
            //（2）填充
            if (symbol.Color != Color.Transparent)
            {
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                g.FillRectangle(sBrush, sRect);
                sBrush.Dispose();
            }
            //（3）绘制边界
            if (symbol.Outline.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
            {
                GeoSimpleLineSymbol sOutline = symbol.Outline;
                if (sOutline.Visible == true)
                {
                    Pen sPen = new Pen(sOutline.Color, (float)(sOutline.Size / 1000 * dpm));
                    sPen.DashStyle = (DashStyle)sOutline.Style;
                    g.DrawRectangle(sPen, sRect);
                    sPen.Dispose();
                }
            }
        }

        //采用简单填充符号绘制简单多边形
        private static void DrawPolygonBySimpleFill(Graphics g, GeoRectangle extent, double mapScale, double dpm,
            double mpu, GeoPoints points, GeoSimpleFillSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            GraphicsPath sGraphicPath = new GraphicsPath();     //用于屏幕绘制
            Int32 sPointCount = points.Count;  //顶点数目
            PointF[] sScreenPoints = new PointF[sPointCount];
            for (Int32 j = 0; j <= sPointCount - 1; j++)
            {
                PointF sScreenPoint = new PointF();
                GeoPoint sCurPoint = points.GetItem(j);
                sScreenPoint.X = (float)((sCurPoint.X - sOffsetX) * mpu / mapScale * dpm);
                sScreenPoint.Y = (float)((sOffsetY - sCurPoint.Y) * mpu / mapScale * dpm);
                sScreenPoints[j] = sScreenPoint;
            }
            sGraphicPath.AddPolygon(sScreenPoints);
            //（2）填充
            SolidBrush sBrush = new SolidBrush(symbol.Color);
            g.FillPath(sBrush, sGraphicPath);
            sBrush.Dispose();
            //（3）绘制边界
            if (symbol.Outline.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
            {
                GeoSimpleLineSymbol sOutline = symbol.Outline;
                if (sOutline.Visible == true)
                {
                    Pen sPen = new Pen(sOutline.Color, (float)(sOutline.Size / 1000 * dpm));
                    sPen.DashStyle = (DashStyle)sOutline.Style;
                    g.DrawPath(sPen, sGraphicPath);
                    sPen.Dispose();
                }
            }
        }

        //采用简单填充符号绘制复合多边形
        private static void DrawMultiPolygonBySimpleFill(Graphics g, GeoRectangle extent, double mapScale, double dpm,
            double mpu, GeoMultiPolygon multiPolygon, GeoSimpleFillSymbol symbol)
        {
            double sOffsetX = extent.MinX, sOffsetY = extent.MaxY;  //获取投影坐标系相对屏幕坐标系的平移量
            //（1）转换为屏幕坐标
            Int32 sPartCount = multiPolygon.Parts.Count;        //简单多边形的数目
            GraphicsPath sGraphicPath = new GraphicsPath();     //定义复合多边形，用于屏幕绘制
            for (Int32 i = 0; i <= sPartCount - 1; i++)
            {
                Int32 sPointCount = multiPolygon.Parts.GetItem(i).Count;  //当前简单多边形的顶点数目
                PointF[] sScreenPoints = new PointF[sPointCount];
                for (Int32 j = 0; j <= sPointCount - 1; j++)
                {
                    PointF sScreenPoint = new PointF();
                    GeoPoint sCurPoint = multiPolygon.Parts.GetItem(i).GetItem(j);
                    sScreenPoint.X = (float)((sCurPoint.X - sOffsetX) * mpu / mapScale * dpm);
                    sScreenPoint.Y = (float)((sOffsetY - sCurPoint.Y) * mpu / mapScale * dpm);
                    sScreenPoints[j] = sScreenPoint;
                }
                sGraphicPath.AddPolygon(sScreenPoints);
            }
            //（2）填充
            SolidBrush sBrush = new SolidBrush(symbol.Color);
            g.FillPath(sBrush, sGraphicPath);
            sBrush.Dispose();
            //（3）绘制边界
            if (symbol.Outline.SymbolType == GeoSymbolTypeConstant.SimpleLineSymbol)
            {
                GeoSimpleLineSymbol sOutline = symbol.Outline;
                if (sOutline.Visible == true)
                {
                    Pen sPen = new Pen(sOutline.Color, (float)(sOutline.Size / 1000 * dpm));
                    sPen.DashStyle = (DashStyle)sOutline.Style;
                    g.DrawPath(sPen, sGraphicPath);
                    sPen.Dispose();
                }
            }
        }

        //绘制简单点符号
        // drawingArea is a square
        internal static void DrawSimpleMarker(Graphics g, Rectangle drawingArea, double dpm, GeoSimpleMarkerSymbol symbol)
        {
            if (symbol.Style == GeoSimpleMarkerSymbolStyleConstant.Circle)
            {
                Pen sPen = new Pen(symbol.Color);
                g.DrawEllipse(sPen, drawingArea);
                sPen.Dispose();
            }
            else if (symbol.Style == GeoSimpleMarkerSymbolStyleConstant.SolidCircle)
            {
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                g.FillEllipse(sBrush, drawingArea);
                sBrush.Dispose();
            }
            else if (symbol.Style == GeoSimpleMarkerSymbolStyleConstant.Triangle)
            {
                List<PointF> points = new List<PointF>();
                points.Add(new PointF(drawingArea.X, drawingArea.Y));
                points.Add(new PointF(drawingArea.X + drawingArea.Width, drawingArea.Y));
                points.Add(new PointF(drawingArea.X + drawingArea.Width / 2, drawingArea.Y - drawingArea.Height));

                Pen sPen = new Pen(symbol.Color);
                g.DrawPolygon(sPen, points.ToArray());
                sPen.Dispose();
            }
            else if (symbol.Style == GeoSimpleMarkerSymbolStyleConstant.SolidTriangle)
            {
                List<PointF> points = new List<PointF>();
                points.Add(new PointF(drawingArea.X, drawingArea.Y));
                points.Add(new PointF(drawingArea.X + drawingArea.Width, drawingArea.Y));
                points.Add(new PointF(drawingArea.X + drawingArea.Width / 2, drawingArea.Y - drawingArea.Height));

                SolidBrush sBrush = new SolidBrush(symbol.Color);
                g.FillPolygon(sBrush, points.ToArray());
                sBrush.Dispose();
            }
            else if (symbol.Style == GeoSimpleMarkerSymbolStyleConstant.Square)
            {
                Pen sPen = new Pen(symbol.Color);
                g.DrawRectangle(sPen, drawingArea);
                sPen.Dispose();
            }
            else if (symbol.Style == GeoSimpleMarkerSymbolStyleConstant.SolidSquare)
            {
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                g.FillRectangle(sBrush, drawingArea);
                sBrush.Dispose();
            }
            else if (symbol.Style == GeoSimpleMarkerSymbolStyleConstant.CircleDot)
            {
                Pen sPen = new Pen(symbol.Color);
                g.DrawEllipse(sPen, drawingArea);
                SolidBrush sBrush = new SolidBrush(symbol.Color);
                Rectangle sRect = new Rectangle((int)(drawingArea.X + 0.25 * drawingArea.Width + 1), (int)(drawingArea.Y + 0.25 * drawingArea.Height + 1), drawingArea.Width / 2, drawingArea.Height / 2);
                g.FillEllipse(sBrush, sRect);
                sPen.Dispose();
            }
            else if (symbol.Style == GeoSimpleMarkerSymbolStyleConstant.CircleCircle)
            {
                Pen sPen = new Pen(symbol.Color);
                g.DrawEllipse(sPen, drawingArea);
                Rectangle sRect = new Rectangle((int)(drawingArea.X + 0.25 * drawingArea.Width + 1), (int)(drawingArea.Y + 0.25 * drawingArea.Height + 1), drawingArea.Width / 2, drawingArea.Height / 2);
                g.DrawEllipse(sPen, sRect);
                sPen.Dispose();
            }
        }

        #endregion

    }
}
