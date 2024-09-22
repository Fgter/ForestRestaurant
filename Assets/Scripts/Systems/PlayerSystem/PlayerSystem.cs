using UnityEngine;
using QFramework;
using SaveData;
using Models;
public class PlayerSystem : AbstractSystem
{
    PlayerModel _model;
    protected override void OnInit()
    {
        _model = this.GetModel<PlayerModel>();
        GiveIntinalMaterials();
    }

    void GiveIntinalMaterials()
    {
        if (_model.isFirstEnter)
        {
            this.SendCommand(new IncreaseGoldCommand(1000));
            this.SendCommand(new UnlockFoodCommand(2001));
            this.SendCommand(new UnlockFoodCommand(2002));
            this.SendCommand(new UnlockFoodCommand(2003));
            this.SendCommand(new UnlockFoodCommand(2004));
            this.SendCommand(new UnlockFoodCommand(2005));
            this.SendCommand(new UnlockFoodCommand(2006));
        }
        _model.isFirstEnter = false;
    }
}
