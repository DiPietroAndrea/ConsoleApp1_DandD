using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.DandD.BLL.Model
{
    public class Barbaro : Soldato
    {
        #region ---> Dichiarazioni
        private String stileBarbaro;
        private int puntiFuria;
        private String armatura;
        #endregion

        #region ---> Costruttori
        public Barbaro() : this(string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty)
        {
        }

        public Barbaro(String n, String c, int e, String ln, String s, String asl, String r, String b, String cs,  String sb, int pf, String a) : base(n, c, e, s, ln, asl, r, b, cs)
        {
            stileBarbaro = sb;
            puntiFuria = pf;
            armatura = a;
        }
        #endregion

        #region ---> Proprietà
        public string StileBarbaro
        { get { return stileBarbaro; } set { stileBarbaro = value; } }
        public int PuntiFuria
        { get { return puntiFuria; } set { puntiFuria = value; } }
        public String Armatura
            { get { return armatura; } set { armatura = value; } }
        #endregion

        #region ---> Metodi
        public override string stampaScheda()
        {
            return ("Personaggio 1: \r\n\r\n" + base.stampaScheda() + "\r\n" + "Stile di combattimento: " + stileBarbaro + "\r\n" + "Punti Furia:  " + puntiFuria + "\r\n" + "Armatura: " + armatura + "\r\n");
        }
        #endregion
    }
}
