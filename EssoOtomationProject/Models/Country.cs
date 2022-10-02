using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EssoOtomationProject.Models
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }

        [Required]
        public string CountryName { get; set; }
    }
}
