using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();
        }
        private void set_Load(object sender, EventArgs e)
        {
            checkBoxs.Checked = AnalogClock.showsec;
            checkBoxtop.Checked = AnalogClock.topmost;
            TopMost = AnalogClock.topmost;
            textBoxSize.Text = AnalogClock.a.ToString();
            textBoxEdge.Text = AnalogClock.edge.ToString();
        }

        private void buttonok_Click(object sender, EventArgs e)
        {
            AnalogClock.showsec = checkBoxs.Checked;
            AnalogClock.topmost = checkBoxtop.Checked;
            if (textBoxSize.Text.Trim() == AnalogClock.a.ToString() && textBoxEdge.Text == AnalogClock.edge.ToString())
            {
                return;
            }
            try
            {
                int size = Convert.ToInt32(textBoxSize.Text.Trim());
                int edge = Convert.ToInt32(textBoxEdge.Text.Trim());
                if (size > edge * 2 + 25)
                {
                    AnalogClock.a = Convert.ToInt32(textBoxSize.Text.Trim());
                    AnalogClock.edge = Convert.ToInt32(textBoxEdge.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Number is not correct!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
