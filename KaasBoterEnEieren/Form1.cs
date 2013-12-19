using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using KaasBoterEnEieren.component;

namespace KaasBoterEnEieren
{
    public partial class Form1 : Form
    {
        private int beurt = 1;
        private List<SpelVakje> vakjes = new List<SpelVakje>();

        public Form1()
        {
            InitializeComponent();

            this.MakeBord();
        }

        private void MakeBord()
        {
            vakjes.Add(new SpelVakje(this.VakjeImage1 ,1,1));
            vakjes.Add(new SpelVakje(this.VakjeImage2,1,2));
            vakjes.Add(new SpelVakje(this.VakjeImage3,1,3));
            vakjes.Add(new SpelVakje(this.VakjeImage4,2,1));
            vakjes.Add(new SpelVakje(this.VakjeImage5,2,2));
            vakjes.Add(new SpelVakje(this.VakjeImage6,2,3));
            vakjes.Add(new SpelVakje(this.VakjeImage7,3,1));
            vakjes.Add(new SpelVakje(this.VakjeImage8,3,2));
            vakjes.Add(new SpelVakje(this.VakjeImage9,3,3));

            for (int i = 0; i < 9; i++)
            {
                vakjes[i].PBox.Click += PBox_Click;
            }

        }

        void PBox_Click(object sender, EventArgs e)
        {
            SpelSession.beurt++;

            //check of iemand heeft gewonnen
            bool x = true;
            bool o = true;
            bool x1 = true;
            bool o1 = true;
            for (int i = 1; i < 4; i++)
            {
                if (vakjes.Where(v => v.X == i).Count(v => v.Toestand == SpelVakjeToestand.rondje) == 3)
                {
                    this.meldingen.Text = "rondje heeft gewonnen";
                    SpelSession.beurt = 0;
                }
                else if (vakjes.Where(v => v.X == i).Count(v => v.Toestand == SpelVakjeToestand.kruisje) == 3)
                {
                    this.meldingen.Text = "kruisje heeft gewonnen";
                    SpelSession.beurt = 0;
                }
                if (vakjes.Where(v => v.Y == i).Count(v => v.Toestand == SpelVakjeToestand.rondje) == 3)
                {
                    this.meldingen.Text = "rondje heeft gewonnen";
                    SpelSession.beurt = 0;
                }
                else if (vakjes.Where(v => v.Y == i).Count(v => v.Toestand == SpelVakjeToestand.kruisje) == 3)
                {
                    this.meldingen.Text = "kruisje heeft gewonnen";
                    SpelSession.beurt = 0;
                }

                if (vakjes.Where(v => v.X == i && v.Y == i).First().Toestand != SpelVakjeToestand.rondje)
                    o = false;
                if (vakjes.Where(v => v.X == i && v.Y == i).First().Toestand != SpelVakjeToestand.kruisje)
                    x = false;

                if (vakjes.Where(v => v.X == i && v.Y == 4-i).First().Toestand != SpelVakjeToestand.rondje)
                    o1 = false;
                if (vakjes.Where(v => v.X == i && v.Y == 4-i).First().Toestand != SpelVakjeToestand.kruisje)
                    x1 = false;
            }
            //diagonaal
            if(x || x1)
                this.meldingen.Text = "kruisje heeft gewonnen";
            if(o || o1)
                this.meldingen.Text = "rondje heeft gewonnen";

        }

    }
}
