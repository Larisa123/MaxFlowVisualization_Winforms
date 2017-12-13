using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaxFlowVisualization_Winforms
{
    public partial class EnterNumberOfNodesForm : Form {
        public int EntryValue { get; set; }
        public EnterNumberOfNodesForm() {
            EntryValue = 0;
            InitializeComponent();
        }

        private void entryNumber_ValueChanged(object sender, EventArgs e) {
            EntryValue = (int)entryNumber.Value;
        }
    }
}
