using QFramework;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Define;
using System;

namespace Models
{
    class DefineModel : AbstractModel
    {
        public const string DataPath = "Data/Data/";
        protected override void OnInit()
        {
            Load();
        }
        public Dictionary<Type, dynamic> allDefines = new Dictionary<Type, dynamic>();

        public Dictionary<int, PlantDefine> PlantDefines = new Dictionary<int, PlantDefine>();
        public Dictionary<int, SeedDefine> SeedDefines = new Dictionary<int, SeedDefine>();
        public Dictionary<int, HarvestDefine> HarvestDefines = new Dictionary<int, HarvestDefine>();

        void Load()
        {
            string json = File.ReadAllText(DataPath + "PlantDefine.txt");
            PlantDefines = JsonConvert.DeserializeObject<Dictionary<int, PlantDefine>>(json);
            allDefines.Add(typeof(PlantDefine), PlantDefines);
            json = File.ReadAllText(DataPath + "SeedDefine.txt");
            SeedDefines = JsonConvert.DeserializeObject<Dictionary<int, SeedDefine>>(json);
            allDefines.Add(typeof(SeedDefine), SeedDefines);
            json = File.ReadAllText(DataPath + "HarvestDefine.txt");
            HarvestDefines = JsonConvert.DeserializeObject<Dictionary<int, HarvestDefine>>(json);
            allDefines.Add(typeof(HarvestDefine), HarvestDefines);
        }
    }
}
