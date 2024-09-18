using Models;
using QFramework;


public class GetExpectedGoldQuery : AbstractQuery<int>
{
    protected override int OnDo()
    {
        return this.GetModel<RestaurantModel>().ExpectedGoldSum;
    }
}

