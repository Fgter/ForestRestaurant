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
        //UIManager.instance.ShowMessageTip("����һ����Ϣ");
        //UIManager.instance.ShowMessageTip("����һ����Ϣ").SetType(MessageType.Error);
        //UIManager.instance.ShowMessageTip("����һ����Ϣ").SetType(MessageType.Warning);
        //UIManager.instance.ShowMessageTip("����һ����Ϣ").SetType(MessageType.Finish);
        UIManager.instance.ShowMessageTip("����һ����Ϣ").SetIcon(ResLoader.LoadSprite("Feces")).AddFunction(() => {  Debug.Log("��ʾ"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
