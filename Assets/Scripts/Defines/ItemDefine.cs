using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Define
{
    public enum ItemType
    {
        Seed,
        Harvest,//收获物
        food,
    }
    public class ItemDefine:IDefine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public string Icon { get; set; }
    }
}
