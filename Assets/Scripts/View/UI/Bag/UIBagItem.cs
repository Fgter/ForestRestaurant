using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIBagItem : MonoBehaviour
{
    [SerializeField]
    Image icon;
    [SerializeField]
    TextMeshProUGUI count;
    [SerializeField]
    TextMeshProUGUI Name;
    [SerializeField]
    TextMeshProUGUI description;
    public void SetItem(Item item,int count)
    {
        this.icon.overrideSprite = ResLoader.Load<Sprite>(PathConfig.SpritePath + item.define.Icon);
        this.count.text = count.ToString();
        this.Name.text = item.define.Name;
        this.description.text = item.define.Description;
    }
}
