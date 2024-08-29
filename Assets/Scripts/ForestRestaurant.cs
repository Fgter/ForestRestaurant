using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class ForestRestaurant : Architecture<ForestRestaurant>
{
    protected override void Init()
    {
        ResKit.Init();
    }
}
