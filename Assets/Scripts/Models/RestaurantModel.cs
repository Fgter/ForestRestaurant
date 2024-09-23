using Define;
using QFramework;
using SaveData;
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
        public BindableProperty<int> GoldSum { get; set; } = new();//目前收益
        //留言板功能
        public Dictionary<int,string> Acclaims { get; set; } = new(); //当前留言数据
        protected override void OnInit()
        {
            SelectMax = 100;
            Load();
            CommonMono.AddQuitAction(Save);
            GoldSum.Register(v =>
            {
                this.SendEvent<UpdateCashRegisterUIEvent>();
            });
        }
        void Save()
        {
            RestaurantSaveData restaurantSaveData = new();
            restaurantSaveData.Acclaims = Acclaims;
            restaurantSaveData.CanSelectFoodMenu.AddRange(CanSelectFoodMenu.Keys);
            restaurantSaveData.ExpectedGoldSum = ExpectedGoldSum;
            restaurantSaveData.FoodMenu.AddRange(FoodMenu.Keys);
            restaurantSaveData.GoldSum = GoldSum.Value;
            restaurantSaveData.SelectMax = SelectMax;
            this.GetUtility<Storage>().Save(restaurantSaveData);
        }
        void Load()
        {
            RestaurantSaveData restaurantSaveData = new();
            restaurantSaveData = this.GetUtility<Storage>().Load<RestaurantSaveData>();
            if (restaurantSaveData == default)
                return;
           Acclaims = restaurantSaveData.Acclaims;
            foreach (var item in restaurantSaveData.CanSelectFoodMenu)
            {
                CanSelectFoodMenu.Add(item, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(item))));
            }
            ExpectedGoldSum = restaurantSaveData.ExpectedGoldSum;
            foreach (var item in restaurantSaveData.FoodMenu)
            {
                FoodMenu.Add(item, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(item))));
            }
            GoldSum.Value = restaurantSaveData.GoldSum;
            SelectMax = restaurantSaveData.SelectMax;
        }
    }
}
   


