using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class ClinkerProfile
    {
        public int Id { get; set; }
        public Clinker Clinker { get; set; }
        public List<Clinker> Homies { get; set; }
        public List<Clinker> Enemies { get; set; }
    }
}
