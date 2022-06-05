using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WFA040622_G3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        SoundPlayer play;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnKur_Click(object sender, EventArgs e)
        {
            timer1.Start();
            btnKur.Enabled = false;
            lblMesaj.Text = "Alarm Kuruldu!";

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime simdikiZaman = DateTime.Now;
            DateTime alarmSaati = dateTimePicker1.Value;

            if (simdikiZaman.Hour == alarmSaati.Hour && simdikiZaman.Minute == alarmSaati.Minute && simdikiZaman.Second == alarmSaati.Second)
            {
                timer1.Stop();
                lblMesaj.Text = "Alarm Çalıyor...";
                Stream alarm = Properties.Resources.alarm;
                play = new SoundPlayer(alarm);
                play.PlayLooping();

            }

        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnDurdur.Enabled = false;
            lblMesaj.Text = "Alarm Durduruldu!";
            btnKur.Enabled = true;
            play.Stop();

        }
    }
}
