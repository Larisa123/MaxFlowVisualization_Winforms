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

        public static int animationStep;
        private static int waitBetweenEachConnection = 1500;
        private static int waitBeetwenEachPath = 1000;

        public Animation(MainWindow mainWindow) {
            this.mainWindow = mainWindow;
            state = AnimationState.NotAnimating;
        }

        public static void Restart() {
            
        }

        public static void NewPath(int[] path) {
            previousNode = Node.S;
            currentIndex = 0;
            currentPath = path;
        }

        public void PerformStep() {
            if (previousNode == currentNode)
                return;

            if (currentIndex == currentPath.Length) {
                state = AnimationState.InBetweenPaths; // this path has already ended
                return;
            }


            currentNode = currentPath[currentIndex]; 

            Drawing.DrawLine(previousNode, currentNode, flowLine: true);
            Connection.ChangeShownCapacity(previousNode, currentNode, currentResidualGraph[currentNode, previousNode]);

            // show progress on the progress bar:
            mainWindow.UpdateProgression(animationStep);

            Task.Delay(waitBetweenEachConnection).Wait(); // we wait for 1.5 seconds

            previousNode = currentNode; // so we proceed with the flow
            currentIndex++;
        }

    }
}
