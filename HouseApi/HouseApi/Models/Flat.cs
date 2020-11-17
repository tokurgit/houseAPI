using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace HouseApi.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int RoomCount { get; set; }
        public int ResidentCount { get; private set; }
        public int LivingSpace { get; set; }
        public int HouseId { get; set; }
        [JsonIgnore]
        public virtual House House { get; set; }
        private List<Resident> Residents { get; set; }

        public Flat()
        { 
        }

        private Flat(HouseApiDbContext context)
        {
            Residents = context.Residents.Where(r => r.FlatId == Id).ToList();
            ResidentCount = Residents.Count;
        }
    }
}
