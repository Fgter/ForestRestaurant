using Models;
using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class GetExpectedGold : AbstractQuery<int>
{
    protected override int OnDo()
    {
        return this.GetModel<FoodMenuModel>().ExpectedGoldSum;
    }
}

