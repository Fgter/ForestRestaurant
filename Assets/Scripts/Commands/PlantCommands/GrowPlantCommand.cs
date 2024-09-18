using Models;
using UnityEngine;
using QFramework;
using Define;

public class GrowPlantCommand : AbstractCommand<Plant>
{
    int id;
    PlantDefine plantDefine;
    Soil soil;
    GameObject prefab;
    Transform ts;
    public GrowPlantCommand(int id,Soil soil,GameObject prefab)
    {
        this.id = id;
        this.soil = soil;
        this.prefab = prefab;
        ts = soil.transform;
    }
    protected override Plant OnExecute()
    {
        plantDefine = this.SendQuery(new GetDefineQuery<PlantDefine>(id));
        GameObject go = GameObject.Instantiate(prefab,ts);
        Plant plant = go.GetComponent<Plant>();
        PlantEntityData plantEntityData = new PlantEntityData(plantDefine, soil.data);
        this.GetModel<PlantModel>().AddPlant(plantEntityData, soil.data.Id);
        plant.Init(plantEntityData, soil.data);
        soil.data.plant = plant.entityData;
        return plant;
    }
}
