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
    public class NewCharacterMainViewModel : ViewModel
    {
        private CreaPersonaggio nuovoPersonaggio;


        public NewCharacterMainViewModel()
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
        public void Valida(CreaPersonaggio item)
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

        public bool IsOk
        { get; set; }



        private RelayCommand _confermaCommand;
        public RelayCommand ConfermaCommand
        { get { return _confermaCommand; } }

        private void ConfermaRoutine(object p)
        {
            Valida(NuovoPersonaggio);
            IsOk = true;
            
            //if (p is Window)
            //{
            //    MainView mainView = new MainView();
            //    mainView.Show();
            //    (p as Window).Close();
            //}

        }
    }
}
