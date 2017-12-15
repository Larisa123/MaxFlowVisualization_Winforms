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
    /// Class for creating and storing nodes.
    /// </summary>
    class LabelNodes {
        private MainWindow mainWindow;

        public int NumberOnScreen { get; set; }
        public int MaxNumber { get; set; }
        public Label[] array;

        public LabelNodes(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            NumberOnScreen = 0;
        }

        public void InitializeLabelArray(int dimension) {
            this.MaxNumber = dimension;
            this.array = new Label[this.MaxNumber];
        }

        public void ResetAllProperties() {
            this.NumberOnScreen = 0;
            this.MaxNumber = 0;
            this.removeLabelNodes();
        }

        public void AddLabelNodeInArray(Label label) {
            this.array[this.NumberOnScreen] = label;
            this.NumberOnScreen++;
        }

        public void addNewNodeLabel() {
            if (this.NumberOnScreen >= this.MaxNumber)
                return;
            // gets executed only when the number of nodes of screen is smaller than the max number of nodes

            // Add label:
            Label newLabel = new Label  {
                Location = mainWindow.Drawing.GetRelativeLocationOfLastClick(),
                Name = "label_" + NumberOnScreen.ToString(),
                Size = new Size(mainWindow.Drawing.CircleRadius, mainWindow.Drawing.CircleRadius), // as big as the circle, we will be draging it later
                ForeColor = mainWindow.Drawing.PenColor,
                Text = NumberOnScreen.ToString().ToString()
            };
            mainWindow.Controls.Add(newLabel);
            newLabel.BringToFront();

            // subscribe label to mouse events (for connections):
            newLabel.MouseDown += new MouseEventHandler(mainWindow.labelNode_MouseDown);
            newLabel.MouseUp += new MouseEventHandler(mainWindow.labelNode_MouseUp);

            // Add label to array:
            AddLabelNodeInArray(newLabel);

            // Draw circle around the label:
            mainWindow.Drawing.DrawCircleAroundLastClick();
        }

        public void removeLabelNodes() {
            //foreach (Label labelNode in labelNodes)
            //TODO: erase label
            InitializeLabelArray(0); // empty array of labels
        }
    }
}
