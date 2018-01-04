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

        private List<TextBox> list; // we store them so we can delete them later

        public Connection(MainWindow mainWindow, MaxFlow maxFlow) {
            this.mainWindow = mainWindow;
            this.maxFlow = maxFlow;
        }

        /// <summary>
        /// Resets the list storing the capacity text boxes.
        /// </summary>
        public void ResetAllProperties() {
            if (this.list != null)
                this.removeConnections();
            this.list = new List<TextBox>();
        }

        public void AddConnection() {
            Point startPoint = Drag.StartLocation;
            Point endPoint = Drag.EndLocation;
            Drawing.DrawLine(startPoint, endPoint);
            addCapacity();
        }

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

        private void addCapacity() {
            int middleX = (Drag.StartLocation.X + Drag.EndLocation.X) / 2;
            int middleY = (Drag.StartLocation.Y + Drag.EndLocation.Y) / 2;
            Point location = Drawing.RelativeLocation(new Point(middleX, middleY));

            TextBox capacityText = new TextBox {
                Location = location,
                Name = "connection_" + Drag.StartNodeLabel.Tag + "_" + Drag.EndNodeLabel.Tag,// connection_nodeIndex1_nodeIndex2
                Text = "0",
                MaximumSize = new Size(20, 20),
                BackColor = mainWindow.BackColor,
                BorderStyle = BorderStyle.None
            };

            this.list.Add(capacityText);

            mainWindow.Controls.Add(capacityText);
            capacityText.BringToFront();

            // subscribe label to mouse events (for connections):
            capacityText.TextChanged += new EventHandler(mainWindow.capacity_TextChanged);

            // TODO: add to graph matrix

            MaxFlow.ShouldAdd = ShouldAdd.Nothing;
        }

        /// <summary>
        /// Removes capacity text boxes from drawing area (actually from the form's control)
        /// </summary>
        private void removeConnections() {
            foreach (TextBox capacityBox in this.list) {
                if (mainWindow.Controls.Contains(capacityBox)) {
                    // We have to manually remove event handlers:
                    capacityBox.TextChanged -= new EventHandler(mainWindow.capacity_TextChanged);

                    mainWindow.Controls.Remove(capacityBox); // removes the label from its control
                    capacityBox.Dispose(); // lets go of the reference preventing memory release
                }
            }

            this.list = new List<TextBox>();
        }
    }
}
