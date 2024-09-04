using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Models;

public class Test : ViewController,IController
{
    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }

    [ContextMenu("Test")]
    public void test()
    {
        this.SendQuery(new GetItemQuery<SeedItem>(3));
    }

    private void OnMouseDown()
    {
        GetComponent<Soil>().GrowPlant(1);
        //UIManager.instance.Show<PopUIPlantInfo>(new PopUIPlantInfoData(GetComponent<Soil>().plant));
    }

    private void Start()
    {
        this.GetModel<ItemModel>();
    }
}
