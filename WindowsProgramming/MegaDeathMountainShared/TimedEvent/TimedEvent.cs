using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDeathMountainShared
{
    class TimedEvent
    {
        Timer timer;
        int ticks = 0;

        public TimedEvent() { timer = new Timer(); }

        public void Start() => timer.Start();

        public void Stop() => timer.Stop();

        public void setDurationInSeconds(int seconds)
        {
            timer.Interval = (1000 * seconds);
        }
    }
}
