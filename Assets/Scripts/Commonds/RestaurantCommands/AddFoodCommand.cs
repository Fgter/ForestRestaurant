using Define;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 该指令用于向菜单添加菜品
/// </summary>
public class AddFoodCommand : AbstractCommand
{
    Item _item;
    FoodItem _foodItem;
    FoodMenuModel Ls;
    int _id;
    public AddFoodCommand(int Id)
    {
        _id = Id;
    }
    protected override void OnExecute()
    {
        Debug.Log("[AddFoodCommand] 添加食物指令触发");
        _item = this.SendCommand(new CreateItemCommond(_id));
        Ls = this.GetModel<FoodMenuModel>();
        bool istype = _item is FoodItem;

        //下面判断是：1、类型是否正确 2、是否在选择菜单中已经存在 3、能选择的菜单中是否存在 4、选择的菜单数量是否大于最大值
        if (istype && !Ls.SelectFoodMenu.ContainsKey(_id) && Ls.CanSelectFoodMenu.ContainsKey(_id) && Ls.SelectFoodMenu.Count <= Ls.SelectMax) //类型与重复存在判断
        {
            _foodItem = (FoodItem)_item;
            Succeed();
            Debug.Log("[AddFoodCommand] 添加成功");
        }
        //类型错误返回错误日志
        else if (!istype)
        {
            Debug.LogError("[AddFoodCommand] 你所加入的Item不属于FoodItem");
        }
        else
        {
            Fail();
        }
    }
    void Succeed()//添加成功后的方法
    {
        Ls.SelectFoodMenu.Add(_id, _foodItem);//添加至选择菜单中
        Ls.CanSelectFoodMenu.Remove(_id);//移除可选择菜单中的值
        Ls.ExpectedGoldSum += _foodItem.define.Price;//添加金币
        this.SendEvent<RestaurantEvent>();
    }
    void Fail()//添加失败后的方法(非类型错误的情况)
    {
        //消息提示显示啥的
    }
}
