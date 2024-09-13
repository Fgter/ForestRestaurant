using Models;
using QFramework;
class IncreaseGoldCommond : AbstractCommand
{
    int count;
    public IncreaseGoldCommond(int count)
    {
        this.count = count;
    }
    protected override void OnExecute()
    {
        this.GetModel<PlayerModel>().Gold.Value += count;
    }
}
