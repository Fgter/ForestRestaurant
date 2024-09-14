using QFramework;
using System.Collections.Generic;
using Models;

class BuyItemCommond : AbstractCommand<bool>
{
    int shopId;
    int shopItemId;
    int count;
    public BuyItemCommond(int shopId, int shopItemId, int count)
    {
        this.shopId = shopId;
        this.shopItemId = shopItemId;
        this.count = count;
    }
    protected override bool OnExecute()
    {
        var shopItem = this.GetModel<ShopModel>().shopItemDict[shopId][shopItemId];
        int price = shopItem.define.Price * count;
        if (shopItem.count < count)
            return false;
        if (this.SendQuery(new GetGoldQuery()) < price)
            return false;
        shopItem.count -= count;
        this.SendCommand(new DecreaseGoldCommond(price));
        this.SendCommand(new AddItemCommond(shopItem.define.ItemId, count));
        return true;
    }
}
