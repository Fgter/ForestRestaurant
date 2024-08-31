using QFramework;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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

        void Load()
        {
            string json = File.ReadAllText(DataPath + "ItemDefine.txt");
            ItemDefines = JsonConvert.DeserializeObject<Dictionary<int, ItemDefine>>(json);
        }
    }
}
