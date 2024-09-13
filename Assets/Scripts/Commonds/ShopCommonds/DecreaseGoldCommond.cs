using Models;
using QFramework;
class DecreaseGoldCommond : AbstractCommand<bool>
{
    int count;
    public DecreaseGoldCommond(int count)
    {
        this.count = count;
    }
    protected override bool OnExecute()
    {
        var model = this.GetModel<PlayerModel>();
        var gold = model.Gold;
        if (gold.Value>=count)
        {
            gold.Value -= count;
            return true;
        }
        return false;
    }
}
