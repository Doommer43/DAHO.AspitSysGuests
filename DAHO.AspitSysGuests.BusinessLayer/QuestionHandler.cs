using DAHO.AspitSysGuests.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAHO.AspitSysGuests.BusinessLayer
{
    public class QuestionHandler : BaseHandler
    {
        public List<Question> GetAllQuestions()
        {
            return Model.Questions.ToList();
        }

        public Question GetQuestion(int id)
        {
            return Model.Questions.FirstOrDefault(q => q.Id == id);
        }

        public bool Add(Question question)
        {
            Model.Questions.Add(question);
            return SaveChanges();
        }

        public bool Update(Question question)
        {
            var result = Model.Questions.Find(question.Id);
            result = question;
            return SaveChanges();
        }

        public bool Remove(Question question)
        {
            Model.Questions.Remove(question);
            return SaveChanges();
        }
    }
}
