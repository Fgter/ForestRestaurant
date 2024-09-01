using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Data;
using Models;

public class GetPlantDefineQuery : AbstractQuery<PlantDefine>
{
    int id;
    public GetPlantDefineQuery(int id)
    {
        this.id = id;
    }
    protected override PlantDefine OnDo()
    {
        DataModel model = this.GetModel<DataModel>();
        if (model.PlantDefines.ContainsKey(id))
        {
            return model.PlantDefines[id];
        }
        else
        {
            Debug.LogError("Plant id:" + id + " is not in PlantDefines");
            return default;
        }
    }
}
