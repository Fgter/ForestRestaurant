using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Models;

public class ForestRestaurant : Architecture<ForestRestaurant>
{
    protected override void Init()
    {
        ResKit.Init();
        //Utility
        RegisterUtility<Storage>(new Storage());
        //Model
        RegisterModel<DefineModel>(new DefineModel());
        RegisterModel<ItemModel>(new ItemModel());
        RegisterModel<FoodMenuModel>(new FoodMenuModel());
        //System
        RegisterSystem<TimeSystem>(new TimeSystem());
        RegisterSystem<PlantingSystem>(new PlantingSystem());

    }
}
