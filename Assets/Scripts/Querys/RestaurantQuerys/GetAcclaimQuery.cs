using Models;
using QFramework;
using UnityEngine;
/// <summary>
/// 获取食物的评论(已经存在的)
/// </summary>
public class GetAcclaimQuery : AbstractQuery<string>
{
    int _id;
    RestaurantModel _model;
    public GetAcclaimQuery(int id)
    {
        _id = id;
    }
    protected override string OnDo()
    {
        _model = this.GetModel<RestaurantModel>();
        if (_model.Acclaims.ContainsKey(_id))
        {
            return _model.Acclaims[_id];
        }
        Debug.LogError("[GetAcclaimQuery] 没有对应的食物评论");
        return null;
    }
}

