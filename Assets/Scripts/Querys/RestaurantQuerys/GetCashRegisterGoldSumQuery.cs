
using Models;
using QFramework;

public class GetCashRegisterGoldSumQuery : AbstractQuery<int>
{
    protected override int OnDo()
    {
        return this.GetModel<RestaurantModel>().GoldSum.Value;
    }
}

