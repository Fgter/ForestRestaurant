using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Models;
using Define;

public class Test : ViewController,IController
{
    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }

    [ContextMenu("Test")]
    public void test()
    {
        //this.SendQuery(new GetItemQuery<SeedItem>(3));
        //UIManager.instance.Show<UIBag>(null);
        this.SendCommand<AddItemCommond>(new AddItemCommond(1, 10));
        this.SendCommand<AddItemCommond>(new AddItemCommond(2, 10)); 
    }

    [ContextMenu("Test2")]
    public void test2()
    {
        UIManager.instance.Show<UISeedBag>(null);
    }
    private void OnMouseDown()
    {
        //GetComponent<Soil>().GrowPlant(1001);
        //UIManager.instance.Show<PopUIPlantInfo>(new PopUIPlantInfoData(GetComponent<Soil>().plant));
        //this.SendCommand<AddItemCommond>(new AddItemCommond(1, 10));
        //this.SendCommand<AddItemCommond>(new AddItemCommond(10001, 10));
       
    }

    private void Start()
    {
        this.GetModel<ItemModel>();
    }
}
