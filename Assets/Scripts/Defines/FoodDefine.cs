using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Define
{
    public class FoodDefine : IBagItemDefine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Supplies { get; set; } = new ();//消耗物的Id
        public List<int> Sum { get; set; } = new();//消耗食物的数量
        public int Price { get; set; }//出售的基础价格
        public string Description { get; set; }//描述
        public string Icon { get; set; }
    }
}

