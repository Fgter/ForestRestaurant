using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Data;

public class GrowPlantCommond : AbstractCommand<Plant>
{
    int id;
    PlantDefine plantDefine;
    Soil soil;
    GameObject prefab;
    Transform ts;
    public GrowPlantCommond(int id,Soil soil,GameObject prefab)
    {
        this.id = id;
        this.soil = soil;
        this.prefab = prefab;
        ts = soil.transform;
    }
    protected override Plant OnExecute()
    {
        plantDefine = this.SendQuery(new GetPlantDefineQuery(id));
        GameObject go = GameObject.Instantiate(prefab,ts);
        Plant plant = go.GetComponent<Plant>();
        PlantEntityData plantEntityData = new PlantEntityData(plantDefine, soil);
        this.GetSystem<PlantingSystem>().AddPlant(plantEntityData, soil);
        plant.Init(plantEntityData, soil);
        return plant;
    }
}
