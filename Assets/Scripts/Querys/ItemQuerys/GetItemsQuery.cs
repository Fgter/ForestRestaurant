using Models;
using QFramework;
using System.Collections.Generic;

class GetItemsQuery<T>:AbstractQuery<List<T>> where T:Item
    {

    protected override List<T> OnDo()
    {
        ItemModel model = this.GetModel<ItemModel>();
        if (model.classifyItems.TryGetValue(typeof(T), out dynamic dic))
        {
            Dictionary<int, T> items = dic as Dictionary<int, T>;
            List<T> result = new List<T>(items.Count);
            result.AddRange(items.Values);
            return result;
        }
        else
        {
            return new List<T>();
        }
    }
}
