
using Models;
using QFramework;
using System.Collections.Generic;
/// <summary>
/// 用于返回评论的id属于那个物品
/// </summary>
public class GetFoodMenuAcclaimQuery : AbstractQuery<List<int>>
{
    static List<int> ints;
    protected override List<int> OnDo()
    {
        if (ints == null)
        {
            ints = new();
        }
        ints.Clear();
        ints.AddRange(this.GetModel<RestaurantModel>().Acclaims.Keys);
        return ints;
    }
}

