using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace SuperZEnt
{
    public class Articles
    {
        [Required]
        [Column(Name = "id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [Column(Name = "name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "description")]
        [Column(Name = "description")]
        public string description { get; set; }

        [Required]
        [Display(Name = "price")]
        [Column(Name = "price")]
        public int price { get; set; }

        [Required]
        [Display(Name = "total_in_shelf")]
        [Column(Name = "total_in_shelf")]
        public int total_in_shelf { get; set; }

        [Required]
        [Display(Name = "total_in_vault")]
        [Column(Name = "total_in_vault")]
        public int total_in_vault { get; set; }

        [Required]
        [Display(Name = "store_id")]
        [Column(Name = "store_id")]
        public int store_id { get; set; }
    }
}
