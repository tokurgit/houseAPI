using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HouseApi.Models
{
    public class House
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        [JsonIgnore]
        public List<Flat> Flats { get; set; }

        public House()
        {
        }

        private House(HouseApiDbContext context)
        {
            Flats = context.Flats.Where(f => f.HouseId == Id).ToList();
        }
    }
}