namespace DAHO.AspitSysGuests.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Answer
    {
        public int Id { get; set; }

        public int GuestId { get; set; }

        public int QuestionId { get; set; }

        [Required]
        public string Response { get; set; }

        public virtual Guest Guest { get; set; }

        public virtual Question Question { get; set; }
    }
}
