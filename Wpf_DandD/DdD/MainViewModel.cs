using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wpf_DandD.Model;
using Wpf_DandD.Personalizza;

namespace Wpf_DandD
{
    
    public class MainViewModel : ViewModel
    {
        private static ObservableCollection<CreaPersonaggio> elenco;

        public MainViewModel()
        {
            if (elenco == null) elenco = new ObservableCollection<CreaPersonaggio>();
            _nuovoPersonaggio = new RelayCommand(NuovoPersonaggioRoutine);
            _personalizza = new RelayCommand(PersonalizzaRoutine);
        }

        public ObservableCollection<CreaPersonaggio> Elenco
        { get { return elenco; } set { elenco = value; OnPropertyChanged(nameof(Elenco)); } }

        private RelayCommand _nuovoPersonaggio;
        public RelayCommand NuovoPersonaggio
        { get { return _nuovoPersonaggio; } }

        private RelayCommand _personalizza;
        public RelayCommand Personalizza
        { get { return _personalizza; } }

        private void NuovoPersonaggioRoutine(object p)
        {
            NewCharacterView win2 = new NewCharacterView();
            win2.ShowDialog();
            
            elenco.Add(win2.VM.NuovoPersonaggio);
            
            OnPropertyChanged(nameof(Elenco));
        }

        private void PersonalizzaRoutine(object p)
        {
            PersonalizzaView win3 = new PersonalizzaView();
            win3.ShowDialog();

            elenco.Add(win3.VM.IsSelected);

            OnPropertyChanged(nameof(Elenco));
        }
    }
}