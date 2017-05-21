namespace ComputerScienceTsu.Models.Generated
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subject
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Id_name { get; set; }

        public int? Lecturer_id { get; set; }

        public int? Course_id { get; set; }

        public int? Department_id { get; set; }

        public bool Is_mandatory { get; set; }

        public virtual CS_Departments CS_Departments { get; set; }

        public virtual Learning_Courses Learning_Courses { get; set; }

        public virtual Lecturer Lecturer { get; set; }
    }
}
