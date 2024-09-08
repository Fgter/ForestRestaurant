using Define;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMenuModel : AbstractModel
{
    public Dictionary<int, FoodItem> SelectFoodMenu = new();//已经选择的菜单
    public Dictionary<int, FoodItem> CanSelectFoodMenu = new();//能选择的菜单
    //消耗多少算多少抵达阈值显示提示
    public int GoldSum { get; set; }//价值总和(这里是默认售价的总和用于预计收益显示)
    public int SelectMax {  get; set; } //选择上限(可能会通过一个整体配置表设置待定)

    protected override void OnInit()
    {
        SelectMax = 100;
        CanSelectFoodMenu.Add(2001, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(2001))));
        CanSelectFoodMenu.Add(2002, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(2002))));
    }

}
