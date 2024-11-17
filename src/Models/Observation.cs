using System;

namespace WildLifeSpotter.Models
{
    public class Observation
    {
        public required string Location { get; set; }
        public required DateTime Date { get; set; }
        public string? Notes { get; set; }
        public required Animal Animal { get; set; }
    }
}

