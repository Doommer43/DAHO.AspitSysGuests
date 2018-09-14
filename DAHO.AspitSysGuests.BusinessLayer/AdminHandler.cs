using DAHO.AspitSysGuests.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAHO.AspitSysGuests.BusinessLayer
{
    public class AdminHandler : BaseHandler
    {
        public Admin LoginAdmin(string name, string password)
        {
            return Model.Admins.Where(a => a.Username == name && a.Password == password).ToList().FirstOrDefault();
        }
    }
}
