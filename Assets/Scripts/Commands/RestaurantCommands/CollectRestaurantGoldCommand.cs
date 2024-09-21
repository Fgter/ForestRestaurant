using Models;
using QFramework;
using UnityEngine;
/// <summary>
/// 收取餐厅金币的指令
/// </summary>
public class CollectRestaurantGoldCommand : AbstractCommand
{
    RestaurantModel _foodMenuModel;
    int test;
    protected override void OnExecute()
    {
        _foodMenuModel = this.GetModel<RestaurantModel>();
        test = this.SendCommand(new IncreaseGoldCommand(_foodMenuModel.GoldSum.Value));
        _foodMenuModel.GoldSum.Value = 0;
        Debug.LogFormat("当前金币数量:{0}",test);
    }
}
