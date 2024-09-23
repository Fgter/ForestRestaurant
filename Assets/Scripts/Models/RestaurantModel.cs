using Define;
using QFramework;
using SaveData;
using System.Collections.Generic;
namespace Models
{
     public class RestaurantModel : AbstractModel
    {
        //ѡ��˵�
        public Dictionary<int, FoodItem> FoodMenu { get; set; } = new();//�Ѿ�ѡ��Ĳ˵�
        public Dictionary<int, FoodItem> CanSelectFoodMenu { get; set; } = new();//��ѡ��Ĳ˵�
                                                                   //���Ķ�������ٵִ���ֵ��ʾ��ʾ
        public int ExpectedGoldSum { get; set; }//��ֵ�ܺ�(������Ĭ���ۼ۵��ܺ�����Ԥ��������ʾ)
        public int SelectMax { get; set; } //ѡ������(���ܻ�ͨ��һ���������ñ����ô���)
        //�����ȡ����
        public BindableProperty<int> GoldSum { get; set; } = new();//Ŀǰ����
        //���԰幦��
        public Dictionary<int,string> Acclaims { get; set; } = new(); //��ǰ��������
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
   


