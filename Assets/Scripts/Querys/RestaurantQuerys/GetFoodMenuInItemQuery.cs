﻿using Models;
using QFramework;
using UnityEngine;
/// <summary>
/// 用于查找菜单中是否存在该对象
/// </summary>
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
                if (this.GetModel<RestaurantModel>().CanSelectFoodMenu.ContainsKey(_id))
                {
                    return this.GetModel<RestaurantModel>().CanSelectFoodMenu[_id];
                }
                else
                {
                    Debug.LogError("[GetFoodMenuInItemQuery] 你所输入的id可能未解锁?");
                    return null;
                }
            case SelectMenu.FoodMenu:
                if (this.GetModel<RestaurantModel>().FoodMenu.ContainsKey(_id))
                {
                    return this.GetModel<RestaurantModel>().FoodMenu[_id];
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

