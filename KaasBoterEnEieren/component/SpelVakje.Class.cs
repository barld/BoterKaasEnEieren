using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using KaasBoterEnEieren;

namespace KaasBoterEnEieren.component
{
    public class SpelVakje
    {
        #region events
        private event EventHandler ChangeState;
        #endregion

        #region private fields
        private SpelVakjeToestand _toestand;
        #endregion

        #region properties
        public PictureBox PBox { private set; get; }
        public SpelVakjeToestand Toestand 
        {
            private set
            {
                this._toestand = value;
                ChangeState("hoi", new EventArgs());
            }
            get
            {
                return this._toestand;
            }
        }
        public int X;
        public int Y;
        #endregion


        #region constructors

        public SpelVakje(PictureBox pBox, int x, int y)
        {
            this.PBox = pBox;
            this.X = x;
            this.Y = y;

            this.ChangeState += ChangeImage;//zorg ervoor dat het plaatje altijd wordt gewijzigd als de staat veranderd
            this.Toestand = SpelVakjeToestand.leeg;//hij begint leeg

            this.PBox.Click += PBox_Click;

            
        }

        void PBox_Click(object sender, EventArgs e)
        {
            if (this.Toestand != SpelVakjeToestand.leeg)
            {
                SpelSession.beurt--;
                return;
            }
            if (SpelSession.beurt % 2 == 0) //hij moet leeg zijn 
            {
                this.Toestand = SpelVakjeToestand.kruisje;
                return;//stop
            }
            this.Toestand = SpelVakjeToestand.rondje;
        }

        #endregion

        private void ChangeImage(object sender, EventArgs e)
        {
            switch (this.Toestand)
            {
                case(SpelVakjeToestand.leeg):
                    this.PBox.Image = null;//global::KaasBoterEnEieren.Properties.Resources.rondje;
                    break;
                case(SpelVakjeToestand.kruisje):
                    this.PBox.Image = global::KaasBoterEnEieren.Properties.Resources.kruisje;
                    break;
                case(SpelVakjeToestand.rondje):
                    this.PBox.Image = global::KaasBoterEnEieren.Properties.Resources.rondje;
                    break;
            }
        }
    }
}
