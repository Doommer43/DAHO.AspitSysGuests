namespace DAHO.AspitSysGuests.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        public int Id { get; set; }

        [Column("Department")]
        [Required]
        public string Department1 { get; set; }

        public int Location { get; set; }

        public virtual Municipality Municipality { get; set; }
    }
}
