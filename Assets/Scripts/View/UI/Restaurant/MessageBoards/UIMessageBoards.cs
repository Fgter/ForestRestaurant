using QFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 留言板
/// </summary>
public class UIMessageBoards : UIWindowBase
{
    [SerializeField]
    RectTransform ShowSize;//显示范围的大小
    [SerializeField]
    GameObject Prefabs;//子物体显示的预制体
    [SerializeField]
    Transform Bg;//父对象
    [SerializeField]
    GameObject UIShowMessage;//UIShowMessage预制体
    [SerializeField]
    Button Back;//返回按钮
    [SerializeField]
    List<GameObject> list;//存储已经存在的对象
    UIShowMessage _UIShowMessage;
    void Start()
    {
        Back.onClick.AddListener(() =>
        {
            UIManager.instance.Close(typeof(UIMessageBoards));
        });
        this.RegisterEvent<UpdateMessageBoardsUIEvent>(v =>
        {
            UpdateShow();
        });
    }
    public override void OnShow(IUIData showData)
    {
        UpdateShow();
    }
    void UpdateShow()
    {
        int count = this.SendQuery(new GetFoodMnueAcclaimCountQuery());
        List<int> ls = this.SendQuery(new GetFoodMenuAcclaimQuery());
        Button bt;
        if (list.Count>=count)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(i>= count)
                {
                    list[i].SetActive(false);
                    continue;
                }
                list[i].SetActive(true);
                bt = list[i].GetComponent<Button>();
                bt.onClick.RemoveAllListeners();
                bt.onClick.AddListener(() =>
                {
                    PlayUIShowMessage(this.SendQuery(new GetAcclaimQuery(ls[i])),null);
                });
            }
        }
        else if(list.Count < count)
        {
            for (int i = 0; i < count; i++)
            {
                if (i >= list.Count)
                {
                    CreateUI(this.SendQuery(new GetAcclaimQuery(ls[i])), null);
                    continue;
                }
                list[i].SetActive(true);
                bt = list[i].GetComponent<Button>();
                bt.onClick.RemoveAllListeners();
                bt.onClick.AddListener(() =>
                {
                    PlayUIShowMessage(this.SendQuery(new GetAcclaimQuery(ls[i])), null);
                });
            }
        }
    }
    void CreateUI(string text,Sprite sprite)
    {
        
        Button go = Instantiate(Prefabs, Bg).GetComponent<Button>();
        go.transform.localPosition = new Vector2(UnityEngine.Random.Range(-(ShowSize.sizeDelta.x / 2),(ShowSize.sizeDelta.x / 2)), UnityEngine.Random.Range(-(ShowSize.sizeDelta.y / 2),(ShowSize.sizeDelta.y / 2)));
        go.onClick.AddListener(() =>
        {
            PlayUIShowMessage(text,sprite);
        });
        list.Add(go.gameObject);
    }
    void PlayUIShowMessage(string text,Sprite sprite)
    {
        if(_UIShowMessage == null)
        {
            _UIShowMessage = Instantiate(UIShowMessage,transform).GetComponent<UIShowMessage>();
        }
        _UIShowMessage.gameObject.SetActive(true);
        _UIShowMessage.Set(text,sprite);
    }
}
