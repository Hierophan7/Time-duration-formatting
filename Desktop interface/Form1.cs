using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeDBContext;
using Calculations;

namespace Desktop_interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int formatDuration;
        private TimeContext db = new TimeContext();

        protected override void OnLoad(EventArgs e)
        {
            var times = db.Times.ToList().Reverse<Time>().Take(5).Reverse();
            dbOutput.Text = "";
            foreach (Time unit in times)
            {
                dbOutput.Text += unit.Output + "\r\n";
            }
        }
        private void computeButton_Click(object sender, EventArgs e)
        {
            formatDuration = 0;
            if (int.TryParse(inputData.Text, out formatDuration)) {
                outputCurrent.Text = TimeCalculations.Calculations(formatDuration);
                db.Times.Add(new Time() { Output = outputCurrent.Text });
                db.SaveChanges();
                OnLoad(e);
            } else {
                outputCurrent.Text = "The number is too large or wrong input data.";
            }
            inputData.Clear();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
