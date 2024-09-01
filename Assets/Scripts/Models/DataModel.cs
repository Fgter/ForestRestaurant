using QFramework;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Data;

namespace Models
{
    class DataModel : AbstractModel
    {
        public const string DataPath = "Data/Data/";
        protected override void OnInit()
        {
            Load();
        }

        public Dictionary<int, ItemDefine> ItemDefines = new Dictionary<int, ItemDefine>();
        public Dictionary<int, PlantDefine> PlantDefines = new Dictionary<int, PlantDefine>();

        void Load()
        {
            string json = File.ReadAllText(DataPath + "ItemDefine.txt");
            ItemDefines = JsonConvert.DeserializeObject<Dictionary<int, ItemDefine>>(json);
            json = File.ReadAllText(DataPath + "PlantDefine.txt");
            PlantDefines = JsonConvert.DeserializeObject<Dictionary<int, PlantDefine>>(json);
        }
    }
}
