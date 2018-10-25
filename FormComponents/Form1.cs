using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormComponents {
    public partial class Form1 : Form {

        Control activeField = null;

        public Form1() {
            InitializeComponent();

            virtualKeyboard1.virtual_keypress += VirtualKeypress;
            virtualNumpad1.virtual_keypress += VirtualKeypress;
        }

        private void VirtualKeypress(string key) {
            ActiveControl = activeField;
            if (key == "Backspace") {
                SendKeys.Send("{BS}");
            } else {
                SendKeys.Send(key);
            }
            SendKeys.Flush();
        }

        private void clickedTextbox(object sender, EventArgs e) {
            activeField = (Control)sender;
        }
    }
}
