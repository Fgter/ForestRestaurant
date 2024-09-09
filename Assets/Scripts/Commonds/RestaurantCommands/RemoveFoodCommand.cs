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
    FoodItem _foodItem;
    FoodMenuModel _ls;
    int _id;
    public RemoveFoodCommand(int Id)
    {
        _id = Id;
    }
    protected override void OnExecute()
    {
        Debug.Log("[RemoveFoodCommand] 删除食物指令触发");
        _foodItem = this.SendQuery(new GetFoodMenuInItemQuery(_id, SelectMenu.FoodMenu));
        _ls = this.GetModel<FoodMenuModel>();
        if (_ls != null) //类型与重复存在判断
        {
            Succeed();
            Debug.Log("[RemoveFoodCommand] 删除成功");
        }
        else
        {
            Fail();
        }
    }
    void Succeed()//删除成功后的方法
    {
        _ls.CanSelectFoodMenu.Add(_id, _foodItem);//移除可选择菜单中的值
        _ls.FoodMenu.Remove(_id);//添加至选择菜单中
        _ls.ExpectedGoldSum -= _foodItem.define.Price;//添加金币
        this.SendEvent<UpdateFoodMenuUIEvent>();
    }
    void Fail()//删除失败后的方法(非类型错误的情况)
    {
        //消息提示显示啥的
    }

}

