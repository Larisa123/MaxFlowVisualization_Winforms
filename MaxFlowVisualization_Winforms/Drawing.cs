using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace MaxFlowVisualization_Winforms
{
    class Drawing {
        private MainWindow mainWindow;

        private static Graphics area;
        public static Point AreaLoc; // drawing area location
        // mouse position in drawing area coordinates, gets set everytime user clicks on drawing area in .Drawing mode:
        public static Point PositionInArea; // position in drawing area - where the user clicked to add a node

        private static Pen circlePen;
        private static Pen connectionPen;// we need a different pen for drawing lines, because of line caps on connections
        private static float penWidth;
        private static Color backColor;

        public static Color PenColor;
        public static int CircleRadius;


        public Drawing(MainWindow mainWindow, PictureBox drAreaComp)  {
            this.mainWindow = mainWindow;

            area = drAreaComp.CreateGraphics();
            area.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            AreaLoc = drAreaComp.Location;
            backColor = drAreaComp.BackColor;
            CircleRadius = 15;
            penWidth = 2F;
            PenColor = Color.DarkBlue;
            circlePen = new Pen(PenColor, penWidth);

            connectionPen = new Pen(PenColor, penWidth);
            var bigArrow = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);
            connectionPen.CustomEndCap = bigArrow;
        }

        public static void DrawCircleAroundLastClick() {
            Point circlePos = new Point(PositionInArea.X - CircleRadius, PositionInArea.Y - CircleRadius);
            Size circleSize = new Size(CircleRadius * 2, CircleRadius * 2);
            area.DrawEllipse(circlePen, rect: new Rectangle(circlePos, circleSize));
        }

        public static void DrawLine(Point startPoint, Point endPoint) {
            // we should start and end the line a bit after the node, so we dont have the arrow pointing
            // directly in the center of the node.
            // we can do this using this equation: tan(fi) = y/x and a point on a circle with radius r is:
            // (r cos(fi), r sin(fi))

            double fi = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
            Console.WriteLine(fi);
            Point margin = new Point((int)(Drawing.CircleRadius * Math.Cos(fi)), (int)(Drawing.CircleRadius * Math.Sin(fi)));
            Console.WriteLine(margin.ToString());
            area.DrawLine(connectionPen, PointSum(startPoint, margin), PointDiff(endPoint, margin));
        }

        // TODO: change those methods so they make more sense (they do work)
        public static Point RelativeLocationInDrAreaOf(Point location) {
            return new Point(location.X - AreaLoc.X, location.Y - AreaLoc.Y);
        }
        public static Point RelativeLocation(Point location) {
            return new Point(location.X + AreaLoc.X, location.Y + AreaLoc.Y);
        }

        public static Point GetRelativeLocationCentered(Point location) {
            int x = location.X - AreaLoc.X + CircleRadius / 3;
            int y = location.Y - AreaLoc.Y + CircleRadius / 3;
            return new Point(x, y);
        }

        public static Point GetRelativeLocationOfLastClick() {
            int x = PositionInArea.X + AreaLoc.X - CircleRadius / 3;
            int y = PositionInArea.Y + AreaLoc.Y - CircleRadius / 3;
            return new Point(x, y);
        }
        public void ClearDrawingArea() {
            area.Clear(backColor);
            MainWindow.AppState = AppState.Initialized; // Go to default state
            mainWindow.Reset(); // removes nodes and connections
        }

        public static bool LocationEndedInAreaAround(Point location, Point centerOfArea) {
            Size areaSize = new Size(CircleRadius * 2, CircleRadius * 2);
            Point center = RelativeLocationInDrAreaOf(centerOfArea);
            Rectangle areaAroundCenter = new Rectangle(center, areaSize);

            return areaAroundCenter.Contains(location);
        }

        public static Point PointSum(Point A, Point B) => new Point(A.X + B.X, A.Y + B.Y);
        public static Point PointDiff(Point A, Point B) => new Point(A.X - B.X, A.Y - B.Y);
    }
}
