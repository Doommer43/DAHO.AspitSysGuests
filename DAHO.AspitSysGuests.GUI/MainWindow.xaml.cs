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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DAHO.AspitSysGuests.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QuestionnaireHandler QH = new QuestionnaireHandler();
        public MainWindow()
        {
            InitializeComponent();
            List<Questionnaire> questionnaires = QH.GetAllQuestionnares();
            CboxSelectQuestionnaire.ItemsSource = questionnaires;
        }

        private void BtnNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
