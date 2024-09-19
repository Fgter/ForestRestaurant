using QFramework;


class UnlockSoilCommand : AbstractCommand
{
    Soil soil;
    public UnlockSoilCommand(Soil soil)
    {
        this.soil = soil;
    }
    protected override void OnExecute()
    {
        soil.data.unlock = true;
        this.SendEvent(new UnlockSoilEvent(soil));
    }
}
