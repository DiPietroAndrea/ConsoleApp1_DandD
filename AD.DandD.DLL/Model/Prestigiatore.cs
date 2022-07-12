using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.DandD.BLL.Model
{
    public class Prestigiatore : CreaPersonaggio
    {
        #region ---> Dichiarazioni
        private String trucchetto;
        private String assoManica;
        #endregion

        #region ---> Costruttori
        public Prestigiatore() : this(string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }
        public Prestigiatore(String n, String c, int e, String s, String ln, String t, String asm) : base(n, c, e, s, ln)
        {
            trucchetto = t;
            assoManica = asm;
        }
        #endregion

        #region ---> Dichiarazioni
        public String Trucchetto
        { get { return trucchetto; } set { trucchetto = value; } }
        public String AssoManica
        { get { return assoManica; } set { assoManica = value; } }
        #endregion

        #region ---> Metodi
        public override string stampaScheda()
        {
            return (base.stampaScheda() + "trucchetti: " + trucchetto + "\r\nasso nella manica: " + assoManica + "\r\n");
        }
        #endregion
    }
}
