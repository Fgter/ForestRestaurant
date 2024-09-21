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
        UIManager.instance.Show<UIFoodMenu>(null); //ѡ��˵�
    }
    [ContextMenu("T2")]
    public void T2()
    {
        UIManager.instance.Show<UIMessageBoards>(null);//���԰�
    }
    [ContextMenu("T3")]
    public void T3()
    {
        UIManager.instance.Show<UICashRegister>(null);//����̨
    }
    [ContextMenu("ɾ��")]
    public void Delect()
    {
        Storage.RemoveAllSaves();
    }
    [ContextMenu("����ʳ��")]
    public void AddFood()
    {
        this.SendCommand(new UnlockFoodCommand(2001));
        this.SendCommand(new UnlockFoodCommand(2002));
        this.SendCommand(new UnlockFoodCommand(2003));
        this.SendCommand(new UnlockFoodCommand(2004));
        this.SendCommand(new UnlockFoodCommand(2005));
        this.SendCommand(new UnlockFoodCommand(2006));
    }
    [ContextMenu("���һ���ʱ��")]
    public void AddOneDay()
    {
        RestaurantSystem.AddTiem(86400);
    }
    // Start is called before the first frame update
    void Start()
    {
        //UIManager.instance.ShowMessageTip("����һ����Ϣ");
        //UIManager.instance.ShowMessageTip("����һ����Ϣ").SetType(MessageType.Error);
        //UIManager.instance.ShowMessageTip("����һ����Ϣ").SetType(MessageType.Warning);
        //UIManager.instance.ShowMessageTip("����һ����Ϣ").SetType(MessageType.Finish);
        //UIManager.instance.ShowMessageTip("����һ����Ϣ").SetIcon(ResLoader.LoadSprite("Feces")).AddFunction(() => {  Debug.Log("��ʾ"); });
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
