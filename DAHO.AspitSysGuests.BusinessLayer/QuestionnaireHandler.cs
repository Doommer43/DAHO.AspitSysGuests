using DAHO.AspitSysGuests.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAHO.AspitSysGuests.BusinessLayer
{
    public class QuestionnaireHandler : BaseHandler
    {
        public List<Questionnaire> GetAllQuestionnares()
        {
            return Model.Questionnaires.ToList();
        }

        public Questionnaire GetActiveQuestionnaire()
        {
            return (Questionnaire)Model.Questionnaires.Where(q => q.IsActive == true);
        }

        public List<Question> GetQuestionnaireQuestions(Questionnaire questionnaire)
        {
            return Model.Questions.Where(q => q.QuestionaireId == questionnaire.Id).ToList();
        }

        public bool Add(Questionnaire questionnaire)
        {
            Model.Questionnaires.Add(questionnaire);
            return SaveChanges();
        }

        public bool Update(Questionnaire questionnaire)
        {
            var result = Model.Questionnaires.Find(questionnaire.Id);
            result = questionnaire;
            return SaveChanges();
        }

        public bool Remove(Questionnaire questionnaire)
        {
            Model.Questionnaires.Remove(questionnaire);
            return SaveChanges();
        }
    }
}
