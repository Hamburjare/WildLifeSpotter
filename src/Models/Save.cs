using Newtonsoft.Json;
using Spectre.Console;

namespace WildLifeSpotter;

public class Save
{
    public string? Name { get; set; }
    public List<Observation> Observations { get; set; } = new();
    public List<Animal> Animals { get; set; } = new();

    public void LoadSave(string name) {
        var save = JsonConvert.DeserializeObject<Save>(File.ReadAllText($"saves/{name}.json"));
        Name = save.Name;
        Observations = save.Observations;
        Animals = save.Animals;
    }

    public void SaveSave() {
        var path = $"saves/{Name}.json";

        if (!Directory.Exists("saves")) {
            Directory.CreateDirectory("saves");
        }

        File.WriteAllText(path, JsonConvert.SerializeObject(this));
    }

    public List<string> ListSaves() {
        var saves = Directory.GetFiles("saves");
        
        return saves.Select(save => Path.GetFileNameWithoutExtension(save)).ToList();
    }
}