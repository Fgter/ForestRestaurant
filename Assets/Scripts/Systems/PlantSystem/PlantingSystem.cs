using QFramework;
using Define;
using SaveData;
using Models;

public class PlantingSystem : AbstractSystem
{
    PlantModel _model;
    protected override void OnInit()
    {
        _model = this.GetModel<PlantModel>();
        TimeSystem.RegisterSecondUpdateAction(Grow);
    }

    void Grow()
    {
        foreach (var plant in _model.plants.Values)
        {
            plant.Grow();
        }
    }

}
