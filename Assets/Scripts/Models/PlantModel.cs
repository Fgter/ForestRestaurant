using QFramework;
using System.Collections.Generic;
using SaveData;
using Define;

namespace Models
{
    class PlantModel : AbstractModel
    {
        public Dictionary<int, SoilEntityData> soils = new Dictionary<int, SoilEntityData>();
        public Dictionary<int, PlantEntityData> plants = new Dictionary<int, PlantEntityData>();//key为soil的id
        protected override void OnInit()
        {
            InitSoil();
            Load();
            CommonMono.AddQuitAction(Save);
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

        void InitSoil()
        {
            var defines = this.SendQuery(new GetDefinesQuery<SoilDefine>());
            foreach (var define in defines)
            {
                soils[define.Id] = new SoilEntityData(define, define.UnlockStart);
            }
        }

        void Load()
        {
            SoilPlantSaveData data = this.GetUtility<Storage>().Load<SoilPlantSaveData>();
            if (data == default)
                return;

            foreach (var soil in data.soils)
            {
                soils[soil.Id].unlock = soil.unlock;
            }
            foreach (var kv in data.plants)
            {
                PlantEntityData p = new PlantEntityData();
                p.Load(kv.Value, this.SendQuery(new GetDefineQuery<PlantDefine>(kv.Value.id)));
                plants[kv.Key] = p;
                soils[kv.Key].plant = p;
                p.Grow(this.SendQuery(new GetOfflinePeriodQuery()));
            }
        }

        void Save()
        {
            SoilPlantSaveData plantsSaveData = new SoilPlantSaveData();
            foreach (var s in soils)
            {
                SoilSaveData soilSaveData = new SoilSaveData();
                soilSaveData.Id = s.Key;
                soilSaveData.unlock = s.Value.unlock;
                plantsSaveData.soils.Add(soilSaveData);
            }
            foreach (var p in plants)
            {
                PlantSaveData plantSaveData = new PlantSaveData();
                plantSaveData.id = p.Value.define.Id;
                plantSaveData.growedTime = TimeConverter.DayToSecond(p.Value.growedTime);
                plantSaveData.season = p.Value.season;
                plantSaveData.currentStage = p.Value.currentStage;
                plantsSaveData.plants.Add(p.Key, plantSaveData);
            }
            this.GetUtility<Storage>().Save(plantsSaveData);
        }
    }
}
