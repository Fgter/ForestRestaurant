using System.Collections.Generic;
using QFramework;
using System;

namespace Models
{
    public class ItemModel : AbstractModel
    {
        public Dictionary<int, Item> Items = new Dictionary<int, Item>();//保存所有Item，方便遍历及更改数量

        public Dictionary<Type, dynamic> classifyItems = new Dictionary<Type, dynamic>();//分类保存Item，方便分类遍历

        protected override void OnInit()
        {
            
        }
    }
}