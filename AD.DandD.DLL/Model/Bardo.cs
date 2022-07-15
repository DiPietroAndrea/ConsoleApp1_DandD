using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.DandD.BLL.Model
{
    public class Bardo : Musicista
    {
        #region ---> Dichiarazioni
        private String stileBardo;
        public int puntiIspirazione;
        public String brano;
        #endregion

        #region ---> Costruttori
        public Bardo() : this(string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty)
        {
        }
        public Bardo(String n, String c, int e, String s, String ln, String r, String ba, String sbr, int pi, String br) : base(n, c, e, s, ln, r, ba)
        {
            stileBardo = sbr;
            puntiIspirazione = pi;
            brano = br;
        }
        #endregion

        #region ---> Proprietà

        public String StileBardo
        { get { return stileBardo; } set { stileBardo = value; } }
        public int PuntiIspirazione
        { get { return puntiIspirazione; } set { puntiIspirazione = value; } }
        
        #endregion

        public String Brano
            { get { return brano; } set { brano = value; } }

        #region ---> Metodi

        public override string stampaScheda()
        {
            return ("Personaggio 3: \r\n\r\n" + base.stampaScheda() + "\r\n" + "Stile di combattimento: " + stileBardo + "\r\n" + "Punti ispirazione: " + puntiIspirazione + "\r\nBrano: " + brano + "\r\n");
        }
        #endregion
    }
}
