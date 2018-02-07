using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace MaxFlowVisualization_Winforms {
    public partial class MainWindow : Form {
        private static AppState appState;
        private MessageText message;

        private MaxFlow maxFlow; // Algorithm

        private Drawing drawing;

        // properties getters, setters:
        internal Drawing Drawing { get => drawing; set => drawing = value; }
        internal MaxFlow MaxFlow { get => maxFlow; set => maxFlow = value; }
        internal static AppState AppState { get => appState; set => appState = value; }

        public MainWindow() {
            InitializeComponent();

            initializeOnStart();
        }

        /// <summary>
        /// Initializes properties when constructor gets called, sets Drawing, LabelNodes, Drag, MaxFlow instances.
        /// </summary>
        private void initializeOnStart() {
            message = new MessageText();

            // algorithm (also label nodes and connections, capacities):
            maxFlow = new MaxFlow(mainWindow: this);

            // drawing:
            Drawing = new Drawing(mainWindow: this, drAreaComp: DrawingAreaComponent);

            Reset(); // sets initial values
        }

        public void Reset() {
            AppState = AppState.Initialized;
            Drag.IsActive = false;
            maxFlow.ResetGraph(); // resets all properties related to the algorithm (graph - nodes, connections, drawing)
        }


        /// <summary>
        /// Shows a fixed example of a network.
        /// </summary>
        private void showExample() {
            Point[] fixedNodeLocs = new Point[] {
                new Point(70, 190),
                new Point(150, 130),
                new Point(150, 270),
                new Point(270, 110),
                new Point(270, 270),
                new Point(370, 190),
            };
            int[][] connections = new int[][] {
                new int[] {0, 1, 3},
                new int[] {0, 2, 3},
                new int[] {1, 2, 2},
                new int[] {1, 3, 3},
                new int[] {3, 4, 4},
                new int[] {2, 4, 2},
                new int[] {3, 5, 2},
                new int[] {4, 5, 3},
            };

            // initialize and set MaxFlow properties (arrays etc):
            MaxFlow.InitializeGraph(fixedNodeLocs.Length);

            // add nodes and connections:
            foreach (Point nodeLoc in fixedNodeLocs) 
                MaxFlow.Node.AddNewNodeLabel(nodeLoc, fixedExample: true);
            
            foreach (int[] connection in connections) {
                int nodeA = connection[0];
                int nodeB = connection[1];
                int capacity = connection[2];

                MaxFlow.Connection.AddConnection(startPoint: fixedNodeLocs[nodeA], endPoint: fixedNodeLocs[nodeB]);
                MaxFlow.Connection.AddCapacity(startPoint: fixedNodeLocs[nodeA],
                                               endPoint: fixedNodeLocs[nodeB],
                                               capacity: capacity,
                                               startNode: nodeA,
                                               endNode: nodeB
                                               );
            }

            // set in out nodes:
            MaxFlow.Node.SetNode("s", Node.array[0]);
            MaxFlow.Node.SetNode("t", Node.array[fixedNodeLocs.Length - 1]);
        }

        private void updateMessage() { labelMainMessage.Text = message.GetAppropriateMessage(AppState); }
        public void SetMessage(string message) { labelMainMessage.Text = message; }

        /// <summary>
        /// Responds to button clicks etc. depending on the state the app is at.
        /// </summary>
        private void processUserInput() {
            updateMessage();

            switch (AppState) {
                case AppState.Initialized:
                    enableClearButton(false);
                    break;
                case AppState.ShowExample:
                    Drawing.ClearDrawingArea();
                    showExample();
                    showProgression(false);
                    enableSolveButton(true);
                    enableClearButton(true);
                    break;
                case AppState.Draw:
                    showProgression(false);
                    Drawing.ClearDrawingArea();
                    enableClearButton(false);
                    enableSolveButton(false);
                    showEntryBox();
                    MaxFlow.ShouldAdd = ShouldAdd.Node;
                    break;
                case AppState.Drawing:
                    maxFlow.AddAppropriateNetworkComponent();
                    // give the user the option to end drawing if the graph is a network:
                    enableEndDrawingButton(maxFlow.CheckIfDrawnGraphANetwork());
                    enableSolveButton(false);
                    enableClearButton(true);
                    break;
                case AppState.EndDrawing:
                    maxFlow.Connection.DeactivateTextBoxes(); // so we cant change the capacities anymore
                    maxFlow.Node.SetInOutNodes();
                    enableEndDrawingButton(false);
                    return;
                case AppState.PreparedForSolving:
                    MaxFlow.ShouldAdd = ShouldAdd.Nothing;
                    return;
                case AppState.Solving:
                    ShowButtonsDuringAnimation(false);
                    maxFlow.ComputeSolution();
                    enableSolveButton(false);
                    break;
                case AppState.ClearDrawingArea:
                    showProgression(false);
                    Drawing.ClearDrawingArea();
                    enableSolveButton(false);
                    enableClearButton(false);
                    enableEndDrawingButton(false);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Shows progression bar, progression speed etc.
        /// </summary>
        private void showProgression(bool shouldShow) {
            AnimationProgression.Value = 0;
            AnimationProgression.Visible = shouldShow;
            labelAnimation.Visible = shouldShow;
        }

        /// <summary>
        /// Updates the value on progression bar.
        /// </summary>
        public void UpdateProgression(float value) {
            AnimationProgression.Value += (int)value;
        }

        ///                                          ENTRY FORM - asks the user for the number of nodes his network will have:

        private void showEntryBox() {
            EnterNumberOfNodesForm entryForm = new EnterNumberOfNodesForm();

            if (entryForm.ShowDialog(this) == DialogResult.OK) { // shows the form and checks if user selected OK
                entryFormEntryConfirmed(entryForm.EntryValue); 
            }
            entryForm.Dispose();
        }

        private void entryFormEntryConfirmed(int entryValue) {
            maxFlow.InitializeGraph(entryValue);
            AppState = AppState.Drawing;
        }

        /// <summary>
        /// Makes the animation buttons visible and all other buttons invisible when false is passed.
        /// </summary>
        public void ShowButtonsDuringAnimation(bool show) {
            showProgression(!show);

            buttonDraw.Visible = show;
            buttonSolve.Visible = show;
            buttonEndDrawing.Visible = show;
            buttonClearDrawingArea.Visible = show;
            buttonShowExample.Visible = show;
        }

        private void enableSolveButton(bool shouldEnable) { buttonSolve.Enabled = shouldEnable; }

        private void enableEndDrawingButton(bool shouldEnable) { buttonEndDrawing.Enabled = shouldEnable; }

        private void enableClearButton(bool shouldEnable) {
            buttonClearDrawingArea.Enabled = shouldEnable;
            buttonClearDrawingArea.Visible = shouldEnable;
        }

        ///                                          USER INPUT:

        private void buttonDraw_Click(object sender, EventArgs e){
            AppState = AppState.Draw;
            processUserInput();
        }

        private void buttonShowExample_Click(object sender, EventArgs e) {
            AppState = AppState.ShowExample;
            processUserInput();
        }

        private void buttonClearDrawingArea_Click(object sender, EventArgs e) {
            AppState = AppState.ClearDrawingArea;
            processUserInput();
        }

        private void buttonEndDrawing_Click(object sender, EventArgs e) {
            AppState = AppState.EndDrawing;
            processUserInput();
        }

        private void buttonSolve_Click(object sender, EventArgs e) {
            AppState = AppState.Solving;
            processUserInput();
        }

        public void labelNode_MouseDown(object sender, MouseEventArgs e) {
            Label clickedLabel = (Label)sender;// since label is calling this, this shouldnt be able to throw an error
            Drag.StartNodeLabel = clickedLabel;
            Drag.StartLocation = this.PointToClient(Drawing.GetRelativeLocationCentered(Cursor.Position));
            Drag.IsActive = true;

            if (AppState == AppState.EndDrawing)
                processUserInput();
            else if (AppState == AppState.SetS) {
                maxFlow.Node.SetNode(node: "s", label: clickedLabel);
            }
            else if (AppState == AppState.SetT) {
                maxFlow.Node.SetNode(node: "t", label: clickedLabel);
                enableSolveButton(true);

            }
        }

        public void labelNode_MouseUp(object sender, MouseEventArgs e) {
            if (Drag.IsActive) {
                Drag.EndLocation = this.PointToClient(Drawing.RelativeLocationInDrAreaOf(Cursor.Position));
                if (Drag.EndedInNode())
                    MaxFlow.ShouldAdd = ShouldAdd.Connection;
                    processUserInput();
            }
            Drag.IsActive = false;
        }

        public void capacity_TextChanged(object sender, EventArgs e) {
            if (appState != AppState.Drawing)
                return;

            TextBox textBox = (TextBox)sender;
            maxFlow.Connection.ChangeCapacity(textBox);
        }

        private void DrawingAreaComponent_MouseDown(object sender, MouseEventArgs e) {
            Drawing.PositionInArea = e.Location;
            MaxFlow.ShouldAdd = ShouldAdd.Node;
            processUserInput();
        }
    }


    enum AppState {
        Initialized, // default state
        ShowExample, // // gets set after the user clicks Show example button
        PreparedForSolving, // gets set after the user sets both S and T, means we can solve the problem now
        Solving, // in the process of solving the problem
        Draw, // gets set after Draw graph button click, asks the user for number of nodes in his graph
        Drawing, // in this state the user is able to add nodes and connections, gets set after the number of nodes is set
        EndDrawing, // after this button click, the user is able to set S, T and then click on Solve button (gets activated)
        SetS, // gets set after the user clicks button End drawing, after that
        SetT, // this state gets set
        ClearDrawingArea // gets set after the user clicks Clear drawing area button
    }
}
