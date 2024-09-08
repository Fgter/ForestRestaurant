using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEditor.Progress;

/// <summary>
/// 该指令用于删除菜单中的食物
/// </summary>
public class RemoveFoodCommand : AbstractCommand
{
    Item _item { get; set; }
    FoodItem _foodItem { get; set; }
    FoodMenuModel Ls;
    int _id;
    public RemoveFoodCommand(int Id)
    {
        _id = Id;
    }
    protected override void OnExecute()
    {
        Debug.Log("[AddFoodCommand] 删除食物指令触发");
        _item = this.SendCommand(new CreateItemCommond(_id));
        Ls = this.GetModel<FoodMenuModel>();
        bool istype = _item is FoodItem;
        if (istype && Ls.SelectFoodMenu.ContainsKey(_id) && !Ls.CanSelectFoodMenu.ContainsKey(_id)) //类型与重复存在判断
        {
            _foodItem = (FoodItem)_item;
            Succeed();
            Debug.Log("[AddFoodCommand] 删除成功");
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
        Debug.Log(this.GetModel<FoodMenuModel>().SelectFoodMenu.Count + " " + this.GetModel<FoodMenuModel>().CanSelectFoodMenu.Count + " " + this.GetModel<FoodMenuModel>().GoldSum);
    }
    void Succeed()//删除成功后的方法
    {
        Ls.CanSelectFoodMenu.Add(_id, _foodItem);//移除可选择菜单中的值
        Ls.SelectFoodMenu.Remove(_id);//添加至选择菜单中
        Ls.GoldSum -= _foodItem.define.Price;//添加金币
    }
    void Fail()//删除失败后的方法(非类型错误的情况)
    {
        //消息提示显示啥的
    }

}

