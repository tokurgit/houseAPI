using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseApi.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long PhoneNumber { get; set; }
        public string EMail { get; set; }
        public int FlatId { get; set; }
        public virtual Flat Flat{ get; set; }
    }
}