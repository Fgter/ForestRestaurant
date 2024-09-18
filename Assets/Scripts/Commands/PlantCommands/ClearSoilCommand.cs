using Models;
using QFramework;

public class ClearSoilCommand : AbstractCommand
{
    SoilEntityData soil;
    public ClearSoilCommand(SoilEntityData soil)
    {
        this.soil = soil;
    }
    protected override void OnExecute()
    {
        soil.plant = null;
        PlantModel model = this.GetModel<PlantModel>();
        model.RemovePlant(soil.Id);
    }
}
