using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Input;

namespace spore_autosave
{
    public partial class Form1 : Form
    {
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tick.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tick.Enabled = false;
        }

        private void tick_Tick(object sender, EventArgs e)
        {
            SendKeys.SendWait("^s");
            sw.Start();
            entrovani.Enabled = true;
        }

        private void entrovani_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{ENTER}");
            if (sw.Elapsed.Seconds > 2)
            {
                entrovani.Enabled = false;
                sw.Stop();
                sw.Reset();
            }
        }

        private void nudSavingTime_ValueChanged(object sender, EventArgs e)
        {
            tick.Interval = Convert.ToInt32(nudSavingTime.Value * 1000);
        }
        bool Edown = false;
        private void PauseResume_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.E))
            {
                Edown = true;
            }
            if ((Keyboard.IsKeyUp(Key.E) && Edown))
            {
                Edown = false;
                tick.Enabled = !tick.Enabled;

                #region pause/play music
                if (tick.Enabled)
                {
                    Console.Beep(600, 100);
                    Console.Beep(800, 100);
                    Console.Beep(900, 100);
                    Console.Beep(1000, 100);
                    Console.Beep(1200, 400);
                }
                else
                {
                    Console.Beep(900, 100);
                    Console.Beep(800, 100);
                    Console.Beep(700, 100);
                    Console.Beep(600, 100);
                    Console.Beep(400, 400);
                }
                #endregion
            }
        }
    }
}
