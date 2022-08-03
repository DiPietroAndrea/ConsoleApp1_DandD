using System;
using System.Collections;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using AD.Helper;
using AD.DandD.BLL.ORM;
using AD.DandD.ORM;

namespace ConsoleApp_DD
{
    public class Programma
    {
        public static List<AD.DandD.BLL.Model.CreaPersonaggio> Elenco = new List<AD.DandD.BLL.Model.CreaPersonaggio>();


        static void Main(string[] args)
        {
            var cfg = new Config(@"C:\User\maxidata\Desktop\Elenco_Personaggi");

            #region ---> Elenco dei personaggi

            var barbaro = new AD.DandD.BLL.Model.Barbaro("Andrea", "Di Pietro", 20, "Pavia", "Maschio", "Spadone", "Capo squadra d'assalto", "Terzo battaglione", "Comune cittadino", "Ravvicinato", 10, "Armatura in piastre");
            var mago = new AD.DandD.BLL.Model.Mago("Simone", "Di Pietro", 24, "Maschio", "Voghera", "luci danzanti", "illusione minore", "Distanza", 5, "palla di fuoco");
            var bardo = new AD.DandD.BLL.Model.Bardo("Chiara", "Sedita", 18, "Femmina", "Palermo", "calzante", "Valzher", "Medio raggio", 8, "house of memories");
            var ladro = new AD.DandD.BLL.Model.Ladro("Leonardo", "Alloni", 19, "Maschio", "Casteggio", "Pugnale", "Spia", "Secondo battaglione", "Plebeo", "corpo a corpo", 4, "colpo d'ombra");
            var stregone = new AD.DandD.BLL.Model.Stregone("Matteo", "Vattimo", 19, "Maschio", "Milano", "soffio velenoso", "mano magica", "medio lungo raggio", 10, "meteora");
            Elenco.Add(barbaro);
            Elenco.Add(mago);
            Elenco.Add(bardo);
            Elenco.Add(ladro);
            Elenco.Add(stregone);

            #endregion


            #region ---> Scrivere

            var ctx = new Context(cfg);
            
            ctx.Scrivere(Elenco);

            foreach (var p in Elenco)
            {
                Console.WriteLine(p); 
            }
            
            //foreach(string i in ctx.Leggere())

            Console.WriteLine("\r\nQuesto è l'elenco dei personaggi");

            #endregion


            #region ---> Leggere

            Elenco.Clear();

            Elenco.AddRange(ctx.Leggere());

            if (Elenco.Count() == 0) throw new Exception("L'elenco è vuoto");

            #endregion


            #region ---> Inserire

            var nuovo = new AD.DandD.BLL.Model.CreaPersonaggio("Valeria", "Calore", 18, "Femmina", "Nettuno");

            var n = new AD.DandD.BLL.Model.CreaPersonaggio("Michele", "Imberti", 19, "Maschio", "Bergamo");

            ctx.Inserire(nuovo);

            ctx.Inserire(n);

            // ---> Verfica inserimento e rilettura del file

            Elenco.Clear();
            
            Elenco.AddRange(ctx.Leggere());

            if (!(from x in Elenco where x.ID == nuovo.ID select x).Any()) throw new Exception("Nessun nuovo personaggio è stato inserito");

            //if (Elenco.Contains(nuovo) == null)

            Console.WriteLine("\r\nL'elenco è stato aggiornato.\r\n\r\nPersonaggio 6:\r\n\r\n" + nuovo + "Personaggio 7:\r\n\r\n" + n);

            #endregion


            #region ---> Modificare

            nuovo.Nome = "Valentina";

            //var pm = new AD.DandD.BLL.Model.CreaPersonaggio("Valentina", "Calore", 18, "Femmina", "Nettuno");

            ctx.Inserire(nuovo);

            //pm.Nome = "pippo";

            ctx.Modificare(nuovo);

            // ---> Verifica modifica e rilettura del file

            Elenco.Clear();
            
            Elenco.AddRange(ctx.Leggere());

            if (!(from x in Elenco where x.ID == nuovo.ID select x).Any()) throw new Exception("La modifica non è stata apportata corretamente");

            if (!(from x in Elenco where x.ID == nuovo.ID && x.Nome == nuovo.Nome select x).Any()) throw new Exception("La modifica non è stata effettuata"); 

            #endregion


            #region ---> Eliminare

            ctx.Eliminare(barbaro);

            // ---> Verifica eliminazione e rilettura del file

            Elenco.Clear();
            
            Elenco.AddRange(ctx.Leggere());

            if (!(from x in Elenco where x.ID != barbaro.ID select x).Any()) throw new Exception("Il personaggio non è stato eliminato con successo");

            Console.WriteLine("\r\nNuovo elenco dei personaggi: ");

            foreach (var p in ctx.Leggere())
            {
                Console.WriteLine("\r\n" + p);
            }

            #endregion
        }
    }
}