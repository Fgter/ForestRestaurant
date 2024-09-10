using Define;
using System;
using SaveData;

public class PlantEntityData//Plant内部更新都以秒为单位，外部更新都以天为单位
{
    public Action<string> StageSwitchEvent;
    public int currentStage { get; set; }
    public string currentStageName { get => _define.StagesName[currentStage]; }
    public bool harvestable { get => currentStage >= _define.Animation.Length - 1; }
    public float growedTime { get => TimeConverter.SecondToDay(_growedTime); }//已经生长了多长时间,天为单位
    public SoilEntityData owner { get; set; }//种在哪块土地上
    public int season { get => _season; }
    public bool canReGrow { get => _season < define.SeasonCount; }
    public PlantDefine define { get => _define; }

    PlantDefine _define;
    float _growedTime = 0f;//已经生长了多长时间,秒为单位
    float _matureTime;//成熟所需时间,秒为单位
    int _season;//当前处于第几季

    public PlantEntityData(PlantDefine define, SoilEntityData soil)
    {
        _define = define;
        _season = 1;
        owner = soil;
        _growedTime = 0f;
        SwitchStage(0);
        _matureTime = TimeConverter.DayToSecond(_define.MatureTime);
    }

    public PlantEntityData()
    {
    }

    public void Load(PlantSaveData data,PlantDefine define)
    {
        this.currentStage = data.currentStage;
        this._growedTime = data.growedTime;
        this._season = data.season;
        this._define = define;
        _matureTime = TimeConverter.DayToSecond(_define.MatureTime);
    }

    public void Grow()//生长
    {
        _growedTime += 1;
        TryNextStage();
    }
    /// <summary>
    /// 上线时增长下线时间长度的进度
    /// </summary>
    /// <param name="time">以天为单位</param>
    public void Grow(float time)//time单位为天(day)
    {
        _growedTime += TimeConverter.DayToSecond(time);
        foreach(var port in _define.GrowthPercentPort)
        {
            TryNextStage();
        }
    }

    void TryNextStage()
    {
        if (!harvestable && (_growedTime / _matureTime) >= _define.GrowthPercentPort[currentStage+1])//到达突破口并且不可收获则进入下一阶段
        {
            SwitchStage(++currentStage);
        }
    }

    void SwitchStage(int stage)
    {
        currentStage = stage;
        StageSwitchEvent?.Invoke(_define.Animation[currentStage]);
    }

    public bool TryHarvest()
    {
        if (!harvestable)
            return false;
        else
            return true;
    }

    public void ReGrow()
    {
        _season++;
        _growedTime = 0;
        SwitchStage(0);
    }
}
