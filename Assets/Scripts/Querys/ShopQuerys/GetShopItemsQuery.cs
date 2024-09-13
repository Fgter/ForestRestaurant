using System.Collections.Generic;
using QFramework;
using Models;
using UnityEngine;

class GetShopItemsQuery : AbstractQuery<List<ShopItem>>
{
    int id;
    public GetShopItemsQuery(int shopId)
    {
        this.id = shopId;
    }
    protected override List<ShopItem> OnDo()
    {
        ShopModel model = this.GetModel<ShopModel>();
        List<ShopItem> result = new List<ShopItem>();
        if (model.shopItems.ContainsKey(id))
        {
            result.AddRange(model.shopItems[id].Values);
            return result;
        }
        Debug.LogError(string.Format("ShopModel中没有找到id为{0}的商店", id));
        return result;
    }
}
