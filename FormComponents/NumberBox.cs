using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormComponents {
    public delegate void NumberBoxValueChanged(int oldValue, int newValue);

    public class NumberBox : TextBox {

        private int _value = 1;
        public event NumberBoxValueChanged vmValueChanged;

        public NumberBox() {

            this.KeyPress += NumberBox_KeyPress;
            this.TextChanged += NumberBox_TextChanged;
        }

        private void NumberBox_TextChanged(object sender, EventArgs e) {
            int newValue = 1;
            if (int.TryParse(Text, out newValue)) {
                int oldValue = _value;
                _value = newValue;
                vmValueChanged?.Invoke(oldValue, newValue);
            } else {
                Value = 1;
            }
        }

        private void NumberBox_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public int Value {
            get {
                return _value;
            }
            set {
                if (value < 0) {
                    return;
                }
                _value = value;
                Text = _value.ToString();
            }
        }
    }
}
