using QFramework;
using Define;
using SaveData;
using Models;

public class PlantingSystem : AbstractSystem
{
    PlantModel _model;
    protected override void OnInit()
    {
        _model = this.GetModel<PlantModel>();
        TimeSystem.AddSecondUpdateAction(Grow);
        CommonMono.AddQuitAction(Save);
        InitSoil();
        Load();
    }

    void Grow()
    {
        foreach (var plant in _model.plants.Values)
        {
            plant.Grow();
        }
    }

    void InitSoil()
    {
        var defines = this.SendQuery(new GetDefinesQuery<SoilDefine>());
        foreach (var define in defines)
        {
            _model.soils[define.Id] = new SoilEntityData(define, define.UnlockStart);
        }
    }

    void Save()
    {
        SoilPlantSaveData plantsSaveData = new SoilPlantSaveData();
        foreach (var s in _model.soils)
        {
            SoilSaveData soilSaveData = new SoilSaveData();
            soilSaveData.Id = s.Key;
            soilSaveData.unlock = s.Value.unlock;
            plantsSaveData.soils.Add(soilSaveData);
        }
        foreach (var p in _model.plants)
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

    void Load()
    {
        SoilPlantSaveData data = this.GetUtility<Storage>().Load<SoilPlantSaveData>();
        if (data == default)
            return;

        foreach (var soil in data.soils)
        {
            _model.soils[soil.Id].unlock = soil.unlock;
        }
        foreach (var kv in data.plants)
        {
            PlantEntityData p = new PlantEntityData();
            p.Load(kv.Value, this.SendQuery(new GetDefineQuery<PlantDefine>(kv.Value.id)));
            _model.plants[kv.Key] = p;
            _model.soils[kv.Key].plant = p;
            p.Grow(this.GetSystem<TimeSystem>().GetOfflinePeriod());
        }
    }
}
