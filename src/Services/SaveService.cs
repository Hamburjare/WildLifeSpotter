using Newtonsoft.Json;
using WildLifeSpotter.Models;

namespace WildLifeSpotter.Services
{
    public class SaveService
    {
        public Save LoadSave(string name)
        {
            var save = JsonConvert.DeserializeObject<Save>(File.ReadAllText($"saves/{name}.json"));
            return save;
        }

        public void SaveSave(Save save)
        {
            var path = $"saves/{save.Name}.json";

            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(save));
        }

        public List<string> ListSaves()
        {
            var saves = Directory.GetFiles("saves");
            return saves.Select(save => Path.GetFileNameWithoutExtension(save)).ToList();
        }
    }
}