using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_DandD.Model;

namespace Wpf_DandD
{
    
    public class MainViewModel : ViewModel
    {
        private ObservableCollection<CreaPersonaggio> elenco;
        private int _count;



        public MainViewModel()
        {
            _count = 0;
            elenco = new ObservableCollection<CreaPersonaggio>();
            elenco.Add(new CreaPersonaggio() { Nome = "Andrea", Cognome = "Di Pietro", Eta = 20, Sesso = "Maschio", LuogoNascita = "Pavia" });
            elenco.Add(new CreaPersonaggio() { Nome = "Simone", Cognome = "Di Pietro", Eta = 25, Sesso = "Maschio", LuogoNascita = "Voghera" });
            elenco.Add(new CreaPersonaggio() { Nome = "Valeria", Cognome = "Calore", Eta = 18, Sesso = "Femmina", LuogoNascita = "Nettuno" });
            _nuovoPersonaggio = new RelayCommand(NuovoPersonaggioRoutine);
        }

        public ObservableCollection<CreaPersonaggio> Elenco
        { get { return elenco; } set { elenco = value; OnPropertyChanged(nameof(Elenco)); } }

        public int Count
        { get { return _count; } set { _count = value; OnPropertyChanged(nameof(Count));} }


        private RelayCommand _nuovoPersonaggio;
        public RelayCommand NuovoPersonaggio
        { get { return _nuovoPersonaggio; } }

        private void NuovoPersonaggioRoutine(object p)
        {
            
            NewCharacterView win2 = new NewCharacterView();
            win2.ShowDialog();


            //(bool)win2.DialogResult; 
            {
            Elenco.Add(win2.VM.NuovoPersonaggio);
            }

            OnPropertyChanged(nameof(Elenco));

        }
    }

}
