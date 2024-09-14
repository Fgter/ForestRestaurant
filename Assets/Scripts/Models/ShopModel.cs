using QFramework;
using System.Collections.Generic;
using Define;

namespace Models
{
    public class ShopModel : AbstractModel
    {
        public Dictionary<int, Dictionary<int, ShopItem>> shopItemDict = new Dictionary<int, Dictionary<int, ShopItem>>();//第一个key是商店id，第二个key是shopItem的id
        public List<ShopItem> shopItemList = new List<ShopItem>();
        protected override void OnInit()
        {
            var defines= this.SendQuery(new GetDefineDictionaryQuery<Dictionary<int, Dictionary<int, ShopItemDefine>>>());
            foreach(var s in defines)
            {
                shopItemDict[s.Key] = new Dictionary<int, ShopItem>();
                foreach(var si in s.Value)
                {
                    IIconItemDefine itemDefine = this.SendQuery(new GetIconItemDefineQuery(si.Value.ItemId));
                    ShopItem item = new ShopItem(si.Value, itemDefine, si.Value.sellCount);
                    shopItemDict[s.Key][si.Key] = item;
                    shopItemList.Add(item);
                }
            }
        }
    }
}