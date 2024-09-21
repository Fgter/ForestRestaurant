using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Test2 : MonoBehaviour,IPointerClickHandler, IController
{
    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }
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
    [ContextMenu("删档")]
    public void Delect()
    {
        Storage.RemoveAllSaves();
    }
    [ContextMenu("解锁食物")]
    public void AddFood()
    {
        this.SendCommand(new UnlockFoodCommand(2001));
        this.SendCommand(new UnlockFoodCommand(2002));
        this.SendCommand(new UnlockFoodCommand(2003));
        this.SendCommand(new UnlockFoodCommand(2004));
        this.SendCommand(new UnlockFoodCommand(2005));
        this.SendCommand(new UnlockFoodCommand(2006));
    }
    [ContextMenu("添加一天的时间")]
    public void AddOneDay()
    {
        RestaurantSystem.AddTiem(86400);
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
