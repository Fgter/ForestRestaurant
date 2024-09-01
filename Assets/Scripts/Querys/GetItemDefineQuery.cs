using QFramework;
using Models;
using UnityEngine;
using Data;

public class GetItemDefineQuery : AbstractQuery<ItemDefine>
{
    int id;
    public GetItemDefineQuery(int id)
    {
        this.id = id;
    }
    protected override ItemDefine OnDo()
    {
        DataModel model = this.GetModel<DataModel>();
        if (model.ItemDefines.ContainsKey(id))
        {
            return model.ItemDefines[id];
        }
        else
        {
            Debug.LogError("Item id:" + id + " is not in ItemDefines");
            return default;
        }
    }
}
