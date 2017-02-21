using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace SuperZEnt
{
    public class Stores
    {
        [Required]
        [Column(Name = "id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "name")]
        [Column(Name = "name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "address")]
        [Column(Name = "address")]
        public string address { get; set; }

    }
}
