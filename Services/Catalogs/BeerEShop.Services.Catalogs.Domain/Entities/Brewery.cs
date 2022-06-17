namespace BeerEShop.Services.Catalogs.Domain.Entities
{
    public class Brewery
    {
        public Brewery(string name) 
        {
            Name = name;
        }

        public long BreweryId { get; private set; }
        public string Name { get; private set; }

      
    }
}