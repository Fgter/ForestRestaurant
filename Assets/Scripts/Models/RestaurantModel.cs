using Define;
using QFramework;
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
            GoldSum.Register(v =>
            {
                this.SendEvent<UpdateCashRegisterUIEvent>();
            });
        }
    }
}
   


