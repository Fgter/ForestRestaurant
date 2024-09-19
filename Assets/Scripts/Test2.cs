using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Test2 : MonoBehaviour,IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData eventData)
    {
        
       
        
    }

    [ContextMenu("T1")]
    public void T1()
    {
        UIManager.instance.Show<UIFoodMenu>(null); //选择菜单
    }
    [ContextMenu("T2")]
    public void T2()
    {
        UIManager.instance.Show<UIMessageBoards>(null);//留言板
    }
    [ContextMenu("T3")]
    public void T3()
    {
        UIManager.instance.Show<UICashRegister>(null);//收银台
    }
    // Start is called before the first frame update
    void Start()
    {
        //UIManager.instance.ShowMessageTip("这是一个消息");
        //UIManager.instance.ShowMessageTip("这是一个消息").SetType(MessageType.Error);
        //UIManager.instance.ShowMessageTip("这是一个消息").SetType(MessageType.Warning);
        //UIManager.instance.ShowMessageTip("这是一个消息").SetType(MessageType.Finish);
        //UIManager.instance.ShowMessageTip("这是一个消息").SetIcon(ResLoader.LoadSprite("Feces")).AddFunction(() => {  Debug.Log("显示"); });
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
