using Define;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMenuModel : AbstractModel
{
    public Dictionary<int, FoodItem> SelectFoodMenu = new();//�Ѿ�ѡ��Ĳ˵�
    public Dictionary<int, FoodItem> CanSelectFoodMenu = new();//��ѡ��Ĳ˵�
    //���Ķ�������ٵִ���ֵ��ʾ��ʾ
    public int GoldSum { get; set; }//��ֵ�ܺ�(������Ĭ���ۼ۵��ܺ�����Ԥ��������ʾ)
    public int SelectMax {  get; set; } //ѡ������(���ܻ�ͨ��һ���������ñ����ô���)

    protected override void OnInit()
    {
        SelectMax = 100;
        CanSelectFoodMenu.Add(2001, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(2001))));
        CanSelectFoodMenu.Add(2002, new FoodItem(this.SendQuery(new GetDefineQuery<FoodDefine>(2002))));
    }

}
