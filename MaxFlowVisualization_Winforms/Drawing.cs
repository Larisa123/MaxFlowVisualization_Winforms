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

        private Graphics area;
        public Point AreaLoc; // drawing area location
        // mouse position in drawing area coordinates, gets set everytime user clicks on drawing area in .Drawing mode:
        public Point PositionInArea; // position in drawing area - where the user clicked to add a node

        private Pen circlePen;
        private Pen connectionPen;// we need a different pen for drawing lines, because of line caps on arrays
        private float penWidth;
        public Color PenColor;
        private Color backColor;
        public int CircleRadius;

        public Drawing(MainWindow mainWindow, PictureBox drAreaComp)  {
            this.mainWindow = mainWindow;

            area = drAreaComp.CreateGraphics();
            AreaLoc = drAreaComp.Location;
            this.backColor = drAreaComp.BackColor;
            CircleRadius = 15;
            penWidth = 2F;
            PenColor = Color.DarkBlue;
            circlePen = new Pen(PenColor, penWidth);
        }

        public void DrawCircleAroundLastClick() {
            Point circlePos = new Point(PositionInArea.X - CircleRadius, PositionInArea.Y - CircleRadius);
            Size circleSize = new Size(CircleRadius * 2, CircleRadius * 2);
            this.area.DrawEllipse(circlePen, rect: new Rectangle(circlePos, circleSize));
        }

        public Point GetRelativeLocationOfLastClick() {
            int x = PositionInArea.X + AreaLoc.X - CircleRadius / 3;
            int y = PositionInArea.Y + AreaLoc.Y - CircleRadius / 3;
            return new Point(x, y);
        }

        public void ClearDrawingArea() {
            mainWindow.LabelNodes.removeLabelNodes();
            this.area.Clear(backColor);
        }
    }
}
