using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Models;
using Define;
using SaveData;
using Newtonsoft.Json;
using System;
using UnityEngine.SceneManagement;

public class Test : ViewController,IController
{
    public GameObject prefab;
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
        UIManager.instance.Show<UIBag>(null);
    }
    private void OnMouseDown()
    {
        //GetComponent<Soil>().GrowPlant(1001);
        //UIManager.instance.Show<PopUIPlantInfo>(new PopUIPlantInfoData(GetComponent<Soil>().plant));
        //this.SendCommand<AddItemCommond>(new AddItemCommond(1, 10));
        //this.SendCommand<AddItemCommond>(new AddItemCommond(10001, 10));
        SceneLoader.instance.LoadSceneAsync("³óÍÃ×ÓµÄ²âÊÔ");
    }


    [ContextMenu("Test3")]
    private void Test3()
    {
        SceneLoader.instance.LoadSceneAsync("Test");
    }
    [ContextMenu("Test4")]
    private void Test4()
    {
       
    }

    
    private void Start()
    {
    }

}
