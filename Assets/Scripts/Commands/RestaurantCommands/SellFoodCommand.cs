using Models;
using QFramework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 出售食物的指令返回值为一个缺失的食物以及数量
/// </summary>
public class SellFoodCommand : AbstractCommand
{
    int _id;
    bool istf = false;//是否能出售
    ItemModel _itemModel;
    RestaurantModel _restaurantModel;
    static Dictionary<int, int> _itemdic;//存储的是缺少的材料
    static Dictionary<int, int> _haveitemdic;//存储的是已经存在的材料
    public SellFoodCommand(int id) {
        _id = id;
    }
    protected override void OnExecute()
    {
        if (_itemdic == null)
        {
            _itemdic = new(); 
        }
        if (_haveitemdic == null)
        {
            _haveitemdic = new();
        }
        _itemdic.Clear();
        _haveitemdic.Clear();
        FoodItem foodItem = this.SendQuery(new GetFoodMenuInItemQuery(_id, SelectMenu.FoodMenu));
        int index = 0;
        _itemModel = this.GetModel<ItemModel>();
        _restaurantModel = this.GetModel<RestaurantModel>();
        if(foodItem == null)
        {
            //Fail("该食物不在餐厅菜单中");
            return;//查询不到对应的食物
        }
        foreach(int i in foodItem.define.Supplies)
        { 
            if (_itemModel.Items.ContainsKey(i))
            {
                Run(i,foodItem,index);
            }
            else
            {
                istf = true;
                NoRun(i,foodItem,index);
            }
            index++;
        }
        if (istf)
        {
            Debug.Log("[SellFoodCommand] 缺少材料");
            //Fail("缺少必要的材料");
            return;
        }
        //成功
        Debug.Log("[SellFoodCommand] 出售成功");
        this.SendCommand(new AddGuestbookCommand(_id));
        _restaurantModel.GoldSum.Value += foodItem.define.Price;
        foreach (var i in _haveitemdic.Keys)
        {
            this.SendCommand(new RemoveItemCommand(i, _haveitemdic[i]));
        }
        this.SendEvent<ItemCountChangeEvent>();
        return;
    }
    void Fail(string massage)//临时:无
    {
        UIManager.instance.ShowMessageTip(massage).SetType(MessageType.Error);
    }
    void Run(int id,FoodItem foodItem,int index)
    {
        if (_itemModel.Items[id].count >= foodItem.define.Sum[index])//条件成立
        {
            Debug.Log($"{_itemModel.Items[id]}该材料存在且数量足够");
            AddHaveList(id, foodItem.define.Sum[index]);
        }
        else//记录缺少的材料
        {
            AddNothaveList(id, foodItem.define.Sum[index] - _itemModel.Items[id].count);
        }
    }
    void NoRun(int id, FoodItem foodItem,int index)
    {
        AddNothaveList(id, foodItem.define.Sum[index]);
    }
    void AddNothaveList(int id,int sum)
    {
        if(!_itemdic.ContainsKey(id))
        {
            _itemdic.Add(id, sum);
        }
        else
        {
            _itemdic[id] += sum;
        }
    }
    void AddHaveList(int id , int sum)
    {
        if (!_haveitemdic.ContainsKey(id))
        {
            _haveitemdic.Add(id, sum);
        }
        else
        {
            _haveitemdic[id] += sum;
        }
    }
}

