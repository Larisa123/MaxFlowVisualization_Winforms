using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFlowVisualization_Winforms
{
    public enum AnimationState { NotAnimating,InBetweenPaths, AnimatingPath, End };

    public class Animation {
        private MainWindow mainWindow;

        public static AnimationState state;

        private static int currentIndex;
        public static int previousNode;
        public static int currentNode;

        public static int[] currentPath;
        public static int[,] currentResidualGraph;

        public static int Step;
        public static int WaitBetweenEachConnection = 1500;

        public Animation(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            state = AnimationState.NotAnimating;
        }

        public static void Restart() {
            
        }

        public static void NewPath(int[] path, int[,] residualGraph) {
            previousNode = Node.S;
            currentIndex = 0;
            currentPath = path;
            currentResidualGraph = residualGraph;

            state = AnimationState.AnimatingPath;
        }

        public void PerformStep() {
            if (currentIndex == currentPath.Length) {
                state = AnimationState.InBetweenPaths; // this path has already ended
                return;
            }

            
            if (state == AnimationState.InBetweenPaths) {
                // then we just wait
                state = AnimationState.AnimatingPath;
                return;
            }

            currentNode = currentPath[currentIndex]; // prestavimo se na naslednje vozlišče:
            currentIndex++;

            if (previousNode == currentNode) { // ciklov ne rišemo, gremo na naslednjo vozlišče
                PerformStep();
                return;
            }

            Drawing.DrawLine(previousNode, currentNode, flowLine: true);
            Connection.ChangeShownCapacity(previousNode, currentNode, currentResidualGraph[currentNode, previousNode]);

            // show progress on the progress bar:
            mainWindow.UpdateProgression(Step);

            previousNode = currentNode; // so we proceed with the flow
        }

    }
}
