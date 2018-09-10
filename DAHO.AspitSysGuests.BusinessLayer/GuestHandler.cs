using DAHO.AspitSysGuests.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAHO.AspitSysGuests.BusinessLayer
{
    public class GuestHandler : BaseHandler
    {
        public List<Guest> GetAllGuests()
        {
            return Model.Guests.ToList();
        }

        public Guest GetGuest(int id)
        {
            return Model.Guests.FirstOrDefault(g => g.Id == id);
        }

        public bool SaveGuest(Guest guest)
        {
            Model.
        }
    }
}
