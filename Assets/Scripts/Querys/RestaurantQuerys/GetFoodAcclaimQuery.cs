using Define;
using Models;
using QFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetFoodAcclaimQuery : AbstractQuery<List<string>>
{
    int _id;
    public GetFoodAcclaimQuery(int id) { 
        _id = id;
    }
    protected override List<string> OnDo()
    {
        return this.SendQuery(new GetDefineDictionaryQuery<Dictionary<int, FoodDefine>>())[_id].Acclaim;
    }
}