using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseApi.Models
{
    public class Flat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int RoomCount { get; set; }
        public int ResidentCount { get; set; }
        public int LivingSpace { get; set; }
        public virtual House HouseResiding { get; set; }
    }
}
