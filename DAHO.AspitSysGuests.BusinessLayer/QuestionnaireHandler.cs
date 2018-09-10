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
    }
}
