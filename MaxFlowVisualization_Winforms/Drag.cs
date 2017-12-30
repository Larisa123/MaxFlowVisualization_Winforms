using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;



namespace MaxFlowVisualization_Winforms
{
    /// <summary>
    /// Contains informations about the drag being active, drag start and end labels.
    /// </summary>
    class Drag {
        /*
        private static Point _StartLocation;
        private static Point _EndLocation;
        public static Point StartLocation {
            get { return _StartLocation; }
            set { _StartLocation = Drawing.GetRelativeLocationCentered(value); } // centered
        }
        public static Point EndLocation {
            get { return _EndLocation; }
            set { _EndLocation = Drawing.GetRelativeLocationCentered(value); } // so we drag the line to the actual center
        }
        */

        public static Point StartLocation { get; set; }
        public static Point EndLocation { get; set; }

        public static Label StartNodeLabel { get; set; }
        public static Label EndNodeLabel { get; set; }

        public static bool IsActive { get; set; }

        public static bool EndedInNode() {            
            foreach (Label labelNode in Node.array) {
                if (Drawing.LocationEndedInAreaAround(location: EndLocation, centerOfArea: labelNode.Location)) {
                    EndNodeLabel = labelNode;
                    EndLocation = Drawing.GetRelativeLocationCentered(labelNode.Location); // so we drag the line to the actual center
                    StartLocation = Drawing.GetRelativeLocationCentered(StartNodeLabel.Location); // so we drag the line to the actual center
                    return true;
                }
            }

            return false;
        }
    }
}
