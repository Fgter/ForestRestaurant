using Define;
using QFramework;
using System.Collections.Generic;
namespace Models
{
    public class FoodMenuModel : AbstractModel
    {
        public Dictionary<int, FoodItem> FoodMenu = new();//�Ѿ�ѡ��Ĳ˵�
        public Dictionary<int, FoodItem> CanSelectFoodMenu = new();//��ѡ��Ĳ˵�
                                                                   //���Ķ�������ٵִ���ֵ��ʾ��ʾ
        public int ExpectedGoldSum { get; set; }//��ֵ�ܺ�(������Ĭ���ۼ۵��ܺ�����Ԥ��������ʾ)
        public int GoldSum { get; set; }//Ŀǰ����
        public int SelectMax { get; set; } //ѡ������(���ܻ�ͨ��һ���������ñ����ô���)

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

