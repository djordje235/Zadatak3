using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace zadatak3
{
    enum Vrsta
    {
        domace,
        uvozno
    }
    internal class Pice : Stavka
    {
        private double cenapolitru;
        private double kolicina;
        private Vrsta vrsta;
        
        public Pice() : base() { }

        public Pice(string naziv,DateTime datumisteka,bool dalijeveganska,double cenapolitru,double kolicina,Vrsta vrste) : base(naziv, datumisteka, dalijeveganska)
        {
            this.cenapolitru = cenapolitru;
            this.kolicina = kolicina;
            this.vrsta = vrsta;
        }

        public override double cena()
        {
            double vcena;
            vcena = cenapolitru * kolicina;
            if (vrsta == Vrsta.uvozno)
            {
                return vcena * 1.3;
            }
            else
            {
                return vcena;
            }
        }

        public override void upisiubinarni(BinaryWriter bw)
        {
            bw.Write("P");
            base.upisiubinarni(bw);
            bw.Write(cenapolitru);
            bw.Write(kolicina);
            bw.Write((int)vrsta);

        }

        public override void citajizbinarni(BinaryReader br)
        {
            base.citajizbinarni(br);
            kolicina = br.ReadInt32();
            cenapolitru = br.ReadDouble();
            vrsta = (Vrsta)br.ReadInt32();

        }


    }
}
