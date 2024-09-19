using Models;
using QFramework;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 出售食物的指令返回值为一个缺失的食物以及数量
/// </summary>
public class SellFoodCommand : AbstractCommand
{
    int _id;
    bool istf = false;//是否能出售
    ItemModel _itemModel;
    static Dictionary<Item, int> _itemdic;//存储的是缺少的材料
    public SellFoodCommand(int id) {
        _id = id;
    }
    protected override void OnExecute()
    {
        if (_itemdic == null)
        {
            _itemdic = new(); 
        }
        _itemdic.Clear();
        FoodItem foodItem = this.SendQuery(new GetFoodMenuInItemQuery(_id, SelectMenu.FoodMenu));
        int index = 0;
        _itemModel = this.GetModel<ItemModel>();
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
            //Fail("缺少必要的材料");
            return;
        }
        //成功
        this.SendCommand(new IncreaseGoldCommand(foodItem.define.Price));
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
        }
        else//记录缺少的材料
        {
            AddList(this.SendCommand(new CreateItemCommand(id)), foodItem.define.Sum[index] - _itemModel.Items[id].count);
        }
    }
    void NoRun(int id, FoodItem foodItem,int index)
    {
        AddList(this.SendCommand(new CreateItemCommand(id)), foodItem.define.Sum[index]);
    }
    void AddList(Item item,int sum)
    {
        _itemdic.Add(item,sum);
    }
}

