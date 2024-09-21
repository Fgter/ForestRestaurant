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
        Load();
        CommonMono.AddQuitAction(Save);
        GiveIntinalMaterials();
    }
    void Load()
    {
        PlayerSaveData data = this.GetUtility<Storage>().Load<PlayerSaveData>();
        if (data == default)
            return;
        _model.Gold.Value = data.gold;
        _model.isFirstEnter = data.isFirstEnter;
    }

    void Save()
    {
        PlayerSaveData data = new PlayerSaveData();
        data.gold = _model.Gold.Value;
        data.isFirstEnter = _model.isFirstEnter;
        this.GetUtility<Storage>().Save(data);
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
