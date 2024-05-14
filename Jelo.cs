using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak3
{
    enum Kvalitet
    {
        Prihvatljiv=1,
        Dobar=2,
        Odlican=3,
    }
    internal class Jelo : Stavka
    {
        private double nabavnacena;
        private Kvalitet kvalitet;

        public Jelo()  : base() { }

       public Jelo(string naziv,DateTime datumisteka,bool dalijeveganska,double nabavnacena,Kvalitet kvalitet) : base(naziv,datumisteka,dalijeveganska)
        {
           
            this.nabavnacena = nabavnacena;
            this.kvalitet = kvalitet;

        }
        public override double cena()
        {
            double vcena;
            vcena = (double)kvalitet * nabavnacena;
            if((datumisteka - DateTime.Now).Days < 3)
            {
                return vcena * 0.8;
            }
            else
            {
                return vcena;
            }
        }

        public override void upisiubinarni(BinaryWriter bw)
        {
            bw.Write("J");
            base.upisiubinarni(bw);
            bw.Write(nabavnacena);
            bw.Write((int)kvalitet);
        }

        public override void citajizbinarni(BinaryReader br)
        {
            base.citajizbinarni(br);
            nabavnacena = br.ReadDouble();
            kvalitet = (Kvalitet)br.ReadInt32();
        }

    }
}
