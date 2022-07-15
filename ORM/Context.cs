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
using AD.DandD.BLL;
using AD.DandD.BLL.ORM;
using AD.Helper;
using System.ComponentModel.DataAnnotations;

namespace AD.DandD.ORM
{
    public class Context
    {
        #region --> Dichiarazioni

        private Config config;
        
        #endregion

        #region --> Costruttori

        public Context(Config config)
        {
            this.config = config;
            if (!Directory.Exists(config.Path)) Directory.CreateDirectory(config.Path);
        }

        #endregion

        #region --> Metodi

        public void Scrivere(IEnumerable<AD.DandD.BLL.Model.CreaPersonaggio> elenco)
        {
            var filepath = System.IO.Path.Combine(config.Path, "personaggi.json");
            elenco.ToJSONFile(filepath);
        }

        public IEnumerable<BLL.Model.CreaPersonaggio> Leggere()
        {
            List<BLL.Model.CreaPersonaggio> elenco = new List<BLL.Model.CreaPersonaggio>();
            var filepath = System.IO.Path.Combine(config.Path, "personaggi.json");
            if (!File.Exists(filepath)) return elenco;
            
            var p = filepath.FromJSONFile<IEnumerable<BLL.Model.CreaPersonaggio>>();
            if (p == null) return elenco;  
            elenco.AddRange(p);
            return elenco;
        }

        public void Validare(BLL.Model.CreaPersonaggio item)
        {
            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                throw new Exception("Il campo nome è obbligatorio");
            }

            if (string.IsNullOrWhiteSpace(item.Cognome))
            {
                throw new Exception("Il campo congome è obbligatorio");
            }

            if (item.Eta < 5)
            {
                throw new Exception("Inserire un età più elevata di quella digitata");
            }
        }

        public void Inserire(BLL.Model.CreaPersonaggio item)
        {
            var elenco = this.Leggere().ToList();

            //--> Logica di validazione
            
            this.Validare(item);
            
            //--> Aggiungo l'item nell'elenco

            elenco.Add(item);

            //--> Riscrivo tutto l'elenco
            this.Scrivere(elenco);
        }

        //public void Modificare(BLL.Model.CreaPersonaggio item)
        //{
        //    var elenco = this.Leggere().ToList();

        //    //--> Logica di validazione

        //    this.Validare(item);

        //    //--> Cerco l'item con la stessa chiave

        //    var old_item = (from c in elenco
        //                    where item.ID == c.ID where item.Nome == c.Nome
        //                    select c).FirstOrDefault();

        //    //--> Sostituisco l'item nell'elenco

        //    if (old_item == null) throw new Exception("L'oggetto passato non appartiene all'eleneco");
        
        //        elenco.Remove(old_item);
        
        //        elenco.Add(item);

        //    //--> Riscrivo tutto l'elenco

        //    this.Scrivere(elenco);
        //}

        public void Modificare(BLL.Model.CreaPersonaggio item, BLL.Model.CreaPersonaggio? old_item)
        {
            var elenco = this.Leggere().ToList();

            //--> Logica di validazione

            this.Validare(item);

            //--> Cerco l'item con la stessa chiave

            old_item = (from c in elenco
                            where item.ID == c.ID
                            where item.Nome == c.Nome
                            select c).FirstOrDefault();

            //--> Sostituisco l'item nell'elenco

            if (old_item == null) throw new Exception("L'oggetto passato non appartiene all'eleneco");
            
            elenco.Remove(old_item);
            
            elenco.Add(item);

            //--> Riscrivo tutto l'elenco

            this.Scrivere(elenco);
        }

        public void Eliminare(BLL.Model.CreaPersonaggio item)
        {
            var elenco = this.Leggere().ToList();

            //--> Cerco l'item con la stessa chiave

            var old_item = (from c in elenco
                            where item.ID == c.ID
                            select c).FirstOrDefault();

            //--> Rimuovo l'item dall'elenco

            if (old_item == null) throw new Exception("L'oggetto passato non appartiene all'elengo");
                elenco.Remove(old_item);

            //--> Riscrivo tutto l'elenco

            this.Scrivere(elenco);
        }

        #endregion
    }
}