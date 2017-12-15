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
        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }

        public Label StartNodeLabel { get; set; }
        private Label EndNodeLabel;

        public bool IsActive { get; set; }

        public bool EndedInNode(Label[] nodeLabels) {
            // TODO: should set EndNodeLabel if true
            //EndNodeLabel = nodeLabels.Last().label; // TODO: JUST FOR NOW! SHOULD RETRURN THE PROPER LABEL
            return true;
        }

        public Label GetEndNodeLabel() { return EndNodeLabel; }
    }
}
