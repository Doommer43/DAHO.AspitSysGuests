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
        AdminHandler AH = new AdminHandler();
        private Questionnaire questionnaire;
        private Admin currentAdmin;
        public MainWindow()
        {
            InitializeComponent();
            CboxSelectQuestionnaire.ItemsSource = QH.GetAllQuestionnares();
        }

        private void BtnNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            CreateQuestion qw = new CreateQuestion();
            qw.ShowDialog();
            if(qw.DialogResult == true)
            {
                questionnaire.Questions.Add(new Question() { Question1 = qw.TboxQuestion.Text, Questionnaire = questionnaire });
            }
        }

        private void BtnCreateQuestionnaire_Click(object sender, RoutedEventArgs e)
        {
            questionnaire = new Questionnaire() { Title = TboxQuestionnaireTitle.Text };
        }

        private void BtnQuestionnaireSubmit_Click(object sender, RoutedEventArgs e)
        {
            questionnaire.Admin = new Admin() { Id = currentAdmin.Id, Username = currentAdmin.Username, Password = currentAdmin.Password, Questionnaires = currentAdmin.Questionnaires };
            QH.Add(questionnaire);
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            currentAdmin = AH.LoginAdmin(TboxUsername.Text, TboxPassword.Text);
            TblockCurrentUser.Text = currentAdmin.Username;
        }
    }
}
