using System;

namespace WildLifeSpotter;
public class Observation
{
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public string Notes { get; set; }
    public Animal Animal { get; set; }
}
