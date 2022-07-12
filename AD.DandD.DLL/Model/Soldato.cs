using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.DandD.BLL.Model
{
    public class Soldato : CreaPersonaggio
    {
        #region ---> Dichiarazioni
        private String armaSoldato;
        private String rango;
        private String battaglione;
        private String cetoSociale;
        #endregion

        #region ---> Costruttori
        public Soldato() : this(string.Empty, string.Empty, 0, string.Empty, string.Empty,String.Empty, string.Empty, string.Empty, string.Empty)
        {
        }
        public Soldato(String n, String c, int e, String s, String ln, String asl, String r, String b, String cs) : base (n, c, e, s, ln)
        {
            armaSoldato = asl;
            rango = r;
            battaglione = b;
            cetoSociale = cs;
        }
        #endregion

        #region ---> Proprietà
        public String ArmaSoldato
        { get { return armaSoldato; } set { armaSoldato = value; } }
        public String Rango
        { get { return rango; } set { rango = value; } }
        public String Battaglione
        { get { return battaglione; } set { battaglione = value; } }
        public string CetoSociale
        { get { return cetoSociale; } set { cetoSociale = value; } }
        #endregion

        #region ---> Metodi
        public override string stampaScheda()
        {
            return (base.stampaScheda() + "arma soldato: " + "\r\nrango: " + rango + "\r\nbattaglione: " + battaglione + "\r\nceto sociale: " + cetoSociale);
            
        }
        #endregion
    }
}
