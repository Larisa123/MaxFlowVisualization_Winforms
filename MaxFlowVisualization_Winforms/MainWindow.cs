using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxFlowVisualization_Winforms {
    public partial class MainWindow : Form {
        private AppState appState;
        private MessageText message;

        // Algorithm:
        private MaxFlow maxFlow;
        // Connection detection - draging detection:
        private Drag drag;

        private Drawing drawing;

        // properties getters, setters:
        internal Drawing Drawing { get => drawing; set => drawing = value; }
        internal Drag Drag { get => drag; set => drag = value; }
        internal MaxFlow MaxFlow { get => maxFlow; set => maxFlow = value; }

        public MainWindow() {
            InitializeComponent();
            initializeOnStart();
        }

        /// <summary>
        /// Initializes properties when constructor gets called, sets Drawing, LabelNodes, Drag, MaxFlow instances.
        /// </summary>
        private void initializeOnStart() {
            appState = AppState.Initialized;
            message = new MessageText();

            // drawing:
            Drawing = new Drawing(mainWindow: this, drAreaComp: DrawingAreaComponent);

            // algorithm (also label nodes and connections, capacities):
            MaxFlow = new MaxFlow(mainWindow: this);

            // Connections:
            Drag = new Drag();
            Drag.IsActive = false;
        }
                            

        /// <summary>
        /// Shows a fixed example of a network.
        /// </summary>
        private void showExample() {

        }
        /// <summary>
        /// Solves the current example (either fixed or drawn), gets called after button click.
        /// </summary>
        private void solveCurrentExample() {

        }

        private void updateMessage() { labelMainMessage.Text = message.getAppropriateMessage(appState); }
        private void enableSolveButton(bool shouldEnable) { buttonSolve.Enabled = shouldEnable; }

        private void enableEndDrawingButton(bool shouldEnable) {
            //TODO: Should only get enabled when the drawn graph is actually a network!
            buttonSolve.Enabled = shouldEnable;
        }

        /// <summary>
        /// Responds to button clicks etc. depending on the state the app is at.
        /// </summary>
        private void processUserInput() {
            switch (appState) {
                case AppState.Initialized:
                    //TODO
                    break;
                case AppState.ShowExample:
                    showExample();
                    enableSolveButton(true);
                    break;
                case AppState.Solve:
                    enableSolveButton(false); // user should be able to invoke this method only once
                    solveCurrentExample();
                    break;
                case AppState.Draw:
                    enableSolveButton(false);
                    showEntryBox();
                    //TODO in the method: change the message to say
                    break;
                case AppState.EndDrawing:
                    enableSolveButton(true);
                    break;
                case AppState.Drawing:
                    drawing.AddAppropriateNetworkComponent();
                    enableSolveButton(false);
                    break;
                case AppState.ClearDrawingArea:
                    enableSolveButton(false);
                    Drawing.ClearDrawingArea();
                    break;
                default:
                    enableSolveButton(false);
                    break;
            }
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
            MaxFlow.InitializeGraph(entryValue);
            MaxFlow.LabelNodes.InitializeLabelArray(entryValue);
            appState = AppState.Drawing;
        }  

        ///                                          USER INPUT:

        private void buttonClicked() {
            updateMessage();
            processUserInput();
        }
        private void buttonDraw_Click(object sender, EventArgs e){
            appState = AppState.Draw;
            buttonClicked();
        }
        private void buttonShowExample_Click(object sender, EventArgs e) {
            appState = AppState.ShowExample;
            buttonClicked();
        }
        private void buttonClearDrawingArea_Click(object sender, EventArgs e) {
            appState = AppState.ClearDrawingArea;
            buttonClicked();
        }
        private void buttonEndDrawing_Click(object sender, EventArgs e) {
            appState = AppState.EndDrawing;
            buttonClicked();
        }
        private void buttonSolve_Click(object sender, EventArgs e) {
            appState = AppState.Solve;
            buttonClicked();
        }

        public void labelNode_MouseDown(object sender, MouseEventArgs e) {
            drag.StartNodeLabel = (Label)sender; // since label is calling this, this shouldnt be able to throw an error
            drag.StartLocation = this.PointToClient(drawing.RelativeLocationInDrAreaOf(Cursor.Position));
            drag.IsActive = true;
        }
            
        public void labelNode_MouseUp(object sender, MouseEventArgs e) {
            if (drag.IsActive) {
                drag.EndLocation = this.PointToClient(drawing.RelativeLocationInDrAreaOf(Cursor.Position));
                if (drag.EndedInNode(nodeLabels: maxFlow.LabelNodes.array))
                    drawing.ShouldDraw = ShouldDraw.Connection;
                    processUserInput();
            }
            drag.IsActive = false;
        }

        private void DrawingAreaComponent_MouseDown(object sender, MouseEventArgs e) {
            Drawing.PositionInArea = e.Location;
            drawing.ShouldDraw = ShouldDraw.Node;
            processUserInput();
        }
    }


    enum AppState {
        Initialized, ShowExample, Solve, Draw, Drawing, EndDrawing, ClearDrawingArea
    }
}
