using System;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public virtual Flat Flat { get; set; }
    }
}