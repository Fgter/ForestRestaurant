using QFramework;
using Models;
using SaveData;
using System.Collections.Generic;
using Define;
public class ShopSystem : AbstractSystem
{
    ShopModel _model;
    TimeSystem _timeSystem;
    protected override void OnInit()
    {
        _model = this.GetModel<ShopModel>();
        CommonMono.AddQuitAction(Save);
        Load();
    }


    void Save()
    {
        ShopSaveData shopData = new ShopSaveData();
        shopData.shopItemDict = new Dictionary<int, Dictionary<int, ShopItemSaveData>>();
        shopData.shopItemList = new List<ShopItemSaveData>();
        foreach(var shop in _model.shopItemDict)
        {
            shopData.shopItemDict[shop.Key] = new Dictionary<int, ShopItemSaveData>();
            foreach(var item in shop.Value)
            {
                ShopItemSaveData data = new ShopItemSaveData();
                data.count = item.Value.count;
                data.status = item.Value.status;
                shopData.shopItemDict[shop.Key][item.Key] = data;
                shopData.shopItemList.Add(data);
            }
        }
        this.GetUtility<Storage>().Save<ShopSaveData>(shopData);
    }
    void Load()
    {
        ShopSaveData shopData = this.GetUtility<Storage>().Load<ShopSaveData>();
        if (shopData == default)
            return;
        _timeSystem = this.GetSystem<TimeSystem>();
        Dictionary<int, ShopDefine> shopDefines = new Dictionary<int, ShopDefine>();
        shopDefines = this.SendQuery(new GetDefineDictionaryQuery<Dictionary<int, ShopDefine>>());
        foreach(var shop in _model.shopItemDict)
        {
            if(_timeSystem.JudgeIsNextDayClock(shopDefines[shop.Key].RefreshTime))//刷新数量
            {
                foreach(var item in shop.Value)
                {
                    item.Value.count = item.Value.define.sellCount;
                    item.Value.status = shopData.shopItemDict[shop.Key][item.Key].status;
                }
            }
            else//不刷新数量
            {
                foreach (var item in shop.Value)
                {
                    item.Value.count = shopData.shopItemDict[shop.Key][item.Key].count;
                    item.Value.status = shopData.shopItemDict[shop.Key][item.Key].status;
                }
            }
        }
    }
}
