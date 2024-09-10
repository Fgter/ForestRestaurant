using QFramework;
using System.Collections.Generic;

namespace Models
{
    class PlantModel : AbstractModel
    {
        public Dictionary<int, SoilEntityData> soils = new Dictionary<int, SoilEntityData>();
        public Dictionary<int, PlantEntityData> plants = new Dictionary<int, PlantEntityData>();//key为soil的id
        protected override void OnInit()
        {
          
        }

        public void AddPlant(PlantEntityData data, int soil)
        {
            plants[soil] = data;
        }

        public void RemovePlant(int soil)
        {
            if (plants.ContainsKey(soil))
                plants.Remove(soil);
        }
    }
}
