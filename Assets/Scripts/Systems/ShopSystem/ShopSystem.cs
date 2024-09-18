using QFramework;
using Models;
using SaveData;
using System.Collections.Generic;
using Define;
using System;
public class ShopSystem : AbstractSystem
{
    ShopModel _model;
    TimeSystem _timeSystem;
    Dictionary<int, ShopDefine> shopDefines = new Dictionary<int, ShopDefine>();
    protected override void OnInit()
    {
        _model = this.GetModel<ShopModel>();
        CommonMono.AddQuitAction(Save);
        TimeSystem.RegisterClockUpdateAction(RefeshCount);
        Load();
    }

    /// <summary>
    /// 游戏运行时检测时间,刷新数量
    /// </summary>
    /// <param name="time"></param>
    void RefeshCount(DateTime time)
    {
        foreach (var shop in _model.shopItemDict)
        {
            if (time.Equals(shopDefines[shop.Key].RefreshTime))
            {
                foreach (var item in shop.Value)
                {
                    item.Value.count = item.Value.define.sellCount;
                }
            }
        }
    }

    void Save()
    {
        ShopSaveData shopData = new ShopSaveData();
        shopData.shopItemDict = new Dictionary<int, Dictionary<int, ShopItemSaveData>>();
        shopData.shopItemList = new List<ShopItemSaveData>();
        foreach (var shop in _model.shopItemDict)
        {
            shopData.shopItemDict[shop.Key] = new Dictionary<int, ShopItemSaveData>();
            foreach (var item in shop.Value)
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
        shopDefines = this.SendQuery(new GetDefineDictionaryQuery<Dictionary<int, ShopDefine>>());
        foreach (var shop in _model.shopItemDict)
        {
            if (_timeSystem.JudgeExitTimeOneDayApartClock(shopDefines[shop.Key].RefreshTime))//刷新数量
            {
                foreach (var item in shop.Value)
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
