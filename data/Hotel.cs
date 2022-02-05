//create model Hotel
namespace MyAPIProject.data
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //add foreign   key to Country
        public int CountryId { get; set; }

    }
}
