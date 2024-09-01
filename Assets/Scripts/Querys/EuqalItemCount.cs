using UnityEngine;
using QFramework;
using Models;

class EuqalItemCount : AbstractQuery<bool>
{
    int id;
    int count;
    public EuqalItemCount(int id,int count)
    {
        this.id = id;
        this.count = count;
    }
    protected override bool OnDo()
    {
        ItemModel model = this.GetModel<ItemModel>();
        if (model.Items.TryGetValue(id, out Item item))
        {
            if (item.count >= count)
                return true;
            return false;
        }
        else
        {
            Debug.LogError("id:" + id + " not in ItemModel");
            return false;
        }
    }
}
