
// Code after the ALGORITHM CODE comment from: http://www.geeksforgeeks.org/ford-fulkerson-algorithm-for-maximum-flow-problem/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;



namespace MaxFlowVisualization_Winforms
{
    /// <summary>
    /// Enum for telling us what we should be drawing on the area component on user clicks - a node or a connection
    /// </summary>
    enum ShouldAdd { Nothing, Node, Connection }

    /// <summary>
    /// Stores everything releted to the algorithm, also stores references to the Connection and Node class.
    /// </summary>
    class MaxFlow {
        private MainWindow mainWindow;

        private static int n; // matrix dimension
        private static int[,] graph; // storing capacities on connections between nodes

        private static ShouldAdd shouldAdd;

        // Nodes, connections:
        private Node node;
        private Connection connection;

        // getter, setter:
        internal Node Nodes { get => node; set => node = value; }
        internal static ShouldAdd ShouldAdd { get => shouldAdd; set => shouldAdd = value; }
        internal Connection Connection { get => connection; set => connection = value; }
        public static int[,] Graph { get => graph; set => graph = value; }

        /// <summary>
        /// Initializes some properties - label nodes etc.
        /// </summary>
        public MaxFlow(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            node = new Node(mainWindow: this.mainWindow);
            connection = new Connection(mainWindow: this.mainWindow, maxFlow: this);
        }

        /// <summary>
        /// Calculates the solution of the max flow problem.
        /// </summary>
        public void ComputeSolution() {
            // TODO: show the user how the program is solving this: path animations

            int result = GetMaxFlow();
            mainWindow.SetMessage("Maksimalni pretok narisanega omrežja je: " + result); // temporary
        }
        /// <summary>
        /// Only for debuging: prints the graph to the console.
        /// </summary>
        public static void printGraph() {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    Console.Write(graph[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Decides whether we should add a new node or a connection and adds it by invoking appropriate methods.
        /// </summary>
        public void AddAppropriateNetworkComponent() {
            switch (ShouldAdd) {
                case ShouldAdd.Node:
                    node.AddNewNodeLabel();
                    break;
                case ShouldAdd.Connection:
                    connection.AddConnection(); // TODO: add this method to Connection class when you create it
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Resets all properties associated with computing max flow - graph's dimension, number of current vertices etc.
        /// </summary>
        public void ResetGraph() {
            ShouldAdd = ShouldAdd.Nothing;
            node.ResetAllProperties();
            connection.ResetAllProperties();
            this.ResetAllNumericProperties();
        }

        /// <summary>
        /// Solves the max flow problem and returns the f value.
        /// </summary>
        /// <returns></returns>
        public int GetMaxFlow() {
            // TODO: should only get called once the graph is a valid network and s and t are set
            try { return fordFulkerson(); } catch { return -1; } // if something goes wrong TODO: check which errors 
        }

        /// <summary>
        /// Checks and returns the boolean indicating whether the drawn graph is a network or just a graph.
        /// </summary>
        public bool CheckIfDrawnGraphANetwork() {
            //TODO: implement this method to actually check this
            return true;
        }

        public void InitializeGraph(int dimension) {
            n = dimension;
            graph = new int[n, n];
        }

        /// <summary>
        /// Resets s, t and n - graph's dimension.
        /// </summary>
        public void ResetAllNumericProperties() {
            Node.S = 0;
            Node.T = 0;
            n = 0;
        }

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
            vertexes.AddLast(Node.S);
            visited[Node.S] = true;
            parent[Node.S] = -1;

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
            return (visited[Node.T] == true);
        }

        /// <summary>
        /// Returns tne maximum flow from s to t in the given graph.
        /// </summary>
        /// <returns></returns>
        int fordFulkerson() {
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
                    residualGraph[u, v] = Graph[u, v];

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
                for (v = Node.T; v != Node.S; v = parent[v])
                {
                    u = parent[v];
                    path_flow = Math.Min(path_flow, residualGraph[u, v]);
                }

                // update residual capacities of the edges and
                // reverse edges along the path
                for (v = Node.T; v != Node.S; v = parent[v])
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
