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
    class Nodes {
        private MainWindow mainWindow;

        public static int NumberOnScreen { get; set; }
        public static int MaxNumber { get; set; }
        public Label[] array;
        public static int S; // in node
        public static int T;// out node

        public Nodes(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            NumberOnScreen = 0;
        }

        public void InitializeLabelArray(int dimension) {
            MaxNumber = dimension;
            this.array = new Label[MaxNumber];
        }

        public void ResetAllProperties() {
            NumberOnScreen = 0;
            MaxNumber = 0;
            this.RemoveLabelNodes();
        }

        public void AddLabelNodeInArray(Label label) {
            this.array[NumberOnScreen] = label;
            NumberOnScreen++;
        }

        public void AddNewNodeLabel() {
            if (NumberOnScreen >= MaxNumber)
                return;
            // gets executed only when the number of nodes of screen is smaller than the max number of nodes

            // Add label:
            Label newLabel = new Label {
                Location = mainWindow.Drawing.GetRelativeLocationOfLastClick(),
                Name = "label_" + NumberOnScreen.ToString(),
                Tag = NumberOnScreen.ToString(),
                Size = new Size(Drawing.CircleRadius, Drawing.CircleRadius), // as big as the circle, we will be draging it later
                ForeColor = Drawing.PenColor,
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

        public void SetInOutNodes() {
            MessageBox.Show(MessageText.SetSAndT);
            MainWindow.AppState = AppState.SetS;
        }
        public void SetNode(string node, Label label)  {
            Font bold = new Font(label.Font, FontStyle.Bold);
            label.Font = bold;

            Label signLabel = new Label {
                Name = node,
                Size = new Size(Drawing.CircleRadius, Drawing.CircleRadius),
                ForeColor = Drawing.PenColor,
                Text = node.ToUpper()

            };
            signLabel.Font = bold;

            if (node == "s") {
                S = int.Parse(label.Tag.ToString());
                signLabel.Location = Drawing.PointSum(label.Location, new Point(-Drawing.CircleRadius * 2, 0));

                MainWindow.AppState = AppState.SetT;
            }
            if (node == "t") {
                T = int.Parse(label.Tag.ToString());
                signLabel.Location = Drawing.PointSum(label.Location, new Point(Drawing.CircleRadius * 2, 0));

                MainWindow.AppState = AppState.PreparedForSolving;
            }

            mainWindow.Controls.Add(signLabel);
            signLabel.BringToFront();
        }

        public void RemoveLabelNodes() {
            //foreach (Label labelNode in labelNodes)
            //TODO: erase label
            InitializeLabelArray(0); // empty array of labels
        }
    }
}
