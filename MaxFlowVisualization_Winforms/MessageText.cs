using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxFlowVisualization_Winforms
{
    /// <summary>
    /// Class storing and returning messages based on app state. 
    /// </summary>
    class MessageText {
        private const string defaultText = "Dodajte svoje omrežje z klikom na gumb Nariši omrežje ali poglej dani zgled";
        private const string showExampleText = "Izbrali ste možnost za prikaz primera.";
        private const string solveText = "Prosim počakajte dokler se reševanje primera ne dokonča.";
        private const string drawGraphText = "Izbrali ste možnost za risanje novega grafa.";
        private const string endDrawingText = "Če želite, da se animacija reševanja izvede, stisnite na gumb Reši zgled.";
        private const string drawingText = "Stisnite za dodajo novega vozlišča, povlečite med vozliščema za dodajo nove povezave.";
        private const string clearText = "Pobrisali ste risalno površino.";

        public string getAppropriateMessage(AppState appState)  {
            switch (appState) {
                case AppState.Initialized:
                    return defaultText;
                case AppState.ShowExample:
                    return showExampleText;
                case AppState.Solve:
                    return solveText;
                case AppState.Draw:
                    return drawGraphText;
                case AppState.EndDrawing:
                    return endDrawingText;
                case AppState.Drawing:
                    return drawingText;
                case AppState.ClearDrawingArea:
                    return clearText;
                default:
                    return defaultText;
            }
        }
    }
}
