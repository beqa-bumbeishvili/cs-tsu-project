namespace ComputerScienceTsu.Models.Generated
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Lecturer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lecturer()
        {
            Publications = new HashSet<Publication>();
            Subjects = new HashSet<Subject>();
        }

        public int ID { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(2500)]
        public string About { get; set; }

        [StringLength(2500)]
        public string Additional_info { get; set; }

        public int? Photo_id { get; set; }

        [Required]
        [StringLength(2500)]
        public string Full_address { get; set; }

        public virtual Photo Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publication> Publications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
