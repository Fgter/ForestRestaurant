using QFramework;
using UnityEngine;

public class GetFoodMenuInItemQuery : AbstractQuery<FoodItem>
{
    int _id;
    SelectMenu _selectMenu;
    public GetFoodMenuInItemQuery(int id,SelectMenu selectMenu) 
    { 
        _id = id;
        _selectMenu = selectMenu;
    }
    protected override FoodItem OnDo()
    {
        switch (_selectMenu)
        {
            case SelectMenu.CanSelectMenu:
                if (this.GetModel<FoodMenuModel>().CanSelectFoodMenu.ContainsKey(_id))
                {
                    return this.GetModel<FoodMenuModel>().CanSelectFoodMenu[_id];
                }
                else
                {
                    Debug.LogError("[GetFoodMenuInItemQuery] 你所输入的id可能未解锁?");
                    return null;
                }
            case SelectMenu.FoodMenu:
                if (this.GetModel<FoodMenuModel>().FoodMenu.ContainsKey(_id))
                {
                    return this.GetModel<FoodMenuModel>().FoodMenu[_id];
                }
                else
                {
                    Debug.LogError("[GetFoodMenuInItemQuery] 你所输入的id可能未解锁?");
                    return null;
                }
            default:
                Debug.LogError("[GetFoodMenuInItemQuery] 你所输入的id可能未解锁?");
                return null;
        }
        
    }
}

