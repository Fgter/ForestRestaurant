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

        RegisterModel<ItemModel>(new ItemModel());
        RegisterModel<DataModel>(new DataModel());

    }
}
