using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.DandD.BLL.Model
{
    public class Ladro : Soldato
    {
        private String stileLadro;
        private int puntiFurtività;
        private String abilitàFurtiva;


        public Ladro() : this(string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty)
        { }

        public Ladro (String n, String c, int e, String s, String ln, String asl, String r, String b, String cs, String sl, int pf, String af) : base (n, c, e, s, ln, asl, r, b, cs)
        {
            stileLadro = sl;
            puntiFurtività = pf;
            abilitàFurtiva = af;
        }
        
        public String StileLadro
        { get { return stileLadro; } set { stileLadro = value; } }
        public int PuntiFurtività
        { get { return puntiFurtività; } set { puntiFurtività= value; } }
        public String AbilitàFurtiva
        { get { return abilitàFurtiva; } set { abilitàFurtiva = value; } }

        public override string stampaScheda()
        {
            return ("Personaggio 4: \r\n\r\n" + base.stampaScheda() + "Stile ladro: " + stileLadro + "\r\nPunti furtività: " + puntiFurtività + "\r\nAbilità furtiva: " + abilitàFurtiva + "\r\n");
        }
    }
}
