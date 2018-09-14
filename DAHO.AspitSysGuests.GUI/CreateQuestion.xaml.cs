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
        MultiChoice mc = new MultiChoice();
        Question q;
        public CreateQuestion()
        {
            InitializeComponent();
        }

        private void BtnNewMultiChoice_Click(object sender, RoutedEventArgs e)
        {
            if (ChkBoxIsMulti.IsChecked == true)
            {
                mc.Answer = TboxNewMultiChoice.Text;
                q.MultiChoices.Add(mc);
            }        
        }

        private void BtnNewQuestion_Click(object sender, RoutedEventArgs e)
        {
           q  = new Question() { Question1 = TboxQuestion.Text };
        }

        private void BtnSaveQuestion_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
