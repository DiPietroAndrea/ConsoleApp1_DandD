// See https://aka.ms/new-console-template for more information

namespace ConsoleApp1_DandD
{

    public class Program
    {

        private static List<Model.CreaPersonaggio> Elenco = new List<ConsoleApp1_DandD.Model.CreaPersonaggio>();

        static void LoadDati()
        {
            var barbaro = new ConsoleApp1_DandD.Model.Barbaro("Andrea", "Di Pietro", 20, "Maschio", "Pavia", "Ascia", "Generale", "Primo battaglione", "Nobile", "Ravvicinato", 3, "armatura di cuoio");
            var mago = new ConsoleApp1_DandD.Model.Mago("Simone", "Di Pietro", 24, "Maschio", "Voghera", "luci danzanti", "illusione minore", "Distanza", 5, "palla di fuoco");
            var bardo = new ConsoleApp1_DandD.Model.Bardo("Chiara", "Sedita", 18, "Femmina", "Palermo", "calzante", "Valzher", "Medio raggio", 8, "house of memories");
            var ladro = new ConsoleApp1_DandD.Model.Ladro("Leonardo", "Alloni", 19, "Maschio", "Casteggio", "Pugnale", "Spia", "Secondo battaglione", "Plebeo", "corpo a corpo", 4, "colpo d'ombra");
            var stregone = new ConsoleApp1_DandD.Model.Stregone("Matteo", "Vattimo", 19, "Maschio", "Milano", "soffio velenoso", "mano magica", "medio lungo raggio", 10, "meteora");
            Elenco.Add(barbaro);
            Elenco.Add(mago);
            Elenco.Add(bardo);
            Elenco.Add(ladro);
            Elenco.Add(stregone);
        }
        static IEnumerable<Model.CreaPersonaggio> SearchDati(string? at, string? an)
        {
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
                    break;

                case ("ln"):
                    return (from c in Elenco
                            where c.LuogoNascita.ToLower().Trim() == an.ToLower().Trim()
                            select c).ToArray();

                case ("a"):
                    var soldati = (from x in Elenco 
                                  where x is Model.Soldato 
                                 select (Model.Soldato)x).ToArray();
                    var a = (from c in soldati
                             where c.ArmaSoldato.ToLower().Trim() == an.ToLower().Trim()
                             select c).FirstOrDefault();
                    if (a != null) return new[] { a };
                    break;

                default:
                    throw new ArgumentNullException(String.Format("Il nome {0} non esiste nell'elenco, riprova", at));
            }

            throw new ArgumentNullException(String.Format("Il campo selezionato non è corretto, riprova", at));

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
                    if (personaggiTrovati != null)
                    {
                        foreach (var Personaggio in personaggiTrovati)
                        {
                            Console.WriteLine("\r\n" + Personaggio.stampaScheda());
                        }

                        var xml = Salvataggio(Elenco);
                        Console.Write(xml);

                        //Salvataggio su file csv

                        var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
                        {
                            Delimiter = ";"
                        };
                        using (var writer = new StreamWriter("C:\\Users\\maxidata\\Desktop\\Schede.txt"))
                        using (var csv = new CsvWriter(writer, csvConfig))
                        {
                            csv.WriteRecords(personaggiTrovati);
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
        //visaulizzare a video elenco personaggi formato xml e salvataggio in un file.xml

        
        //    var company = new Company();
    //    company.Employees = new List<Employee>() { new Employee() { Name = "o", Age = "10" }
    //};
    //SerializeToXml(company, xmlFilePath);
    //public static void SerializeToXml<T>(T anyobject, string xmlFilePath)
    //{
    //    XmlSerializer xmlSerializer = new XmlSerializer(anyobject.GetType());

    //    using (StreamWriter writer = new StreamWriter(xmlFilePath))
    //    {
    //        xmlSerializer.Serialize(writer, anyobject);
    //    }
    //}
        
        
        public static string Salvataggio<T>(T anyobject)
        {
            XmlSerializer serializer1 = new XmlSerializer(typeof(T));
            using var file = new StreamWriter("C:\\Users\\maxidata\\Desktop\\Schede.xml");

            var Deserialize = (T)serializer1.Deserialize();

            string SerializeToXml;
            {
                using (StringWriter sw = new StringWriter())
                {
                    serializer1.Serialize(sw, anyobject);
                    return sw.ToString();
                }
            }
    }
}


