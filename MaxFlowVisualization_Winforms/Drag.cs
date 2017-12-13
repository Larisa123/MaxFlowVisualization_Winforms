using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MaxFlowVisualization_Winforms
{
    class Drag {
        public Point StartLocation { get; set; }
        public Point EndLocation { get; set; }
        public bool IsActive { get; set; }
    }
}
