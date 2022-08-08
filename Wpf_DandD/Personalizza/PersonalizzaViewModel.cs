using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Wpf_DandD.Model;

namespace Wpf_DandD.Personalizza
{

    public class PersonalizzaViewModel : ViewModel
    {
        private ObservableCollection<CreaPersonaggio> elenco;
        private MainViewModel vm;
        private static ObservableCollection<CreaPersonaggio> modificazioni;

        public PersonalizzaViewModel()
        {
            vm = new MainViewModel();
            elenco = new ObservableCollection<CreaPersonaggio>();
            elenco = vm.Elenco;
            modificazioni = new ObservableCollection<CreaPersonaggio>();
            modificazioni = elenco;
            _elimina = new RelayCommand(EliminaRoutine);
            _modifica = new RelayCommand(ModificaRoutine);
            _annulla = new RelayCommand(AnnullaRoutine);
            _conferma = new RelayCommand(ConfermaRoutine);  
        }

        public ObservableCollection<CreaPersonaggio> Elenco
        { get { return elenco; } set { elenco = value; OnPropertyChanged(nameof(Elenco)); } }

        public ObservableCollection <CreaPersonaggio> Modificazioni
        { get { return modificazioni; } set { modificazioni = value; OnPropertyChanged(nameof(Modificazioni)); } }

        private CreaPersonaggio _isSelected;
        public CreaPersonaggio IsSelected
        { get { return _isSelected; } set { _isSelected = value; OnPropertyChanged(nameof(IsSelected)); } }

        private bool _readOnly = true;
        public bool ReadOnly 
        { get { return _readOnly; } set { _readOnly = value; OnPropertyChanged(nameof(ReadOnly)); } }

        private RelayCommand _elimina;
        public RelayCommand Elimina
        { get { return _elimina; } set { _elimina = value; OnPropertyChanged(nameof(Elimina)); } }

        private RelayCommand _modifica;
        public RelayCommand Modifica
        { get { return _modifica; } set { _modifica = value; OnPropertyChanged(nameof(Modifica)); } }

        private RelayCommand _annulla;
        public RelayCommand Annulla
        { get { return _annulla; } set { _annulla = value;} }

        private RelayCommand _conferma;
        public RelayCommand Conferma
        { get { return _conferma; } set { _conferma = value; OnPropertyChanged(nameof(Conferma)); } }

        private void EliminaRoutine(object e)
        {   
            elenco.Remove(IsSelected);
        }

        private void ModificaRoutine(object e)
        {
            ReadOnly = !ReadOnly;
        }

        private void AnnullaRoutine (object e)
        {


            
            foreach (Window window in Application.Current.Windows)
            {
                if (window is PersonalizzaView)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void ConfermaRoutine(object e)
        {
          


            foreach (Window window in Application.Current.Windows)
            {
                if (window is PersonalizzaView)
                {
                    window.Close();
                    break;
                }
            }
        }



    }
}
