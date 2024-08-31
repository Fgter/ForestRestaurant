using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace Models
{
    public class ItemModel : AbstractModel
    {
        public class Item
        {
            public ItemDefine define { get; set; }
            public int count { get; set; }
            public Item(ItemDefine define, int count)
            {
                this.define = define;
                this.count = count;
            }
        }

        public Dictionary<int, Item> Items = new Dictionary<int, Item>();
        protected override void OnInit()
        {

        }

        public Item GetItem(int id)
        {
            if (Items.TryGetValue(id, out Item item))
            {
                return item;
            }
            Debug.LogError("id:" + id + "not in ItemModel");
            return default;
        }


        public void AddItem(int id, int count)
        {
            if (Items.TryGetValue(id, out Item item))
            {
                item.count += count;
            }
            else
            {
                Item newItem = new Item(this.SendQuery(new GetItemDefineQuery(id)),count);
                Items.Add(id,newItem);
            }
        }

        public void AddItem(ItemDefine define,int count)
        {
            if (Items.TryGetValue(define.Id, out Item item))
            {
                item.count += count;
            }
            else
            {
                Item newItem = new Item(define, count);
                Items.Add(define.Id, newItem);
            }
        }

        public bool RemoveItem(int id, int count)
        {
            if(Items.TryGetValue(id,out Item item))
            {
                if (item.count >= count)
                {
                    item.count -= count;
                    return true;
                }
                return false;

            }
            else
            {
                Debug.LogError("id:" + id + " not in ItemModel");
                return false;
            }    
        }

        public bool RemoveItem(ItemDefine define, int count)
        {
            if (Items.TryGetValue(define.Id, out Item item))
            {
                if (item.count >= count)
                {
                    item.count -= count;
                    return true;
                }
                return false;

            }
            else
            {
                Debug.LogError("id:" + define.Id + " not in ItemModel");
                return false;
            }
        }

        public bool EqualItemCount(int id, int count)
        {
            if (Items.TryGetValue(id, out Item item))
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
}