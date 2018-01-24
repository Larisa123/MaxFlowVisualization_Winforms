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
        public static Point StartLocation { get; set; }
        public static Point EndLocation { get; set; }

        public static Label StartNodeLabel { get; set; }
        public static Label EndNodeLabel { get; set; }

        public static bool IsActive { get; set; }

        public static bool EndedInNode() {            
            foreach (Label labelNode in Node.array) {
                if (Drawing.LocationEndedInAreaAround(location: EndLocation, centerOfArea: labelNode.Location)) {
                    EndNodeLabel = labelNode;
                    EndLocation = labelNode.Location; 
                    StartLocation = StartNodeLabel.Location;
                    return true;
                }
            }
            return false; // if it didnt end in any of the nodes
        }
    }
}
