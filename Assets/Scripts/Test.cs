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

    public void test()
    {
        //var ui= UIManager.instance.Show<UITest>();
        //ui.aaaa();
        UIManager.instance.ShowPop<UITest>(this.transform,true,3);

       
    }

    private void OnMouseDown()
    {
        GetComponent<Soil>().GrowPlant(1);
    }

    private void Start()
    {
        this.GetModel<DataModel>();
    }
}
