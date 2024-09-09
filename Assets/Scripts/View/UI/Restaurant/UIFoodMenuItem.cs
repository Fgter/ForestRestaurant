using System;
using QFramework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class UIFoodMenuItem :MonoBehaviour, IController,IPointerClickHandler
{
    [SerializeField]
    Image icon;
    [SerializeField]
    TMP_Text description;
    [SerializeField]
    TMP_Text name;
    [SerializeField]
    GameObject SuppliesList;
    [SerializeField]
    GameObject UIFoodSuppliesPrefab;
    [SerializeField]
    List<GameObject> SuppliesListPrefabs = new();
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
        icon.sprite = ResLoader.Load<Sprite>(PathConfig.SpritePath+foodItem.define.Icon);
        description.text = foodItem.define.Description;
        name.text = foodItem.define.Name;
        for (int i = 0;i<foodItem.define.Supplies.Count;i++)
        {
            CreateSupplies(foodItem.define.Supplies[i], foodItem.define.Sum[i]);
        }
        this.action = action;
    }
    void CreateSupplies(int Id,int sum)
    {
        GameObject go = Instantiate(UIFoodSuppliesPrefab, SuppliesList.transform);
        //Item a = this.SendQuery(new GetItemQuery<Item>(Id));//这里暂时这样写
        go.transform.GetChild(0).GetComponent<Image>().sprite = ResLoader.Load<Sprite>(PathConfig.SpritePath + "Pineapple");
        go.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = $"X{sum}";
        SuppliesListPrefabs.Add(go);
    }
}

