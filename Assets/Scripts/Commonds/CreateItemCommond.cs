using QFramework;
using UnityEngine;
using Models;
using Define;

class CreateItemCommond : AbstractCommand<Item>
{
    int id;
    public CreateItemCommond(int id)
    {
        this.id = id;
    }
    protected override Item OnExecute()
    {
        switch (id)
        {
            case int id when (id > 0 && id < 1000)://是种子
                SeedItem si = new SeedItem(this.SendQuery(new GetDefineQuery<SeedDefine>(id)));
                return si;

            case int id when (id > 1000 && id < 2000)://是收获作物
                Item hi = new Item();
                return hi;
            case int id when (id > 2000 && id < 4000)://是食物
                return default;
            default:
                Debug.LogError("id" + id + " 没有这号东西，请查询策划案");
                return default;
        }
    }
}
