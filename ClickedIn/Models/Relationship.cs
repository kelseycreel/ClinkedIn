using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Relationship
    {
        public int Id { get; set; }
        public Clinker FirstId { get; set; }
        public Clinker SecondId { get; set; }
        public bool isHomie { get; set; }
    }
}
