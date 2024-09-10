using QFramework;
using System.Collections.Generic;
using UnityEngine;

public class GetCanSelectFoodMenuQuery : AbstractQuery<List<FoodItem>>
{
    SelectMenu _selectMenu;
    public GetCanSelectFoodMenuQuery(SelectMenu selectMenu)
    {
        _selectMenu = selectMenu;
    }
    protected override List<FoodItem> OnDo()
    {
        List<FoodItem> foodItems = new();
        switch (_selectMenu)
        {
            case SelectMenu.CanSelectMenu:
                foreach (var i in this.GetModel<FoodMenuModel>().CanSelectFoodMenu.Values)
                {
                    foodItems.Add(i);
                }
                return foodItems;
            case SelectMenu.FoodMenu:
                foreach (var i in this.GetModel<FoodMenuModel>().FoodMenu.Values)
                {
                    foodItems.Add(i);
                }
                return foodItems;
            default:
                Debug.LogError("[GetCanSelectFoodMenuQuery] 不存在该数据");
                return null;
        }
    }
}
