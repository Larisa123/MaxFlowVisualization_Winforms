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
        private const string preparedForSolving = "Če želite, da se animacija reševanja izvede, stisnite na gumb Reši problem.";
        private const string endDrawing = "Izberite začetno vozlišče z klikom nanj.";
        private const string drawing = "Stisnite za dodajo novega vozlišča, povlečite med vozliščema za povezavo.";
        private const string setS = "Prosim izberite začetno vozlišče z klikom nanj.";
        private const string setT = "Prosim izberite končno vozlišče z klikom nanj.";
        private const string clear = "Pobrisali ste risalno površino.";

        public static string UnvalidGraph = "Preko narisanega omrežja ne moremo prepeljati nobene enote.";

        public static string[] algorithmExplanations = new string[] {
            "Začnemo z začetnim ničelnim pretokom.",
            "Pretok povečujemo, dokler lahko, pri čemer upoštevamo omejitve povezav.",
            "Maksimalni pretok danega omrežja je: "
        };

        public string GetAppropriateMessage(AppState appState)  {
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
                case AppState.SetS:
                    return setS;
                case AppState.SetT:
                    return setT;
                case AppState.PreparedForSolving:
                    return preparedForSolving;
                default:
                    return "";
            }
        }
    }
}