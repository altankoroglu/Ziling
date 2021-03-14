using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zilDers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.InitializeComponent();
        }

        
        DateTime basZaman = new DateTime();
        DateTime bitZaman = new DateTime();
        DateTime suAn = DateTime.Now;
        string ntDakika, ntSaniye;
        

        TimeSpan kalanSure = new TimeSpan();

        String[] zamanlar = { "08:20:00", "08:30:00", "09:00:00", "09:10:00", "09:40:00", "09:50:00", "10:20:00", "10:30:00", "11:00:00", "11:11:00", "11:40:00", "11:50:00", "12:20:00", "12:30:00", "13:00:00", "13:10:00", "13:40:00", "15:50:00", "16:20:00", "16:30:00", "17:00:00", "17:10:00", "17:40:00", "17:50:00", "18:20:00", "18:30:00", "19:00:00", "19:10:00", "19:40:00", "19:50:00", "20:20:00"};
        //dizi içinde indeksi çift numarada olanlar teneffüs; tek numarada olanlar ise dersi ifade ediyor. 
        string bugun,mesaj;

        int pan,i=0;

        protected void panKucuk()
        {
            pan = 0;
            this.Width = 50;
            label4.Left = 10;
            label6.Visible = false;
            this.Left = Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width;
            this.Top= Screen.PrimaryScreen.WorkingArea.Size.Height - this.Height;

        }

        protected void panBuyuk()
        {
            pan = 1;
            this.Width = 420;
            label4.Left = 330;
            label6.Visible = true;
            this.Left = Screen.PrimaryScreen.WorkingArea.Size.Width - this.Width;
            this.Top = Screen.PrimaryScreen.WorkingArea.Size.Height - this.Height;
        }


        protected void aralikBul()
        {
                for (i = 0; i <= zamanlar.Length; i++)
                {
                    basZaman = Convert.ToDateTime(bugun + " " + zamanlar[i]);
                    bitZaman = Convert.ToDateTime(bugun + " " + zamanlar[i + 1]);

                    if (suAn >= basZaman && suAn <= bitZaman)
                    {
                    if (i % 2 == 0)
                    {
                        mesaj = " Başlamasına";
                        this.BackColor= Color.LightPink;
                    }
                   else
                    {
                        mesaj = " Bitimine";
                        this.BackColor = Color.LemonChiffon;
                    }
                        
                        label6.Text = (i/2+1)+". Dersin" + mesaj + " Kalan Süre:";
                        break;
                    }

                }

  }


        private void Form1_Load(object sender, EventArgs e)
        {
           
            bugun = DateTime.Now.ToShortDateString();
            aralikBul();            
            panKucuk();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            suAn = DateTime.Now;
            kalanSure = bitZaman - suAn;

            ntDakika = string.Format(@"{0:%m}", kalanSure);
            ntSaniye= string.Format(@"{0:%s}", kalanSure);


            if (pan == 0)
            {
                label4.Text = string.Format(@"{0:%m}", kalanSure);
                if (label4.Text == "0") label4.Text = string.Format(@"{0:%s}", kalanSure);
                if (label4.Text == "0") aralikBul();
                
            }


            if (pan == 1) label4.Text = string.Format(@"{0:mm\:ss}", kalanSure);
            if (label4.Text == "00:00") aralikBul();

        }
                
  

   
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = .70;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Enabled = false;
        }

  

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //pan yani panel değişkeni kutunun küçük durumda mı büyük durumda mı olduğunu gösteriyor.
                //pan=0 --> küçük durumda
                //pan=1 --> büyük durumda
                if (pan == 0) panBuyuk();
                else if (pan == 1) panKucuk();
            }
            
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void gösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

       

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)                
            {

                //notifyIcon1.Visible = true;               
                // notifyIcon1.ShowBalloonTip(2000, label6.Text, ntDakika+" Dakika "+ntSaniye+" Saniye", ToolTipIcon.Info);

                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(5000, "Welcome", "Hello ", ToolTipIcon.Info);

            }
        }

       
            
   

    }
}
