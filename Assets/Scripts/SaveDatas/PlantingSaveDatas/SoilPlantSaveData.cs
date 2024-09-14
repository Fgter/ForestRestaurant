using System.Collections.Generic;

namespace SaveData
{
    class SoilPlantSaveData
    {
        public Dictionary<int, PlantSaveData> plants = new Dictionary<int, PlantSaveData>();//key为soil的id
        public List<SoilSaveData> soils = new List<SoilSaveData>();
    }
}
