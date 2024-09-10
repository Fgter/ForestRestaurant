using Define;
using UnityEngine;

    public class SoilEntityData
    {
    public int Id { get => _define.Id; }
    public PlantEntityData plant { get; set; }
    public bool havePlant { get => plant != null; }
    public Vector2 position { get => new Vector2(_define.Position[0], _define.Position[1]); }
    public SoilDefine define { get => _define; }
    public bool unlock { get; set; }
    SoilDefine _define;

    public SoilEntityData(SoilDefine define,bool unlock)
    {
        _define = define;
        this.unlock = unlock;
    }
    }
