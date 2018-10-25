using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormComponents {

    public delegate void HoldButtonTrigger();
    public delegate void HoldButtonReportProgress(double progress);

    public class HoldButton : Button {
        Timer vm_timer = new Timer();
        double vm_holdtime = 0;
        bool vm_buttonCurrentlyPressed = false;
        DateTime vm_startTime;

        public event HoldButtonTrigger vm_trigger;
        public event HoldButtonReportProgress vm_reportProgress;

        public HoldButton(double holdtime) {
            // Set UI properties
            vm_holdtime = holdtime;

            // Setup press and hold functionality
            MouseDown += HoldButton_MouseDown;
            MouseUp += HoldButton_MouseUp;

            vm_timer.Interval = 100;
            vm_timer.Tick += Timer_Tick;
        }

        private void HoldButton_MouseUp(object sender, MouseEventArgs e) {
            vm_buttonCurrentlyPressed = false;
            vm_timer.Stop();
        }

        private void HoldButton_MouseDown(object sender, MouseEventArgs e) {
            vm_buttonCurrentlyPressed = true;
            vm_startTime = DateTime.Now;
            vm_timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e) {
            if (!vm_buttonCurrentlyPressed) {
                return;
            }
            TimeSpan diff = DateTime.Now - vm_startTime;
            double progress = diff.TotalMilliseconds / vm_holdtime;
            if (1 <= progress) {
                vm_timer.Stop();
                vm_trigger?.Invoke();
            } else {
                vm_reportProgress?.Invoke(progress);
            }
        }
    }
}
