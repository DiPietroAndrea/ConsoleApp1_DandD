using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_DandD.Model
{
    class Stregone : Prestigiatore
    {
        public String stileStregone;
        public int puntiStregoneria;
        public String incantesimo;

        public Stregone() : this(string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0, string.Empty)
        { }

        public Stregone(String n, String c, int e, String s, String ln, String t, String asm, String ss, int ps, String i) : base (n, c, e, s, ln, t, asm)
        {
            stileStregone = ss;
            puntiStregoneria = ps;
            incantesimo = i;
        }
            
        public String StileStregone
        { get { return stileStregone; } set { stileStregone = value; } }
        public int PuntiStregoneria
        { get { return puntiStregoneria; } set { puntiStregoneria = value; } }
        public String Incantesimo
        { get { return incantesimo; } set { incantesimo = value; } }

        public override string stampaScheda()
        {
            return (base.stampaScheda() + "stil stregone: " + stileStregone + "\r\npunti stregonerai: " + puntiStregoneria + "\r\nincantesimo " + incantesimo);
        }
    }
}
