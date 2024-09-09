using QFramework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class UIFoodMenu : UIWindowBase
{
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
    List<GameObject> UIFoodItems = new();
    [SerializeField]
    List<GameObject> UICanSelectMenus = new();
    public override void OnShow(IUIData showData)
    {
        ShowUpdate();
        Debug.Log("执行");
        this.RegisterEvent<UpdateFoodMenuUIEvent>(v => { ShowUpdate(); }).UnRegisterWhenGameObjectDestroyed(gameObject);
        Back.onClick.AddListener(() =>
        {
            if (CanSelectMenuRoot.activeInHierarchy)
            {
                CanSelectMenuRoot.SetActive(false);
                FoodMenu.SetActive(true);
            }
            else
            {
                CanSelectMenuRoot.SetActive(true);
                FoodMenu.SetActive(false);
            }
        });
    }
    void ShowUpdate()
    {
        RemoveAllFoodItem();
        foreach (var item in this.SendQuery(new GetCanSelectFoodMenuQuery(SelectMenu.CanSelectMenu)))
        {
            CreateFoodItem(item,SelectMenu.CanSelectMenu);
        }
        foreach (var item in this.SendQuery(new GetCanSelectFoodMenuQuery(SelectMenu.FoodMenu)))
        {
            CreateFoodItem(item, SelectMenu.FoodMenu);
        }
        Gold.text = $"预计收益：{this.GetModel<FoodMenuModel>().ExpectedGoldSum}";
    }
    void CreateFoodItem(FoodItem foodItem,SelectMenu selectMenu)
    {
        GameObject go;
        switch (selectMenu)
        {
            case SelectMenu.CanSelectMenu:
                go = Instantiate(UIFoodItemPrefab, CanSelectMenu.transform);
                go.GetComponent<UIFoodMenuItem>().SetFoodItem(foodItem, () => { this.SendCommand(new AddFoodCommand(foodItem.define.Id)); });
                UICanSelectMenus.Add(go);
                break;
            case SelectMenu.FoodMenu:
                go = Instantiate(UIFoodItemPrefab, FoodMenu.transform);
                go.GetComponent<UIFoodMenuItem>().SetFoodItem(foodItem, () => { this.SendCommand(new RemoveFoodCommand(foodItem.define.Id)); });
                UIFoodItems.Add(go);
                break;
        }
    }
    void RemoveAllFoodItem()
    {
        foreach (GameObject go in UIFoodItems)
        {
            Destroy(go);
        }
        foreach (GameObject go in UICanSelectMenus)
        {
            Destroy(go);
        }
        UIFoodItems.Clear();
        UICanSelectMenus.Clear();
    }
}
public enum SelectMenu
{
    CanSelectMenu,
    FoodMenu
}

