using Models;
using QFramework;
using System.Collections.Generic;
using UnityEngine;

public class GetFoodMenuQuery : AbstractQuery<List<FoodItem>>
{
    SelectMenu _selectMenu;
    static List<FoodItem> foodItems;
    public GetFoodMenuQuery(SelectMenu selectMenu)
    {
        _selectMenu = selectMenu;
    }
    protected override List<FoodItem> OnDo()
    {
        if(foodItems == null)
        {
            foodItems = new();
        }
        else
        {
            foodItems.Clear();
        }
        switch (_selectMenu)
        {
            case SelectMenu.CanSelectMenu:
                foreach (var i in this.GetModel<RestaurantModel>().CanSelectFoodMenu.Values)
                {
                    foodItems.Add(i);
                }
                return foodItems;
            case SelectMenu.FoodMenu:
                foreach (var i in this.GetModel<RestaurantModel>().FoodMenu.Values)
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
