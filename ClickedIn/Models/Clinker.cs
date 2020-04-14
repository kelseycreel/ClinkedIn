using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public enum Services {
        Smuggling,
        HitMan,
        Escapee,
        Tattooist,
        Barber,
        Cook,
        PlayMate,
        Thief,
        Snitch,
        Negotiator
    }

    public class Interest
    {
        public string Name { get; set; }
    }
    public class Clinker
    {
        public int Id { get; set; }
        public string HoodName { get; set; }
        public Services ServiceType { get; set; }
        public List<Interest> Interests { get; set; }
        public List<Clinker> Homies { get; set; }
        public List<Clinker> Enemies { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
