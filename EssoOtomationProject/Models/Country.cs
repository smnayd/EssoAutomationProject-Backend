using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EssoOtomationProject.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
       
    }
}
 