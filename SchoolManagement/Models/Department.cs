using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Column(TypeName = "varchar(10)")]
        [DisplayName("Code")]
        public string Code { get; set; }

        public IEnumerable<Student> Students { get; set; }
    }
}
