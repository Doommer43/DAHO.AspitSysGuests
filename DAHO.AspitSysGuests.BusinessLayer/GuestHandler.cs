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

        public bool Add(Guest guest)
        {
            Model.Guests.Add(guest);
            return SaveChanges();
        }

        public bool Update(Guest guest)
        {
            var result = Model.Guests.Find(guest.Id);
            result = guest;
            return SaveChanges();
        }

        public bool Remove(Guest guest)
        {
            Model.Guests.Remove(guest);
            return SaveChanges();
        }
    }
}
