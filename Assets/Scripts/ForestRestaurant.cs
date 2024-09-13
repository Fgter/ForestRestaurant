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
        RegisterUtility(new Storage());
        //Model
        RegisterModel(new DefineModel());
        RegisterModel(new ItemModel());
        RegisterModel(new PlantModel());
        RegisterModel(new FoodMenuModel());
        RegisterModel(new PlayerModel());
        RegisterModel(new ShopModel());
        //System
        RegisterSystem(new TimeSystem());
        RegisterSystem(new PlantingSystem());

    }
}
