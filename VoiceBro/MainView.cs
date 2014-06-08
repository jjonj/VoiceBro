using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceBro
{
    public partial class MainView : Form
    {
        private VoiceDetector detector;


        public MainView(VoiceDetector detector)
        {
            InitializeComponent();
            this.detector = detector;
        }

        private void scrollSensitivity_Scroll(object sender, EventArgs e)
        {
            txtSensitivity.Text = ((TrackBar)sender).Value.ToString();
        }

        private void txtSensitivity_TextChanged(object sender, EventArgs e)
        {
            int newVal;
            if (int.TryParse(txtSensitivity.Text, out newVal) && newVal >= 0 && newVal <= 10)
            {
                scrollSensitivity.Value = newVal;
            }
            else
            {
                txtSensitivity.Text = scrollSensitivity.Value.ToString();
            }
        }
    }
}
