using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using Define;
using System;


public class Item
{
    public int count { get; set; }
    public Type Type { get => this.GetType(); }
}
public class SeedItem : Item
{
    public SeedDefine define { get; set; }
    public SeedItem(SeedDefine define)
    {
        this.define = define;
        this.count = 0;
    }
}


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