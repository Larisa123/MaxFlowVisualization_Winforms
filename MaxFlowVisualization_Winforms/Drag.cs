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
#pragma warning disable CS0649 // Field 'Drag.EndNodeLabel' is never assigned to, and will always have its default value null
        private Label EndNodeLabel;
#pragma warning restore CS0649 // Field 'Drag.EndNodeLabel' is never assigned to, and will always have its default value null

        public bool IsActive { get; set; }

        public bool EndedInNode(Label[] nodeLabels) {
            // TODO: should set EndNodeLabel if true
            //EndNodeLabel = nodeLabels.Last().label; // TODO: JUST FOR NOW! SHOULD RETRURN THE PROPER LABEL
            return true;
        }

        public Label GetEndNodeLabel() { return EndNodeLabel; }
    }
}
