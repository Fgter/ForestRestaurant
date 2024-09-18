using Define;
using QFramework;
using System.Collections.Generic;
namespace Models
{
     public class RestaurantModel : AbstractModel
    {
        //选择菜单
        public Dictionary<int, FoodItem> FoodMenu { get; set; } = new();//已经选择的菜单
        public Dictionary<int, FoodItem> CanSelectFoodMenu { get; set; } = new();//能选择的菜单
                                                                   //消耗多少算多少抵达阈值显示提示
        public int ExpectedGoldSum { get; set; }//价值总和(这里是默认售价的总和用于预计收益显示)
        public int SelectMax { get; set; } //选择上限(可能会通过一个整体配置表设置待定)
        //金币收取功能
        public int GoldSum { get; set; }//目前收益
        //留言板功能
        public Dictionary<int,string> Acclaims { get; set; } = new(); //当前留言数据
        protected override void OnInit()
        {
            SelectMax = 100;
            AddCanSelectFoodMenuItem(2001);
            AddCanSelectFoodMenuItem(2002);
            AddCanSelectFoodMenuItem(2003);
            AddCanSelectFoodMenuItem(2004);
            AddCanSelectFoodMenuItem(2005);
            AddCanSelectFoodMenuItem(2006);
        }
        void AddCanSelectFoodMenuItem(int _id)
        {
            CanSelectFoodMenu.Add(_id, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(_id))));
        }
    }
}
   


