using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Define
{
    public interface IDefine
    {
    }

    public interface IIconItemDefine:IDefine //给可以在背包中显示出来的物品用的
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public interface IOtherItemDefine:IDefine
    {

    }
}
