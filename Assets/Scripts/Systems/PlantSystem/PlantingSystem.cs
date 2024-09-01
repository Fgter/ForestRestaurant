using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class PlantingSystem : AbstractSystem //Plant内部更新都以秒为单位，外部更新都以天为单位
{
    Dictionary<Soil, PlantEntityData> plants = new Dictionary<Soil, PlantEntityData>();
    protected override void OnInit()
    {
        TimeSystem.AddSecondUpdateAction(Grow);
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
}
