using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf_DandD.NewCharacter;

namespace Wpf_DandD
{

    public partial class NewCharacterView
    {
        public NewCharacterView()
        {
            InitializeComponent();
            VM = new NewCharacterMainViewModel();
            this.DataContext = VM;
        }

        public NewCharacterMainViewModel VM;

        
    }
}
