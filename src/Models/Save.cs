using Newtonsoft.Json;
using Spectre.Console;

namespace WildLifeSpotter.Models
{
    public class Save
    {
        public string? Name { get; set; }
        public List<Observation> Observations { get; set; } = new();
        public List<Animal> Animals { get; set; } = new();
    }
}
