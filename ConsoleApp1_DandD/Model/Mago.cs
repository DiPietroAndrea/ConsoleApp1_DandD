using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_DandD.Model
{
    class Mago : Prestigiatore
    {
        #region ---> Dichiarazioni
        private String stileMago;
        private int puntiMago;
        private String magia;
        #endregion

        #region ---> Costruttori
        public Mago() : this(string.Empty, string.Empty, 0, string.Empty, string.Empty,String.Empty, string.Empty, string.Empty, 0, string.Empty)
        {
        }
        public Mago(String n, String c, int e, String s, String ln, String t, String asm, String sm, int pm, String m) : base(n, c, e, s, ln, t, asm)
        {
            stileMago = sm;
            puntiMago = pm;
            magia = m;
        }
        #endregion

        #region ---> Proprietà
        public String StileMago
        { get { return stileMago; } set { stileMago = value; } }
        public int PuntiMago
        { get { return puntiMago; } set { puntiMago = value; } }
        public String Magia
            { get { return magia; } set { magia = value; } }
        #endregion

        #region ---> Metodi
        public override string stampaScheda()
        {
            return ("Personaggio 2: \r\n\r\n" + base.stampaScheda() + "\r\n" + "Stile di combattimento: " + stileMago + "\r\n" + "Punti magia: " + puntiMago + "\r\nMagia: " + magia + "\r\n");
        }
        #endregion
    }
}
