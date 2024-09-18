using JetBrains.Annotations;
using Models;
using QFramework;
using UnityEngine;
/// <summary>
/// 收取餐厅金币的指令
/// </summary>
public class CollectRestaurantGoldCommand : AbstractCommand
{
    FoodMenuModel _foodMenuModel;
    int test;
    protected override void OnExecute()
    {
        _foodMenuModel = this.GetModel<FoodMenuModel>();
        _foodMenuModel.GoldSum = 0;
        test = this.SendCommand(new IncreaseGoldCommand(_foodMenuModel.GoldSum));
        Debug.LogFormat("当前金币数量:{0}",test);
    }
}
