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
        private Drawing drawing;

        public int NumberOnScreen { get; set; }
        public int MaxNumber { get; set; }
        public Label[] array;

        public LabelNodes(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            this.drawing = mainWindow.Drawing;
            NumberOnScreen = 0;
        }

        public void InitializeLabelArray(int dimension) {
            this.MaxNumber = dimension;
            this.array = new Label[this.MaxNumber];
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
            Label newLabel = new Label();

            newLabel.Location = drawing.GetRelativeLocationOfLastClick();
            newLabel.Name = "label_" + NumberOnScreen.ToString();
            newLabel.Size = new Size(drawing.CircleRadius, drawing.CircleRadius); // size should be as big as the circle, since we will be draging it later
            newLabel.ForeColor = drawing.PenColor;
            newLabel.Text = NumberOnScreen.ToString();

            mainWindow.Controls.Add(newLabel);
            newLabel.BringToFront();

            // subscribe label to mouse events (for connections):
            newLabel.MouseDown += new MouseEventHandler(mainWindow.labelNode_MouseDown);
            newLabel.MouseUp += new MouseEventHandler(mainWindow.labelNode_MouseUp);


            // Add label to array:
            AddLabelNodeInArray(newLabel);

            // Draw circle around the label:
            drawing.DrawCircleAroundLastClick();
        }

        public void removeLabelNodes() {
            //foreach (Label labelNode in labelNodes)
            //TODO: erase label
            InitializeLabelArray(0); // empty array of labels
        }
    }
}
