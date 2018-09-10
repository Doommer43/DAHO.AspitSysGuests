using DAHO.AspitSysGuests.BusinessLayer;
using DAHO.AspitSysGuests.DAL.EF;
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

namespace DAHO.AspitSysGuests.GUI
{
    /// <summary>
    /// Interaction logic for CreateQuestion.xaml
    /// </summary>
    public partial class CreateQuestion : Window
    {
        List<string> choiceList = new List<string>();
        Question q;
        public CreateQuestion()
        {
            InitializeComponent();
        }

        private void BtnNewMultiChoice_Click(object sender, RoutedEventArgs e)
        {
            if(ChkBoxIsMulti.IsChecked == true)
            choiceList.Add(TboxNewMultiChoice.Text);
        }

        private void BtnNewQuestion_Click(object sender, RoutedEventArgs e)
        {
           q  = new Question() { Question1 = TboxQuestion.Text };
        }

        private void BtnSaveQuestion_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
