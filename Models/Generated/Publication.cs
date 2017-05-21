namespace ComputerScienceTsu.Models.Generated
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Publication
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }

        public int? Lecturer_id { get; set; }

        public virtual Lecturer Lecturer { get; set; }
    }
}
