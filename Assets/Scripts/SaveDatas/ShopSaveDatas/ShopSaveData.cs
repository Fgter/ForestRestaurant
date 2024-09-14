using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveData
{
    class ShopSaveData
    {
        public Dictionary<int, Dictionary<int, ShopItemSaveData>> shopItemDict;
        public List<ShopItemSaveData> shopItemList;
    }

    struct ShopItemSaveData
    {
        public int count;
        public bool status;
    }
}
