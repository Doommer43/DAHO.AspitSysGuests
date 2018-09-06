using DAHO.AspitSysGuests.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAHO.AspitSysGuests.BusinessLayer
{
    public class BaseHandler
    {
        private static AspitSysGuestsModel model = new AspitSysGuestsModel();
        protected AspitSysGuestsModel Model { get => model; }

        protected bool SaveChanges()
        {
            int rowsAffected = Model.SaveChanges();

            if(rowsAffected > 0)
            {
                return true;
            } return false;
        }
    }
}
