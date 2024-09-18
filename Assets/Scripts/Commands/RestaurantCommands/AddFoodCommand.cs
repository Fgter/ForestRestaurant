using Models;
using QFramework;
using UnityEngine;
/// <summary>
/// ��ָ��������˵���Ӳ�Ʒ
/// </summary>
public class AddFoodCommand : AbstractCommand
{
    FoodItem _foodItem;
    FoodMenuModel _ls;
    int _id;
    public AddFoodCommand(int Id)
    {
        _id = Id;
    }
    protected override void OnExecute()
    {
        Debug.Log("[AddFoodCommand] ���ʳ��ָ���");
        _foodItem = this.SendQuery(new GetFoodMenuInItemQuery(_id,SelectMenu.CanSelectMenu));
        _ls = this.GetModel<FoodMenuModel>();
        if (_ls.FoodMenu.Count <= _ls.SelectMax && _foodItem !=null) //�������ظ������ж�
        {
            Succeed();
            Debug.Log("[AddFoodCommand] ��ӳɹ�");
        }
        else
        {
            Fail();
        }
    }
    void Succeed()//��ӳɹ���ķ���
    {
        _ls.FoodMenu.Add(_id, _foodItem);//�����ѡ��˵���
        _ls.CanSelectFoodMenu.Remove(_id);//�Ƴ���ѡ��˵��е�ֵ
        _ls.ExpectedGoldSum += _foodItem.define.Price;//��ӽ��
        this.SendEvent<UpdateFoodMenuUIEvent>();
    }
    void Fail()//���ʧ�ܺ�ķ���(�����ʹ�������)
    {
        UIManager.instance.ShowMessageTip("[����] �����ڸ����嵼����Ӵ���");
    }
}
