using DAHO.AspitSysGuests.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAHO.AspitSysGuests.BusinessLayer
{
    public class MultiChoiceHandler : BaseHandler
    {
        public List<MultiChoice> GetAllMultiChoices()
        {
            return Model.MultiChoices.ToList();
        }

        public MultiChoice GetMultiChoice(int id)
        {
            return Model.MultiChoices.FirstOrDefault(q => q.Id == id);
        }

        public bool Add(MultiChoice MultiChoice)
        {
            Model.MultiChoices.Add(MultiChoice);
            return SaveChanges();
        }

        public bool Update(MultiChoice MultiChoice)
        {
            var result = Model.MultiChoices.Find(MultiChoice.Id);
            result = MultiChoice;
            return SaveChanges();
        }

        public bool Remove(MultiChoice MultiChoice)
        {
            Model.MultiChoices.Remove(MultiChoice);
            return SaveChanges();
        }
    }
}
