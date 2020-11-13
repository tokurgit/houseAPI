using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseApi.Models
{
    public class House
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public virtual List<Flat> Flats { get; set; }

    }
}