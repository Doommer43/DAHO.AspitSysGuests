using DAHO.AspitSysGuests.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAHO.AspitSysGuests.BusinessLayer
{
    public class StatisticHandler : BaseHandler
    {
        public int TotalGuests()
        {
            return Model.Guests.ToList().Count;
        }

        public int TotalGuestsToDepartment(string department)
        {
            return Model.Guests.Where(g => g.Department.Name.ToLower() == department.ToLower()).ToList().Count;
        }

        public int TotalApplyingGuests()
        {
            return Model.Guests.Where(g => g.Applying == true).ToList().Count;
        }

        public int TotalApplyingGuestsToDepartment(string department)
        {
            return Model.Guests.Where(g => g.Department.Name.ToLower() == department.ToLower() && g.Applying == true).ToList().Count;
        }

        public (int, int) GetMinMaxGuestAge()
        {
            return (Min: Model.Guests.OrderByDescending(g => g.Age).FirstOrDefault().Age, Max: Model.Guests.OrderBy(g => g.Age).FirstOrDefault().Age);
        }

        public decimal GetAverageGuestAge()
        {
            return (decimal)Model.Guests.Average(g => g.Age);
        }

        public int GetTotalGuestFromDate(DateTime date)
        {
            return Model.Guests.Where(g => g.VisitTime.Year == date.Year && g.VisitTime.Month == date.Month).ToList().Count;
        }

        public int GetUniqueMunicipalities()
        {
            return Model.Guests.GroupBy(g => g.MunicipalityId).ToList().Count;
        }

        public int GetGuestsFromMunicipality(string municipality)
        {
            return Model.Guests.Where(g => g.Municipality.Name.ToLower() == municipality.ToLower()).ToList().Count;
        }
    }
}
