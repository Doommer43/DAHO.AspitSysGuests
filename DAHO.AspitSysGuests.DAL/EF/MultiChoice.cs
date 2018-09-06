namespace DAHO.AspitSysGuests.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MultiChoice
    {
        public int Id { get; set; }

        [Required]
        public string Answer { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
