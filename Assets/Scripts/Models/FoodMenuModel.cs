using Define;
using QFramework;
using System.Collections.Generic;
namespace Models
{
     public class FoodMenuModel : AbstractModel
    {
        public Dictionary<int, FoodItem> FoodMenu { get; set; } = new();//已经选择的菜单
        public BindableProperty<Dictionary<int, FoodItem>> CanSelectFoodMenu { get; set; } = new(new ());//能选择的菜单
                                                                   //消耗多少算多少抵达阈值显示提示
        public int ExpectedGoldSum { get; set; }//价值总和(这里是默认售价的总和用于预计收益显示)
        public int GoldSum { get; set; }//目前收益
        public int SelectMax { get; set; } //选择上限(可能会通过一个整体配置表设置待定)

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
            CanSelectFoodMenu.Value.Add(_id, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(_id))));
        }
    }
}
   


