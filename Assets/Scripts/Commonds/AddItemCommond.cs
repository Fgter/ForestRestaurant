using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Models;

public class AddItemCommond : AbstractCommand
{
    int id;
    int count;
   public AddItemCommond(int id,int count)
    {
        this.id = id;
        this.count = count;
    }

    protected override void OnExecute()
    {
        ItemModel model = this.GetModel<ItemModel>();
        if (model.Items.TryGetValue(id, out Item item))
        {
            item.count += count;
        }
        else
        {
            Item newItem = new Item(this.SendQuery(new GetItemDefineQuery(id)), count);
            model.Items.Add(id, newItem);
        }
    }
}
