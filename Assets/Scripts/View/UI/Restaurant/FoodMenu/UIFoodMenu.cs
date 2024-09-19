using Models;
using QFramework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIFoodMenu : UIWindowBase
{
    [SerializeField]
    Button Handoff;
    [SerializeField]
    Button Back;
    [SerializeField]
    TMP_Text Gold;
    [SerializeField]
    GameObject CanSelectMenu;
    [SerializeField]
    GameObject FoodMenu;
    [SerializeField]
    GameObject UIFoodItemPrefab;
    [SerializeField]
    GameObject CanSelectMenuRoot;
    [SerializeField]
    GameObject FoodMenuRoot;
    [SerializeField]
    List<UIFoodMenuItem> UIFoodItems = new();
    [SerializeField]
    List<UIFoodMenuItem> UICanSelectMenus = new();
    void Start()
    {
        this.RegisterEvent<UpdateFoodMenuUIEvent>(v =>
        {
            ShowUpdate();
        });
        Handoff.onClick.AddListener(() =>
        {
            if (CanSelectMenuRoot.activeInHierarchy)
            {
                CanSelectMenuRoot.SetActive(false);
                FoodMenuRoot.SetActive(true);
            }
            else
            {
                CanSelectMenuRoot.SetActive(true);
                FoodMenuRoot.SetActive(false);
            }
        });
        Back.onClick.AddListener(() =>
        {
            UIManager.instance.Close(typeof(UIFoodMenu));
        });
    }
    public override void OnShow(IUIData showData)
    {
        ShowUpdate();
    }
    void ShowUpdate()
    {
        UpdateList(SelectMenu.FoodMenu);
        UpdateList(SelectMenu.CanSelectMenu);
        Gold.text = $"预计收益：{this.SendQuery(new GetExpectedGoldQuery())}";
    }
    void CreateFoodItem(FoodItem foodItem,SelectMenu selectMenu)//仅用于添加没有的UI
    {
        GameObject go;
        UIFoodMenuItem ls;
        switch (selectMenu)
        {
            case SelectMenu.CanSelectMenu:
                go = Instantiate(UIFoodItemPrefab, CanSelectMenu.transform);
                ls = go.GetComponent<UIFoodMenuItem>();
                ls.SetFoodItem(foodItem, SelectCommand(foodItem,selectMenu));
                UICanSelectMenus.Add(ls);
                break;
            case SelectMenu.FoodMenu:
                go = Instantiate(UIFoodItemPrefab, FoodMenu.transform);
                ls = go.GetComponent<UIFoodMenuItem>();
                ls.SetFoodItem(foodItem, SelectCommand(foodItem, selectMenu));
                UIFoodItems.Add(ls);
                break;
        }
    }
    List<UIFoodMenuItem> ls;
    void UpdateList(SelectMenu selectMenu)
    {
        List<FoodItem> foodItems = this.SendQuery(new GetFoodMenuQuery(selectMenu));
        switch (selectMenu)
        {
            case (SelectMenu.FoodMenu):
                ls = UIFoodItems;
                break;
            case (SelectMenu.CanSelectMenu):
                ls = UICanSelectMenus;
                break;
        }
        if (foodItems.Count > ls.Count) //数量小于对应的Model则更新并添加新的对象
        {
            for (int i = 0; i < foodItems.Count; i++)
            {
                if (i>=ls.Count)
                {
                    CreateFoodItem(foodItems[i], selectMenu);
                    continue;
                }
                ls[i].gameObject.SetActive(true);
                ls[i].SetFoodItem(foodItems[i], SelectCommand(foodItems[i], selectMenu));
            }
        }
        else//数量大于对应的Model则仅设置对象的开关
        {
            for (int i = 0; i < ls.Count; i++)
            {
                if (i >= foodItems.Count)
                {
                    ls[i].gameObject.SetActive(false);
                    continue;
                }
                ls[i].gameObject.SetActive(true);
                ls[i].SetFoodItem(foodItems[i], SelectCommand(foodItems[i], selectMenu));
            }
        }
    }
    Action SelectCommand(FoodItem foodItem,SelectMenu selectMenu)
    {
        switch (selectMenu)
        {
            case (SelectMenu.FoodMenu):
                return () => { this.SendCommand(new RemoveFoodCommand(foodItem.define.Id)); };
            case (SelectMenu.CanSelectMenu):
                return () => { this.SendCommand(new AddFoodCommand(foodItem.define.Id)); };
            default:
                return () => { };
        }
        
    }
}
public enum SelectMenu
{
    CanSelectMenu,
    FoodMenu
}

