using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Models;
using Define;
using SaveData;
using Newtonsoft.Json;
using System;

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
        UIManager.instance.Show<UIBag>(null);
    }
    private void OnMouseDown()
    {
        //GetComponent<Soil>().GrowPlant(1001);
        //UIManager.instance.Show<PopUIPlantInfo>(new PopUIPlantInfoData(GetComponent<Soil>().plant));
        //this.SendCommand<AddItemCommond>(new AddItemCommond(1, 10));
        //this.SendCommand<AddItemCommond>(new AddItemCommond(10001, 10));
       
    }


    [ContextMenu("Test3")]
    private void Test3()
    {
        //TestSaveData data = new TestSaveData();
        //data.aaaa = true;
        //data.bbb.AddRange(new int[] { 1, 2, 3, 5, 6, 7, 8 });
        //data.ccc.Add(1001, new TestSaveData());
        //data.ccc.Add(1002, new TestSaveData());
        //data.ddd.Add(new Vector3(0, 0, 0));
        //data.ddd.Add(new Vector3(1, 0, 0));
        //data.ddd.Add(new Vector3(2, 0, 0));
        //data.ddd.Add(new Vector3(3, 0, 0));
        //this.GetUtility<Storage>().Save(data);
        TimeSpan t = new TimeSpan(1, 5, 10, 20);
        Debug.Log(string.Format( "{0}:{1}:{2} 后进入下一生长阶段", t.Days * 24 + t.Hours, t.Minutes, t.Seconds));
    }
    [ContextMenu("Test4")]
    private void Test4()
    {
        TestSaveData data = this.GetUtility<Storage>().Load<TestSaveData>();
        Debug.Log(data);
    }

    private void Start()
    {
    }

}
