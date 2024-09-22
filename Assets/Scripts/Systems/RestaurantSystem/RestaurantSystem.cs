using Define;
using Models;
using QFramework;
using SaveData;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class RestaurantSystem : AbstractSystem
{
    int _jg = 300;//间隔时间触发随机出售(s)<-可能需要放到配置表中
    static float _thisTime = 0;//已经过去的时间
    float _trigger = 0.6f;//每次触发时的概率
    int _ranindex;//随机数随机出的值
    System.Random _random = new System.Random();
    List<int> _ids = new();//存放id列表(方便直接读取)
    RestaurantModel _model;
    protected override void OnInit()
    {
        _model = this.GetModel<RestaurantModel>();
        CommonMono.AddFixedUpdateAction(() =>
        {
            _thisTime += Time.fixedDeltaTime;
            if (_thisTime >= _jg)
            {
                _thisTime -= _jg;
                if (RandomTrigger(_trigger))
                {
                    Sold();
                }
            }
        });
        CommonMono.AddQuitAction(Save);
        Load();
    }

    void Sold()//处理出售
    {
        _ids.Clear();
        _ids.AddRange(_model.FoodMenu.Keys);
        if (_ids.Count == 0)
        {
            //UIManager.instance.ShowMessageTip("请在餐厅选择出售的食材");
            return;
        }
        _ranindex = _random.Next(0, _ids.Count);
        this.SendCommand(new SellFoodCommand(_ids[_ranindex]));
    }

    bool RandomTrigger(float probability)//触发概率(0-1)
    {
        if (probability <= 0)
        {
            return false;
        }
        else if (probability >= 1)
        {
            return true;
        }
        int ls = _random.Next(0, 101);
        if (ls <= (int)(probability * 100))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Save()
    {
        RestaurantSaveData restaurantSaveData = new();
        restaurantSaveData.Acclaims = _model.Acclaims;
        restaurantSaveData.CanSelectFoodMenu.AddRange (_model.CanSelectFoodMenu.Keys);
        restaurantSaveData.ExpectedGoldSum = _model.ExpectedGoldSum;
        restaurantSaveData.FoodMenu.AddRange(_model.FoodMenu.Keys) ;
        restaurantSaveData.GoldSum = _model.GoldSum.Value;
        restaurantSaveData.SelectMax = _model.SelectMax;
        this.GetUtility<Storage>().Save(restaurantSaveData);
    }
    void Load()
    {
        RestaurantSaveData restaurantSaveData = new();
        restaurantSaveData = this.GetUtility<Storage>().Load<RestaurantSaveData>();
        if (restaurantSaveData == default)
            return;
        _model.Acclaims = restaurantSaveData.Acclaims;
        foreach (var item in restaurantSaveData.CanSelectFoodMenu)
        {
            _model.CanSelectFoodMenu.Add(item, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(item))));
        }
        _model.ExpectedGoldSum = restaurantSaveData.ExpectedGoldSum;
        foreach (var item in restaurantSaveData.FoodMenu)
        {
            _model.FoodMenu.Add(item, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(item))));
        }
        _model.GoldSum.Value = restaurantSaveData.GoldSum;
        _model.SelectMax = restaurantSaveData.SelectMax;
        _thisTime = TimeConverter.DayToSecond(this.SendQuery(new GetOfflinePeriodQuery()));
        if (TimeConverter.SecondToDay(_thisTime) >= 1)
        {
            _model.Acclaims.Clear();//清除所有
        }
        while (_thisTime >= _jg)
        {
            _thisTime -= _jg;
            if (RandomTrigger(_trigger))
            {
                Sold();
            }
        }
    }
    public static void AddTiem(float time)
    {
        _thisTime += time;
    }
}

