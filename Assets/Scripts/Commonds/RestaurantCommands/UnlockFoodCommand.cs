using Define;
using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


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
            this.GetModel<FoodMenuModel>().CanSelectFoodMenu.Add(_id, _foodItem);
            this.SendEvent<UpdateFoodMenuUIEvent>();
        }
        else
        {
            Debug.Log("[错误] sss");
        }
        
    }
}

