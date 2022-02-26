using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyAPIProject.data;

namespace MyAPIProject.Models
{
    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }
    }

    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]

        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]

        public string ShortName { get; set; }
    }

}