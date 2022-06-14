using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_DandD.Model
{
    class Musicista : CreaPersonaggio
    {
        #region ---> Dichiarazioni
        private String ritmo;
        private String ballo;
        #endregion

        #region ---> Costruttori
        public Musicista() : this (string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty)
        { }

        public Musicista (String n, String c, int e, String s, String ln, String r, String ba) : base(n, c, e, s, ln)
        {
            ritmo = r;
            ballo = ba;
        }
        #endregion

        #region --->Proprietà
        public String Ritmo
            { get { return ritmo; } set { ritmo = value; } }
        public String Ballo 
            { get { return ballo; } set { ballo = value; } }
        #endregion

        #region ---> Metodi
        public override string stampaScheda()
        {
            return (base.stampaScheda() + "ritmo: " + ritmo + "\r\nballo: " + ballo);
        }
        #endregion
    }
}
