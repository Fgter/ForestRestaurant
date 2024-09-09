using Define;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��ָ��������˵���Ӳ�Ʒ
/// </summary>
public class AddFoodCommand : AbstractCommand
{
    Item _item;
    FoodItem _foodItem;
    FoodMenuModel Ls;
    int _id;
    public AddFoodCommand(int Id)
    {
        _id = Id;
    }
    protected override void OnExecute()
    {
        Debug.Log("[AddFoodCommand] ���ʳ��ָ���");
        _item = this.SendCommand(new CreateItemCommond(_id));
        Ls = this.GetModel<FoodMenuModel>();
        bool istype = _item is FoodItem;

        //�����ж��ǣ�1�������Ƿ���ȷ 2���Ƿ���ѡ��˵����Ѿ����� 3����ѡ��Ĳ˵����Ƿ���� 4��ѡ��Ĳ˵������Ƿ�������ֵ
        if (istype && !Ls.SelectFoodMenu.ContainsKey(_id) && Ls.CanSelectFoodMenu.ContainsKey(_id) && Ls.SelectFoodMenu.Count <= Ls.SelectMax) //�������ظ������ж�
        {
            _foodItem = (FoodItem)_item;
            Succeed();
            Debug.Log("[AddFoodCommand] ��ӳɹ�");
        }
        //���ʹ��󷵻ش�����־
        else if (!istype)
        {
            Debug.LogError("[AddFoodCommand] ���������Item������FoodItem");
        }
        else
        {
            Fail();
        }
    }
    void Succeed()//��ӳɹ���ķ���
    {
        Ls.SelectFoodMenu.Add(_id, _foodItem);//�����ѡ��˵���
        Ls.CanSelectFoodMenu.Remove(_id);//�Ƴ���ѡ��˵��е�ֵ
        Ls.ExpectedGoldSum += _foodItem.define.Price;//��ӽ��
        this.SendEvent<RestaurantEvent>();
    }
    void Fail()//���ʧ�ܺ�ķ���(�����ʹ�������)
    {
        //��Ϣ��ʾ��ʾɶ��
    }
}
