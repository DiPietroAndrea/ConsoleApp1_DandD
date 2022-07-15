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
using AD.DandD.BLL;


namespace ConsoleApp1_DandD
{
    public class Program
    {
        public static List<AD.DandD.BLL.Model.CreaPersonaggio> Elenco = new List<AD.DandD.BLL.Model.CreaPersonaggio>();

        static void LoadDati()
        {
            #region Elenco dei personaggi

            var barbaro = new AD.DandD.BLL.Model.Barbaro("Andrea", "Di Pietro", 20, "Pavia", "Maschio", "Ascia", "Generale", "Primo battaglione", "Nobile", "Ravvicinato", 3, "armatura di cuoio");
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
        }
        static IEnumerable<AD.DandD.BLL.Model.CreaPersonaggio> SearchDati(string? at, string? an)
        {
            #region ---> Scelta del campo da cercare

            if (string.IsNullOrEmpty(at)) throw new ArgumentNullException("Tipo di campo obbligatorio");
            if (string.IsNullOrEmpty(an)) throw new ArgumentNullException("Valore del campo obbligatorio");
            switch (at.ToLower().Trim())
            {
                case ("n"):
                    var cn = (from c in Elenco
                              where c.Nome.ToLower().Trim() == an.ToLower().Trim()
                              select c).FirstOrDefault();
                    if (cn != null) return new[] { cn };
                    break;

                case ("c"):
                    return (from c in Elenco
                            where c.Cognome.ToLower().Trim() == an.ToLower().Trim()
                            select c).ToArray();

                case ("ln"):
                    return (from c in Elenco
                            where c.LuogoNascita.ToLower().Trim() == an.ToLower().Trim()
                            select c).ToArray();

                case ("a"):
                    var soldati = (from x in Elenco
                                   where x is AD.DandD.BLL.Model.Soldato
                                   select (AD.DandD.BLL.Model.Soldato)x).ToArray();
                    var a = (from c in soldati
                             where c.ArmaSoldato.ToLower().Trim() == an.ToLower().Trim()
                             select c).FirstOrDefault();
                    if (a != null) return new[] { a };
                    break;

                default:
                    throw new ArgumentNullException(String.Format("Il nome {0} non esiste nell'elenco, riprova", at));
            }

            throw new ArgumentNullException(String.Format("Il campo selezionato non è corretto, riprova", at));
            
            #endregion
        }

        static void Main(string[] args)
        {
            try
            {
                LoadDati();

                do
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Per quale campo vuoi cercare il personaggio?\r\n" + "n: nome\r\n" + "c: cognome\r\n" + "ln: luogo di nascita\r\n" + "a: arma\r\n");
                    var att = Console.ReadLine();
                    Console.WriteLine("\r\nDigita i valori da ricercare\r\n");
                    var an = Console.ReadLine();
                    var personaggiTrovati = SearchDati(att, an);
                    personaggiTrovati = SearchDati(att, an);


                    if (personaggiTrovati != null)
                    {
                        foreach (var Personaggio in personaggiTrovati)
                        {
                            Console.WriteLine("\n" + Personaggio.stampaScheda() + "\n");
                            
                        }
                        
                    };

                } while (true);

            }
            catch (ArgumentNullException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex.Message);
            }
            catch (System.Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }
    }
}