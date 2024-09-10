using Define;
using System;
using SaveData;

public class PlantEntityData//Plant�ڲ����¶�����Ϊ��λ���ⲿ���¶�����Ϊ��λ
{
    public Action<string> StageSwitchEvent;
    public int currentStage { get; set; }
    public string currentStageName { get => _define.StagesName[currentStage]; }
    public bool harvestable { get => currentStage >= _define.Animation.Length - 1; }
    public float growedTime { get => TimeConverter.SecondToDay(_growedTime); }//�Ѿ������˶೤ʱ��,��Ϊ��λ
    public SoilEntityData owner { get; set; }//�����Ŀ�������
    public int season { get => _season; }
    public bool canReGrow { get => _season < define.SeasonCount; }
    public PlantDefine define { get => _define; }

    PlantDefine _define;
    float _growedTime = 0f;//�Ѿ������˶೤ʱ��,��Ϊ��λ
    float _matureTime;//��������ʱ��,��Ϊ��λ
    int _season;//��ǰ���ڵڼ���

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

    public void Grow()//����
    {
        _growedTime += 1;
        TryNextStage();
    }
    /// <summary>
    /// ����ʱ��������ʱ�䳤�ȵĽ���
    /// </summary>
    /// <param name="time">����Ϊ��λ</param>
    public void Grow(float time)//time��λΪ��(day)
    {
        _growedTime += TimeConverter.DayToSecond(time);
        foreach(var port in _define.GrowthPercentPort)
        {
            TryNextStage();
        }
    }

    void TryNextStage()
    {
        if (!harvestable && (_growedTime / _matureTime) >= _define.GrowthPercentPort[currentStage+1])//����ͻ�ƿڲ��Ҳ����ջ��������һ�׶�
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
