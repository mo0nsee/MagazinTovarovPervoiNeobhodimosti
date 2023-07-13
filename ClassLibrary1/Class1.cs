using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Director
    {
        string Parol;
        public Director(string parol)
        {
            this.Parol = parol;
        }
        public override string ToString()
        {
            return string.Format("{0}", Parol);
        }
    }
    public abstract class Human
    {
        public string fio;
    }
    public class Rabotniki : Human
    {
        public int Godprin;
        public string dols;
        public int zarp;
        public int staj;
        public Rabotniki(string fio, string dols, int Godprin, int zarp, int staj)
        {
            this.fio = fio;
            this.dols = dols;
            this.Godprin = Godprin;
            this.zarp = zarp;
            this.staj = staj;
        }
        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4}", fio, dols, Godprin, zarp, staj);
        }
    }
    public abstract class Tovars
    {
        public string nazvanie;
        public string srok;
        public string otdel;
    }
    public class Tovar : Tovars
    {
        public double cena;
        public int kolvo;
        public string nalichie;
        public Tovar(string nazvanie, string srok, string otdel, double cena, int kolvo, string nalichie)
        {
            this.nazvanie = nazvanie;
            this.srok = srok;
            this.otdel = otdel;
            this.cena = cena;
            this.kolvo = kolvo;
            this.nalichie = nalichie;
        }
        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5}", nazvanie, srok, otdel, cena, kolvo, nalichie);
        }
    }
    public struct ZakupkaGr
    {
        public string data;
        public ZakupkaGr(string data)
        {
            this.data = data;
        }
        public override string ToString()
        {
            return string.Format("{0}", data);
        }
    }
    public struct ZakupkaSp
    {
        public string nazvanie;
        public double cena;
        public int kolvo;
        public ZakupkaSp(string nazvanie,double cena, int kolvo)
        {
            this.nazvanie = nazvanie;
            this.cena = cena;
            this.kolvo = kolvo;
        }
        public override string ToString()
        {
            return string.Format("{0};{1};{2}", nazvanie,cena,kolvo);
        }
    }

}
