﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MaxFlowVisualization_Winforms
{
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
            try  {
                Console.WriteLine(textBox.Text);
                int capacity = int.Parse(textBox.Text);
                if (capacity < 0) {
                    mainWindow.SetMessage("Kapaciteta more biti numerična!"); //TODO: add to messagetext
                }
                else { SetCapacity(capacity, fromTextBox: textBox); }
            }
            catch{
                mainWindow.SetMessage("Kapaciteta mora biti pozitivna!");
            }
        }

        public void SetCapacity(int nodeA, TextBox fromTextBox) {
            // TODO: use spliting to get out start and end indexes of nodes
            //graph[nodeA, nodeB] = capacity;
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
