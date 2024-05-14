using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadatak3
{
    internal class Restoran
    {
        private string nazivrestorana;
        private List<Stavka> meni;

        public Restoran(string ime)
        {
            this.nazivrestorana = ime;
            meni = new List<Stavka>();
        }
        
        public void Dodajstavku(Stavka stavka)
        {
            meni.Add(stavka);
        }

        public void Sortirajpoceni()
        {
            meni.Sort();
        }
        public void Izbaci()
        {
            int i = 0;
            while (i < meni.Count)
            {
                if (meni[i].Datumisteka < DateTime.Now)
                {
                    meni.Remove(meni[i]);
                }
                else
                {
                    i++;
                }
            }

        }
        public void Proveriveganski()
        {
            int k = 0;
            foreach (Stavka stavka in meni)
            {
                if (stavka.Dalijeveganska)
                {
                    k = 1;
                }
            }
            if (k == 0)
            {
                throw new VeganUnfriendly("Nema veganskih stavki!");
            }
        }

        public void upis(string fajl)
        {
            try
            {
                using (BinaryWriter upisi = new BinaryWriter(new FileStream(fajl, FileMode.Create)))
                {
                    upisi.Write(meni.Count);
                    upisi.Write(nazivrestorana);
                    foreach(var stavka in meni)
                    {
                        stavka.upisiubinarni(upisi);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void citanje(string fajl)
        {
            try
            {
                using (BinaryReader citaj = new BinaryReader(new FileStream(fajl, FileMode.Open)))
                {
                    int duzina = citaj.ReadInt32();
                    nazivrestorana = citaj.ReadString();
                    meni.Clear();
                    for (int i = 0; i < duzina; i++)
                    {
                        char tip = citaj.ReadChar();
                        Stavka stavka;
                        if (tip == 'J')
                        {
                            stavka = new Jelo();
                        }
                        else
                        {
                            stavka = new Pice();
                        }
                        stavka.citajizbinarni(citaj);
                        meni.Add(stavka);
                    }
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void print()
        {
            foreach (var stavka in meni)
            {
                stavka.prikaz();
            }
        }

    }
}
