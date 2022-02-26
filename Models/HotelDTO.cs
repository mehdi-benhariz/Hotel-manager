using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyAPIProject.data;

namespace MyAPIProject.Models
{
    public class HotelDTO : CreateCountryDTO
    {
        public int Id { get; set; }
        public Country Country { get; set; }

    }

    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }
        [Required]

        public string Adress { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public string Rating { get; set; }

        [Required]
        public int CountryId { get; set; }
    }

}