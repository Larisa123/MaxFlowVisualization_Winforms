
// Code from: http://www.geeksforgeeks.org/ford-fulkerson-algorithm-for-maximum-flow-problem/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;



namespace MaxFlowVisualization_Winforms
{
    enum ShouldAdd { Nothing, Node, Connection, Capacity }


    class MaxFlow {
        private MainWindow mainWindow;

        private int s; // in node
        private int t;// out node
        private int n; // matrix dimension
        private int[,] graph; // storing capacities on connections between nodes

        private ShouldAdd shouldAdd;
        // Nodes:
        private LabelNodes labelNodes;
        // Connections: 

        // getter, setter:
        internal LabelNodes LabelNodes { get => labelNodes; set => labelNodes = value; }
        internal ShouldAdd ShouldAdd { get => shouldAdd; set => shouldAdd = value; }

        /// <summary>
        /// Initializes some properties - label nodes etc.
        /// </summary>
        public MaxFlow(MainWindow mainWindow) {
            mainWindow = this.mainWindow;
            LabelNodes = new LabelNodes(mainWindow: mainWindow);
            this.ShouldAdd = ShouldAdd.Nothing;

            ResetGraph();
        }

        public void AddAppropriateNetworkComponent() {
            switch (this.ShouldAdd) {
                case ShouldAdd.Node:
                    LabelNodes.addNewNodeLabel();
                    break;
                case ShouldAdd.Connection:
                    addConnection(); // TODO: add this method to Connection class when you create it
                    break;
                case ShouldAdd.Capacity:
                    addCapacity(); // TODO: add this method to Connection class when you create it
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Resets all properties associated with computing max flow - graph's dimension, number of current vertices etc.
        /// </summary>
        public void ResetGraph() {
            labelNodes.ResetAllProperties();
            this.ResetAllProperties();
        }

        /// <summary>
        /// Solves the max flow problem and returns the f value.
        /// </summary>
        /// <returns></returns>
        public int GetMaxFlow() {
            // TODO: should only get called once the graph is a valid network and s and t are set
            try { return fordFulkerson(); } catch { return -1; } // if something goes wrong TODO: check which errors 
        }

        private void addCapacity() {
            // TODO: add this method to Connection class when you create it
            // add location to screen:
            int capacityPositionYMargin = 0; //TODO: add as property to Connection class
            int middleX = (mainWindow.Drag.StartLocation.X + mainWindow.Drag.EndLocation.X) / 2;
            int middleY = (mainWindow.Drag.StartLocation.Y + mainWindow.Drag.EndLocation.Y) / 2;
            Point location = mainWindow.Drawing.RelativeLocation(new Point(middleX, middleY + capacityPositionYMargin));

            // TODO: add appropriate name: connection_nodeIndex1_nodeIndex2, add to graph matrix
            TextBox capacityText = new TextBox();
            capacityText.Location = location;
            capacityText.Text = "0";
            capacityText.MaximumSize = new Size(20, 20);
            mainWindow.Controls.Add(capacityText);
            capacityText.BringToFront();

            // subscribe label to mouse events (for connections):
            capacityText.TextChanged += new EventHandler(mainWindow.capacity_TextChanged);
        }
        private void addConnection() {
            // TODO: add this method to Connection class when you create it
            //Console.WriteLine(mainWindow.);

            Point startPoint = mainWindow.Drag.StartLocation;
            Point endPoint = mainWindow.Drag.EndLocation;
            mainWindow.Drawing.DrawLine(startPoint, endPoint);
            ShouldAdd = ShouldAdd.Capacity;
            AddAppropriateNetworkComponent();
        }

        public void ChangeCapacity(TextBox textBox) {
            try {
                int capacity = int.Parse(textBox.Text);
                if (capacity < 0) {
                    mainWindow.SetMessage("Capacity should be numeric!");
                }
                else { SetCapacity(capacity, fromTextBox: textBox); }
            }
            catch {
                mainWindow.SetMessage("Capacity should be positive!");
            }
        }

        public void SetCapacity(int nodeA, TextBox fromTextBox) {
            // TODO: use spliting to get out start and end indexes of nodes
            //graph[nodeA, nodeB] = capacity;
        }

        public void InitializeGraph(int dimension) {
            this.n = dimension;
            this.graph = new int[this.n, this.n];
        }

        public void ResetAllProperties() {
            this.s = 0;
            this.t = 0;
            this.n = 0;
        }

        public void SetS(int index) { this.s = s; }
        public void SetT(int index) { this.t = t; }

        //                                       ALGORITM CODE:

        private bool isThereAPathFromSToT (int[,] residualGraph, int[] parent)
        {
            /* Returns true if there is a path from source 's' to sink 't' in residual graph. 
             * Also fills parent[] to store the path */
            // Create a visited array and mark all vertices as not visited

            bool[] visited = new bool[n];
            for (int i = 0; i < n; ++i)
                visited[i] = false;

            // Create a queue, enqueue source vertex and mark
            // source vertex as visited
            LinkedList<int> vertexes = new LinkedList<int>();
            vertexes.AddLast(s);
            visited[s] = true;
            parent[s] = -1;

            // Standard BFS Loop
            while (vertexes.Count != 0)
            {
                //int u = int.Parse(vertexes.Last.ToString());
                int u = vertexes.Last.Value;
                vertexes.RemoveLast();

                for (int v = 0; v < n; v++)
                {
                    if (visited[v] == false && residualGraph[u, v] > 0)
                    {
                        vertexes.AddLast(v);
                        parent[v] = u;
                        visited[v] = true;
                    }
                }
            }

            // If we reached sink in BFS starting from source, then
            // return true, else false
            return (visited[t] == true);
        }

        // Returns tne maximum flow from s to t in the given graph
        int fordFulkerson()
        {
            int u, v;

            // Create a residual graph and fill the residual graph
            // with given capacities in the original graph as
            // residual capacities in residual graph

            // Residual graph where rGraph[i][j] indicates
            // residual capacity of edge from i to j (if there
            // is an edge. If rGraph[i][j] is 0, then there is
            // not)
            int[,] residualGraph = new int[n, n]; // pridruzene kapacitete!

            for (u = 0; u < n; u++)
                for (v = 0; v < n; v++)
                    residualGraph[u, v] = graph[u, v];

            // This array is filled by BFS and to store path
            int[] parent = new int[n];

            int max_flow = 0;  // There is no flow initially

            // Augment the flow while tere is path from source
            // to sink
            while (isThereAPathFromSToT(residualGraph, parent))
            {
                // Find minimum residual capacity of the edhes
                // along the path filled by BFS. Or we can say
                // find the maximum flow through the path found.
                int path_flow = int.MaxValue;
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, residualGraph[u, v]);
                }

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = t; v != s; v = parent[v])
                {
                    u = parent[v];
                    residualGraph[u, v] -= path_flow;
                    residualGraph[v, u] += path_flow;
                }

                // Add path flow to overall flow
                max_flow += path_flow;
            }

            // Return the overall flow
            return max_flow;
        }
    }
}
