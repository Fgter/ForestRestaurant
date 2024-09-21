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
using UnityEngine.EventSystems;

public class Test : ViewController, IController
{
    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }
    [ContextMenu("Test4")]
    private void Test4()
    {
        this.SendCommand(new IncreaseGoldCommand(500));
    }
}
