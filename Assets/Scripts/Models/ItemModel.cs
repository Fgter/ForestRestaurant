using System.Collections.Generic;
using QFramework;
using System;

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