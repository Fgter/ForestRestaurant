using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Define;
using SaveData;

public class PlantingSystem : AbstractSystem 
{
    Dictionary<Soil, PlantEntityData> plants = new Dictionary<Soil, PlantEntityData>();
    Dictionary<int, Soil> soil = new Dictionary<int, Soil>();
    protected override void OnInit()
    {
        TimeSystem.AddSecondUpdateAction(Grow);
        CommonMono.AddQuitAction(Save);
        Load();
    }

    void Grow()
    {
        foreach(var plant in plants.Values)
        {
            plant.Grow();
        }
    }

    public void AddPlant(PlantEntityData data,Soil soil)
    {
        plants[soil] = data;
    }

    void Save()
    {
        SoilPlantSaveData plantsSaveData = new SoilPlantSaveData();
        foreach(var p in this.plants)
        {
            PlantSaveData plantSaveData = new PlantSaveData();
            plantSaveData.id = p.Value.define.Id;
            plantSaveData.growedTime = TimeConverter.DayToSecond( p.Value.growedTime);
            plantSaveData.season = p.Value.season;
            plantSaveData.currentStage = p.Value.currentStage;
            plantsSaveData.plants.Add(p.Key.Id, plantSaveData);
        }
        this.GetUtility<Storage>().Save(plantsSaveData);
    }

    void Load()
    {
        GameObject prefab = ResLoader.Load<GameObject>(PathConfig.PrefabPath + "Plant");
        SoilPlantSaveData data = this.GetUtility<Storage>().Load<SoilPlantSaveData>();
        if (data == default)
            return;
        foreach(var plant in data.plants.Values)
        {
            PlantEntityData p = new PlantEntityData();
            p.Load(plant, this.SendQuery(new GetDefineQuery<PlantDefine>(plant.id)));
            p.Grow(1);
            plants.Add(new Soil(), p);///////////
            GameObject go= GameObject.Instantiate(prefab);
            go.GetComponent<Plant>().Init(p, null);
        }
    }
}
