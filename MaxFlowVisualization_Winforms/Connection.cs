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
    /// Class for storing, adding, changing and deleting connections and capacities of the maxflow algorithm.
    /// </summary>
    class Connection {
        private MainWindow mainWindow;
        private MaxFlow maxFlow;

        private static TextBox[,] capacityMatrix; // we store them so we can delete them later

        public Connection(MainWindow mainWindow, MaxFlow maxFlow) {
            this.mainWindow = mainWindow;
            this.maxFlow = maxFlow;
        }

        /// <summary>
        /// Resets the list storing the capacity text boxes.
        /// </summary>
        public void ResetAllProperties() {
            if (capacityMatrix != null)
                this.removeConnections();
        }

        public void initializeCapacityMatrix(int n) {
            capacityMatrix = new TextBox[n, n];
        }

        public void AddConnection() {
            Point startPoint = Drag.StartLocation;
            Point endPoint = Drag.EndLocation;

            // We cant have cycles, we shouldnt add a connection between two nodes that are the same
            if (Drag.EndNodeLabel.Name == Drag.StartNodeLabel.Name)
                return;

            Drawing.DrawLine(startPoint, endPoint, flowLine: false);
            addCapacity();
        }

        /// <summary>
        /// Changes the capacity stored in the MaxFlow matrix, called when the user changes the textbox's text.
        /// </summary>
        public void ChangeCapacity(TextBox textBox) {
            if (textBox.Text.Length == 0) // when we change the text to empty, we shouldnt read this
                return;

            // names are constructed: connection_nodeA_nodeB
            try {
                int capacity = int.Parse(textBox.Text); // if not an int, an execption will be thrown
                if (capacity < 0) {
                    mainWindow.SetMessage("Capacity should be positive!"); //TODO: add to messagetext
                } else { // we can set it!
                    string[] splittedText = textBox.Name.ToString().Split('_');
                    int nodeA = int.Parse(splittedText[1]);
                    int nodeB = int.Parse(splittedText[2]);

                    MaxFlow.Graph[nodeA, nodeB] = capacity;
                }
            } catch {
                mainWindow.SetMessage("Capacity should be numeric!");
            }
        }

        /// <summary>
        /// Changes capacity text, so we see how algorithm is working.
        /// </summary>
        public static void ChangeCapacity(int i, int j, int value) {
            TextBox textBox = capacityMatrix[i, j];
            if (textBox != null)
                textBox.Text =  String.Format("{0}/{1}", value, MaxFlow.Graph[i, j]);
        }

        private void addCapacity() {
            // where to add:
            int middleX = (Drag.StartLocation.X + Drag.EndLocation.X) / 2;
            int middleY = (Drag.StartLocation.Y + Drag.EndLocation.Y) / 2;
            Point location = Drawing.GetRelativeLocationCentered(Drawing.RelativeLocation(new Point(middleX, middleY)));

            // the actual text box:
            TextBox capacityText = new TextBox {
                Location = location,
                Name = "connection_" + Drag.StartNodeLabel.Tag + "_" + Drag.EndNodeLabel.Tag,// name is connection_nodeIndex1_nodeIndex2
                Text = "0", // initial value
                MaximumSize = new Size(20, 17),
                BackColor = Drawing.drArea.BackColor,
                Font = new Font("Source Sans Pro Light", 11),
                BorderStyle = BorderStyle.None
            };

            // add to form:
            mainWindow.Controls.Add(capacityText);
            capacityText.BringToFront();

            // subscribe text box to value changed event:
            capacityText.TextChanged += new EventHandler(mainWindow.capacity_TextChanged);

            // store capacities (actually text boxes, values are stored in maxflow's graph)
            int nodeA = int.Parse(Drag.StartNodeLabel.Tag.ToString());
            int nodeB = int.Parse(Drag.EndNodeLabel.Tag.ToString());
            capacityMatrix[nodeA, nodeB] = capacityText;

            MaxFlow.ShouldAdd = ShouldAdd.Nothing;
        }

        public void DeactivateTextBoxes() {
            foreach (TextBox textBox in capacityMatrix) {
                if (textBox != null)
                    textBox.ReadOnly = true;
            }
        }

        /// <summary>
        /// Removes capacity text boxes from drawing area (actually from the form's control)
        /// </summary>
        private void removeConnections() {
            foreach (TextBox capacityBox in capacityMatrix) {
                if (mainWindow.Controls.Contains(capacityBox)) {
                    // We have to manually remove event handlers:
                    capacityBox.TextChanged -= new EventHandler(mainWindow.capacity_TextChanged);

                    mainWindow.Controls.Remove(capacityBox); // removes the label from its control
                    capacityBox.Dispose(); // lets go of the reference preventing memory release
                }
            }
        }
    }
}
