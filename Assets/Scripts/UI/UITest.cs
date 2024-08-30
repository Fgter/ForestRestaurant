using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    class UITest:UIWindowBase
    {
    public override void OnInit()
    {
        base.OnInit();
        Debug.Log("OnInit");
    }
    public void aaaa()
    {
        Debug.Log("aaaaaa");
    }
}

