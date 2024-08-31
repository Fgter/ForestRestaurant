using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public enum ItemType
    {
        Seed,
        Harvest,//收获物
        food,
    }
    public class ItemDefine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public string Icon { get; set; }
    }
}
