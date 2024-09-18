using Models;
using QFramework;
using UnityEngine;
/// <summary>
/// 该指令用于向菜单添加菜品
/// </summary>
public class AddFoodCommand : AbstractCommand
{
    FoodItem _foodItem;
    FoodMenuModel _ls;
    int _id;
    public AddFoodCommand(int Id)
    {
        _id = Id;
    }
    protected override void OnExecute()
    {
        Debug.Log("[AddFoodCommand] 添加食物指令触发");
        _foodItem = this.SendQuery(new GetFoodMenuInItemQuery(_id,SelectMenu.CanSelectMenu));
        _ls = this.GetModel<FoodMenuModel>();
        if (_ls.FoodMenu.Count <= _ls.SelectMax && _foodItem !=null) //类型与重复存在判断
        {
            Succeed();
            Debug.Log("[AddFoodCommand] 添加成功");
        }
        else
        {
            Fail();
        }
    }
    void Succeed()//添加成功后的方法
    {
        _ls.FoodMenu.Add(_id, _foodItem);//添加至选择菜单中
        _ls.CanSelectFoodMenu.Remove(_id);//移除可选择菜单中的值
        _ls.ExpectedGoldSum += _foodItem.define.Price;//添加金币
        this.SendEvent<UpdateFoodMenuUIEvent>();
    }
    void Fail()//添加失败后的方法(非类型错误的情况)
    {
        UIManager.instance.ShowMessageTip("[错误] 不存在该物体导致添加错误");
    }
}
