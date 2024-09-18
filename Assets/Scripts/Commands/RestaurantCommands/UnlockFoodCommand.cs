using Define;
using QFramework;
using UnityEngine;
using Models;

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
            this.GetModel<FoodMenuModel>().CanSelectFoodMenu.Value.Add(_id, _foodItem);
        }
        else
        {
            Debug.Log("[错误] sss");
        }
        
    }
}

