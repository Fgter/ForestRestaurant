using Models;
using QFramework;
using System.Collections.Generic;
/// <summary>
/// 添加留言命令
/// </summary>
public class AddGuestbookCommand : AbstractCommand
{
    int _id;
    static List<string> _acclaims;//获取的食物的留言列表
    System.Random _random = new ();
    RestaurantModel _model;
    /// <summary>
    /// 添加留言命令
    /// </summary>
    /// <param name="id">需要添加的食物留言(唯一)</param>
    public AddGuestbookCommand(int id) {
        _id = id;
    }
    protected override void OnExecute()
    {
        if(_acclaims == null)
        {
            _acclaims = new();
        }
        _model = this.GetModel<RestaurantModel>();
        if (_model.Acclaims.ContainsKey(_id))//对于已经存在的留言的食物不执行
        {
            return;
        }
        _acclaims.Clear();
        _acclaims = this.SendQuery(new GetFoodAcclaimQuery(_id));
        _model.Acclaims.Add(_id,_acclaims[_random.Next(_acclaims.Count)]);

        _model.GoldSum += _random.Next(0,10);//小费
    }
}

