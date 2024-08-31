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
        UIManager.instance.ShowPop<UITest>(this.transform,false,3);
    }

    private void Start()
    {
        GetComponent<AnimationPlayer>().SetAnimation("Run");
    }
}
