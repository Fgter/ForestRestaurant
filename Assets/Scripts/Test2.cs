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
