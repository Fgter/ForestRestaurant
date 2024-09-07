using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;


class UISeedBagData:IUIData
{
    public Soil soil;
    public UISeedBagData(Soil s)
    {
        soil = s;
    }
}
public class UISeedBag : UIWindowBase
{
    [SerializeField]
    GameObject seedBagItemPrefab;
    [SerializeField]
    Transform content;

    List<UISeedBagItem> seedBagItems = new List<UISeedBagItem>();
    public Soil soil { get; set; }

    public override void OnShow(IUIData showData)
    {
        soil = (showData as UISeedBagData)?.soil;
        Refresh(); 
    }
    void Refresh()
    {
        List<SeedItem> items = this.SendQuery(new GetItemsQuery<SeedItem>());
        bool bagItemEnough = seedBagItems.Count >= items.Count;
        if (bagItemEnough)
        {
            int temp = 0;
            for (; temp < items.Count; temp++)
            {
                seedBagItems[temp].SetItem(items[temp], items[temp].count,this);
                seedBagItems[temp].gameObject.SetActive(true);

            }
            for (; temp < seedBagItems.Count; temp++)
            {
                seedBagItems[temp].gameObject.SetActive(false);
            }
        }
        else
        {
            int temp = 0;
            for (; temp < seedBagItems.Count; temp++)
            {
                seedBagItems[temp].SetItem(items[temp], items[temp].count,this);
            }
            for (; temp < items.Count; temp++)
            {
                CreateBagItem(items[temp], items[temp].count);
            }
        }
    }

    void CreateBagItem(SeedItem item, int count)
    {
        GameObject go = GameObject.Instantiate(seedBagItemPrefab, content);
        UISeedBagItem bagItem = go.GetComponent<UISeedBagItem>();
        bagItem.SetItem(item, count,this);
        seedBagItems.Add(bagItem);
    }
}
