using QFramework;
using System;
using System.Collections.Generic;
using Models;
using UnityEngine;

    class GetItemsQuery<T>:AbstractQuery<List<T>> where T:Item
    {

    protected override List<T> OnDo()
    {
        ItemModel model = this.GetModel<ItemModel>();
        if (model.classifyItems.TryGetValue(typeof(T), out dynamic dic))
        {
            Dictionary<int, T> items = dic as Dictionary<int, T>;
            List<T> reslut = new List<T>(items.Count);
            foreach(var item in items.Values)
            {
                reslut.Add(item);
            }
            return reslut;
        }
        else
        {
            return new List<T>();
        }
    }
}
