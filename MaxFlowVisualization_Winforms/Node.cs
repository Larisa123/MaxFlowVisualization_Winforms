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
    class Node {
        private MainWindow mainWindow;

        public static int NumberOnScreen { get; set; }
        public static int MaxNumber { get; set; }
        public static Label[] array;
        public static int S; // in node
        public static int T;// out node

        private static Label labelS;
        private static Label labelT;

        public Node(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            NumberOnScreen = 0;
        }

        public void InitializeLabelArray(int dimension) {
            MaxNumber = dimension;
            array = new Label[MaxNumber];
        }

        public void ResetAllProperties() {
            NumberOnScreen = 0;
            MaxNumber = 0;
            if (array != null) {
                this.removeLabelNodes();
                removeInOutNodes();
            }
            InitializeLabelArray(0); // empty array of labels
        }

        public void AddLabelNodeInArray(Label label) {
            array[NumberOnScreen] = label;
            NumberOnScreen++;
        }

        public void AddNewNodeLabel() {
            if (NumberOnScreen >= MaxNumber)
                return;
            // gets executed only when the number of nodes of screen is smaller than the max number of nodes

            // Add label:
            Label newLabel = new Label {
                Location = Drawing.GetRelativeLocationOfLastClick(),
                Name = "label_" + NumberOnScreen.ToString(),
                Tag = NumberOnScreen.ToString(),
                Size = new Size(Drawing.CircleRadius, Drawing.CircleRadius), // as big as the circle, we will be draging it later
                ForeColor = Drawing.PenColor,
                Font = new Font("Source Sans Pro Light", 11),
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
            Drawing.DrawCircleAroundLastClick();
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
                labelS = signLabel;

                MainWindow.AppState = AppState.SetT;
            }
            if (node == "t") {
                T = int.Parse(label.Tag.ToString());
                signLabel.Location = Drawing.PointSum(label.Location, new Point(Drawing.CircleRadius * 2, 0));
                labelT = signLabel;

                MainWindow.AppState = AppState.PreparedForSolving;
            }

            mainWindow.Controls.Add(signLabel);
            signLabel.BringToFront();
        }

        /// <summary>
        /// Removes nodes from the drawing area. Also releases them from memory.
        /// </summary>
        private void removeLabelNodes() {
            // TODO: add this reference to viri in seminarska: https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-add-to-or-remove-from-a-collection-of-controls-at-run-time

            foreach (Label labelNode in array) {
                if (mainWindow.Controls.Contains(labelNode)) {
                    // We have to manually remove event handlers:
                    labelNode.MouseDown -= new MouseEventHandler(mainWindow.labelNode_MouseDown);
                    labelNode.MouseUp -= new MouseEventHandler(mainWindow.labelNode_MouseUp);

                    mainWindow.Controls.Remove(labelNode); // removes the label from its control
                    labelNode.Dispose(); // lets go of the reference preventing memory release
                }
            }
        }

        /// <summary>
        /// Removes in out nodes from the drawing area (S and T).
        /// </summary>
        private void removeInOutNodes() {
            if (mainWindow.Controls.Contains(labelS)) {
                mainWindow.Controls.Remove(labelS); // removes the label from its control
                labelS.Dispose(); // lets go of the reference preventing memory release
            }
            if (mainWindow.Controls.Contains(labelT)) {
                mainWindow.Controls.Remove(labelT); // removes the label from its control
                labelT.Dispose(); // lets go of the reference preventing memory release
            }
        }
    }
}
