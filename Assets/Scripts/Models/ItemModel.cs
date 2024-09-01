using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Data;

namespace Models
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
    public class ItemModel : AbstractModel
    {
        public Dictionary<int, Item> Items = new Dictionary<int, Item>();
        protected override void OnInit()
        {

        }
    }
}