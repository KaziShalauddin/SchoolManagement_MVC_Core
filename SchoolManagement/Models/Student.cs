using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    // [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "varchar(10)")]
        [DisplayName("Reg. No.")]
        public string RegistrationNo { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Roll { get; set; }
    }
}
