using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EssoOtomationProject.Models
{
    [Table("Cities")]
    public class City
    {
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }
    }
}
