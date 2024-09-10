using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.instance.Show<UIFoodMenu>(null);
        //UIManager.instance.ShowMessageTip("这是一个消息");
        //UIManager.instance.ShowMessageTip("这是一个消息").SetType(MessageType.Error);
        //UIManager.instance.ShowMessageTip("这是一个消息").SetType(MessageType.Warning);
        //UIManager.instance.ShowMessageTip("这是一个消息").SetType(MessageType.Finish);
        UIManager.instance.ShowMessageTip("这是一个消息").SetIcon(ResLoader.LoadSprite("Feces")).AddFunction(() => {  Debug.Log("显示"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
