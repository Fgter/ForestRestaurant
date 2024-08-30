using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
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
}
