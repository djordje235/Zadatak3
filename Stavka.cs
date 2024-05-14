using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace zadatak3
{
    internal  abstract class Stavka : IComparable<Stavka>
    {
        protected string naziv;
        protected DateTime datumisteka;
        protected bool dalijeveganska;

        public Stavka() { }

        public Stavka(string naziv, DateTime datumisteka, bool dalijeveganska)
        {
            this.naziv = naziv;
            this.datumisteka = datumisteka;
            this.dalijeveganska = dalijeveganska;
        }
        public DateTime Datumisteka
        {
            get { return datumisteka; }
        }

        public bool Dalijeveganska
        {
            get { return dalijeveganska; }
        }

        public abstract double cena();

        public virtual void upisiubinarni(BinaryWriter bw) 
        {
            bw.Write(naziv);
            bw.Write(datumisteka.Ticks);
            bw.Write(dalijeveganska);
        }

        public virtual void citajizbinarni(BinaryReader br) 
        {
            naziv = br.ReadString();
            datumisteka = new DateTime(br.ReadInt64());
            dalijeveganska = br.ReadBoolean();
        }

        public int CompareTo(Stavka stavka)
        {
            if(this.cena() < stavka.cena())
            {
                return -1;
            }
            if(this.cena() > stavka.cena())
            {
                return 1;
            }
            return 0;
        }

        public virtual void prikaz()
        {
            Console.WriteLine("Naziv: " + naziv);
            Console.WriteLine("Cena: " + this.cena());
        }
    }
}
