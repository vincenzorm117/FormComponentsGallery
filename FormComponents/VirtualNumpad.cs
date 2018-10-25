using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormComponents {

    public partial class VirtualNumpad : UserControl {

        public delegate void FCEventVirtualKeyPress(String key);
        public event FCEventVirtualKeyPress virtual_keypress;

        public VirtualNumpad() {
            InitializeComponent();
        }

        private void virtualKeypress_click(object sender, EventArgs e) {
            var button = (Button)sender;
            virtual_keypress(button.Text);
        }
    }
}
