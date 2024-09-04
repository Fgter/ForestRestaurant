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
        public Dictionary<int, Item> Items = new Dictionary<int, Item>();//��������Item�������������������

        public Dictionary<Type, dynamic> classifyItems = new Dictionary<Type, dynamic>();//���ౣ��Item������������

        protected override void OnInit()
        {

        }
    }
}