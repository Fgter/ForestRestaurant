using Define;
using Models;
using QFramework;

public class UnlockFoodCommand : AbstractCommand
{
    int _id;

    public UnlockFoodCommand(int id) {
         _id = id;
    }
    protected override void OnExecute()
    {
        FoodItem _foodItem = new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(_id)));
        if(_foodItem != null)
        {
            this.GetModel<RestaurantModel>().CanSelectFoodMenu.Add(_id, _foodItem);
        }
        else
        {
            UIManager.instance.ShowMessageTip("[错误] 不存在该id的物品无法解锁").SetType(MessageType.Error);
        }
        
    }
}

