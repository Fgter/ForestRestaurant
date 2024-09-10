using Models;
using QFramework;

public class ClearSoilCommond : AbstractCommand
{
    SoilEntityData soil;
    public ClearSoilCommond(SoilEntityData soil)
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
