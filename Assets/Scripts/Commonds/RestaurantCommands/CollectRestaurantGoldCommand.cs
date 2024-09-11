using Models;
using QFramework;
using UnityEngine;

public class CollectRestaurantGoldCommand : AbstractCommand
{
    PlayerModel _playerModel;
    FoodMenuModel _foodMenuModel;
    protected override void OnExecute()
    {
        _playerModel = this.GetModel<PlayerModel>();
        _foodMenuModel = this.GetModel<FoodMenuModel>();
        _playerModel.Gold += _foodMenuModel.GoldSum;
        Debug.Log($"[CollectRestaurantGoldCommand] 收取成功 玩家当前金币数量为{_playerModel.Gold}");
    }
}
