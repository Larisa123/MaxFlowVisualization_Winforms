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
        public static string fontName = "Microsoft Sans Serif";

        private const string start = "Dodajte svoje omrežje z klikom na gumb Nariši omrežje ali poglej dani zgled";
        private const string showExample = "Izbrali ste možnost za prikaz primera.";
        private const string solve = "Prosim počakajte dokler se reševanje primera ne dokonča.";
        private const string drawGraph = "Izbrali ste možnost za risanje novega grafa.";
        private const string endDrawing = "Če želite, da se animacija reševanja izvede, stisnite na gumb Reši zgled.";
        private const string drawing = "Stisnite za dodajo novega vozlišča, povlečite med vozliščema za dodajo nove povezave.";
        private const string clear = "Pobrisali ste risalno površino.";

        public static string SetSAndT = "Določite izvor in ponor z zaporednima\nklikoma na začetno in končno vozlišče.";

        public string getAppropriateMessage(AppState appState)  {
            switch (appState) {
                case AppState.Initialized:
                    return start;
                case AppState.ShowExample:
                    return showExample;
                case AppState.Solving:
                    return solve;
                case AppState.Draw:
                    return drawGraph;
                case AppState.EndDrawing:
                    return endDrawing;
                case AppState.Drawing:
                    return drawing;
                case AppState.ClearDrawingArea:
                    return clear;
                default:
                    return start;
            }
        }
    }
}
