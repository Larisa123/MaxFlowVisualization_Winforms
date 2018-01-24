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
        public static PictureBox drArea;
        // mouse position in drawing area coordinates, gets set everytime user clicks on drawing area in .Drawing mode:
        public static Point PositionInArea; // position in drawing area - where the user clicked to add a node

        private static Pen circlePen;
        private static Pen connectionPen;// we need a different pen for drawing lines, because of line caps on connections
        private static Pen flowConnectionPen; // pen for flow animations
        private static Color flowPenColor;

        private static float penWidth;
        private static Color backColor;

        public static Color PenColor;
        public static int CircleRadius;



        public Drawing(MainWindow mainWindow, PictureBox drAreaComp)  {
            this.mainWindow = mainWindow;

            area = drAreaComp.CreateGraphics();
            area.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            drArea = drAreaComp;
            AreaLoc = drAreaComp.Location;
            backColor = drAreaComp.BackColor;

            CircleRadius = 15;
            penWidth = 2F;
            PenColor = Color.DarkBlue;
            flowPenColor = Color.OrangeRed;
            circlePen = new Pen(PenColor, penWidth);

            // line pens:
            flowConnectionPen = new Pen(flowPenColor, penWidth);
            connectionPen = new Pen(PenColor, penWidth);
            // line pen arrows:
            var bigArrow = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);
            connectionPen.CustomEndCap = bigArrow;
            flowConnectionPen.CustomEndCap = bigArrow;
        }

        public static void DrawCircleAroundLastClick() {
            Point circlePos = new Point(PositionInArea.X - CircleRadius, PositionInArea.Y - CircleRadius);
            Size circleSize = new Size(CircleRadius * 2, CircleRadius * 2);
            area.DrawEllipse(circlePen, rect: new Rectangle(circlePos, circleSize));
        }

        /// <summary>
        /// Draws a line between two locations (points). Draws a connection line with a cap between two label nodes in blue or red, 
        /// depending on whether we are showing the flow animation or removing the flow animation (going over with previous line color).
        /// </summary>
        public static void DrawLine(Point startPoint, Point endPoint, bool flowLine) {
            // we should start and end the line a bit after the node, so we dont have the arrow pointing
            // directly in the center of the node.
            // we can do this using this equation: tan(fi) = y/x and a point on a circle with radius r is:
            // (r cos(fi), r sin(fi))

            double fi = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
            Point margin = new Point((int)(Drawing.CircleRadius * Math.Cos(fi)), (int)(Drawing.CircleRadius * Math.Sin(fi)));
            var linePen = (flowLine) ? flowConnectionPen : connectionPen;

            // so we drag the line to the actual center:
            startPoint = GetRelativeLocationCentered(startPoint);
            endPoint= GetRelativeLocationCentered(endPoint);

            area.DrawLine(linePen, PointSum(startPoint, margin), PointDiff(endPoint, margin));
        }

        public static void DrawLine(int startNode, int endNode, bool flowLine) {
            Point startPoint = Node.array[startNode].Location;
            Point endPoint = Node.array[endNode].Location;

            DrawLine(startPoint, endPoint, flowLine);
        }

        public void ClearDrawingArea() {
            area.Clear(backColor);
            MainWindow.AppState = AppState.Initialized; // Go to default state
            mainWindow.Reset(); // removes nodes and connections
        }

        public static bool LocationEndedInAreaAround(Point location, Point centerOfArea) {
            Size areaSize = new Size(CircleRadius * 3, CircleRadius * 3);
            Point center = RelativeLocationInDrAreaOf(centerOfArea);
            Rectangle areaAroundCenter = new Rectangle(center, areaSize);

            return areaAroundCenter.Contains(location);
        }

        // Relative location calculations and point calculations:

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
            int x = PositionInArea.X + AreaLoc.X - CircleRadius / 3 - 2;
            int y = PositionInArea.Y + AreaLoc.Y - CircleRadius / 3 - 3;
            return new Point(x, y);
        }

        public static Point centerTheLocation(Point loc) {
            int x = loc.X + 2;
            int y = loc.Y + 2;
            return new Point(x, y);
        }

        public static Point PointSum(Point A, Point B) => new Point(A.X + B.X, A.Y + B.Y);
        public static Point PointDiff(Point A, Point B) => new Point(A.X - B.X, A.Y - B.Y);
    }
}
