using Models;
using QFramework;
class IncreaseGoldCommond : AbstractCommand<int>
{
    int count;
    public IncreaseGoldCommond(int count)
    {
        this.count = count;
    }
    protected override int OnExecute()
    {
        this.GetModel<PlayerModel>().Gold.Value += count;
        return count;
    }
}
