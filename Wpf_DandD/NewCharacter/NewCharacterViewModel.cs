using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_DandD.Model;

namespace Wpf_DandD.NewCharacter
{
    public class NewCharacterViewModel : ViewModel
    {
        private CreaPersonaggio nuovoPersonaggio;

        public NewCharacterViewModel()
        {
            nuovoPersonaggio = new CreaPersonaggio();
            _confermaCommand = new RelayCommand(ConfermaRoutine);
        }

        public CreaPersonaggio NuovoPersonaggio
        { get { return nuovoPersonaggio; } set { nuovoPersonaggio = value; OnPropertyChanged(nameof(NuovoPersonaggio)); } }

        public string NuovoNome
        { get { return nuovoPersonaggio.Nome; } set { nuovoPersonaggio.Nome = value; OnPropertyChanged(nameof(NuovoNome)); } }
        public string NuovoCognome
        { get { return nuovoPersonaggio.Cognome; } set { nuovoPersonaggio.Cognome = value; OnPropertyChanged(nameof(NuovoCognome)); } }
        public int NuovoEta
        { get { return nuovoPersonaggio.Eta; } set { nuovoPersonaggio.Eta = value; OnPropertyChanged(nameof(NuovoEta)); } }
        public string NuovoSesso
        { get { return nuovoPersonaggio.Sesso; } set { nuovoPersonaggio.Sesso = value; OnPropertyChanged(nameof(NuovoSesso)); } }
        public string NuovoLuogoNascita
        { get { return nuovoPersonaggio.LuogoNascita; } set { nuovoPersonaggio.LuogoNascita = value; OnPropertyChanged(nameof(NuovoLuogoNascita)); } }
        
        public bool Valida(CreaPersonaggio item)
        {
            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                MessageBox.Show("Il campo nome è obbligatorio");
                return false;
            } 

            if (string.IsNullOrWhiteSpace(item.Cognome))
            {
                MessageBox.Show("Il campo congome è obbligatorio");
                return false;
            }

            if (item.Eta < 5)
            {
                MessageBox.Show("Inserire un età più elevata di quella digitata");
                return false;
            }
            return true;
        }

        private RelayCommand _confermaCommand;
        public RelayCommand ConfermaCommand
        { get { return _confermaCommand; } }

        private void ConfermaRoutine(object p)
        {
            if (Valida(NuovoPersonaggio))
            foreach (Window window in Application.Current.Windows)
            {
                if (window is NewCharacterView)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}