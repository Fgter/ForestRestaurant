using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using QFramework;

public class UISeedBagItem : MonoBehaviour,IController
{
    [SerializeField]
    Image icon;
    [SerializeField]
    TextMeshProUGUI count;
    [SerializeField]
    TextMeshProUGUI Name;
    [SerializeField]
    TextMeshProUGUI description;
    [SerializeField]
    Button btn;

    UISeedBag owner;
    SeedItem item;

    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }

    public void SetItem(SeedItem item, int count,UISeedBag owner)
    {
        this.item = item;
        this.icon.overrideSprite = ResLoader.LoadSprite(this.item.define.Icon);
        this.count.text = count.ToString();
        this.Name.text = this.item.define.Name;
        this.description.text = this.item.define.Description;
        this.owner = owner;
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (owner.soil.GrowPlant(item.define.TargetPlant))
            this.SendCommand(new RemoveItemCommand(item.define.Id, 1));
        owner.HideNo();
    }
}
