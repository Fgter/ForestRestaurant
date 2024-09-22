using QFramework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIFoodMenuItem :MonoBehaviour, IController,IPointerClickHandler
{
    [SerializeField]
    Image icon;
    [SerializeField]
    TMP_Text description;
    [SerializeField]
    TMP_Text Name;
    [SerializeField]
    GameObject SuppliesList;
    [SerializeField]
    GameObject UIFoodSuppliesPrefab;
    [SerializeField]
    List<UIFoodMenuItemItem> SuppliesListPrefabs = new();
    Action action;
    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        action?.Invoke();
    }

    public void SetFoodItem(FoodItem foodItem,Action action = null)
    {
        icon.sprite = ResLoader.LoadSprite(foodItem.define.Icon);//加载当前食物的图片
        description.text = foodItem.define.Description;//加载当前食物的描述
        Name.text = foodItem.define.Name;//加载当前食物的名称
        if (SuppliesListPrefabs.Count< foodItem.define.Supplies.Count)
        {
            for (int i = 0; i < foodItem.define.Supplies.Count; i++)
            {
                if (SuppliesListPrefabs.Count <= i)
                {
                    CreateSupplies(foodItem.define.Supplies[i], foodItem.define.Sum[i]);
                    continue;
                }
                SetSupplies(SuppliesListPrefabs[i], foodItem.define.Supplies[i], foodItem.define.Sum[i]);
                SuppliesListPrefabs[i].gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < SuppliesListPrefabs.Count; i++)
            {
                if (foodItem.define.Supplies.Count <= i)
                {
                    SuppliesListPrefabs[i].gameObject.SetActive(false);
                    continue;
                }
                SetSupplies(SuppliesListPrefabs[i], foodItem.define.Supplies[i], foodItem.define.Sum[i]);
                SuppliesListPrefabs[i].gameObject.SetActive(true);
            }
        }
        this.action = action;
    }
    void CreateSupplies(int Id,int sum)
    {
        UIFoodMenuItemItem go = Instantiate(UIFoodSuppliesPrefab, SuppliesList.transform).GetComponent<UIFoodMenuItemItem>();
        SetSupplies(go, Id,sum);
        SuppliesListPrefabs.Add(go);
    }
    void SetSupplies(UIFoodMenuItemItem go, int id,int sum)
    {
        string name = this.SendCommand(new CreateItemCommand(id)).Icondefine.Icon;
        if (name.Equals(""))
        {
            go.Set($"X{sum}", ResLoader.Load<Sprite>(PathConfig.SpritePath + "Feces"));
            return;
        }
        go.Set($"X{sum}", ResLoader.Load<Sprite>(PathConfig.SpritePath + name));
    }
}

