using Define;
using System;
using SaveData;

public class PlantEntityData//Plant�ڲ����¶�����Ϊ��λ���ⲿ���¶�����Ϊ��λ
{
    public Action<string> StageSwitchEvent;
    public int currentStage { get; set; }
    public string currentStageName { get => m_define.StagesName[currentStage]; }
    public bool harvestable { get => currentStage >= m_define.Animation.Length - 1; }
    public float growedTime { get => TimeConverter.SecondToDay(m_growedTime); }//�Ѿ������˶೤ʱ��,��Ϊ��λ
    public Soil owner { get; set; }//�����Ŀ�������
    public int season { get => m_season; }
    public bool canReGrow { get => m_season < define.SeasonCount; }
    public PlantDefine define { get => m_define; }

    PlantDefine m_define;
    float m_growedTime = 0f;//�Ѿ������˶೤ʱ��,��Ϊ��λ
    float m_matureTime;//��������ʱ��,��Ϊ��λ
    int m_season;//��ǰ���ڵڼ���

    public PlantEntityData(PlantDefine define, Soil soil)
    {
        m_define = define;
        m_season = 1;
        owner = soil;
        m_growedTime = 0f;
        SwitchStage(0);
        m_matureTime = TimeConverter.DayToSecond(m_define.MatureTime);
    }

    public PlantEntityData()
    {
    }

    public void Load(PlantSaveData data,PlantDefine define)
    {
        this.currentStage = data.currentStage;
        this.m_growedTime = data.growedTime;
        this.m_season = data.season;
        this.m_define = define;
        m_matureTime = TimeConverter.DayToSecond(m_define.MatureTime);
    }

    public void Grow()//����
    {
        m_growedTime += 1;
        TryNextStage();
    }
    public void Grow(float time)//time��λΪ��(day)
    {
        m_growedTime += TimeConverter.DayToSecond(time);
        foreach(var port in m_define.GrowthPercentPort)
        {
            TryNextStage();
        }
    }

    void TryNextStage()
    {
        if (!harvestable && (m_growedTime / m_matureTime) >= m_define.GrowthPercentPort[currentStage+1])//����ͻ�ƿڲ��Ҳ����ջ��������һ�׶�
        {
            SwitchStage(++currentStage);
        }
    }

    void SwitchStage(int stage)
    {
        currentStage = stage;
        StageSwitchEvent?.Invoke(m_define.Animation[currentStage]);
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
        m_season++;
        m_growedTime = 0;
        SwitchStage(0);
    }
}
