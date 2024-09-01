using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using QFramework;
using System;

public class PlantEntityData
{
    public Action<string> StageSwitchEvent;
    public int currentStage { get; set; }
    public bool harvestable { get => currentStage >= m_define.GrowthStageCount-1; }
    public float growedTime { get => TimeConverter.SecondToDay(m_growedTime); }//已经生长了多长时间,天为单位
    public Soil owner { get; set; }//种在哪块土地上
    public int season { get => m_season; }
    public bool canReGrow { get => m_season < define.SeasonCount; }
    public PlantDefine define { get => m_define; }

    PlantDefine m_define;
    float m_growedTime = 0f;//已经生长了多长时间,秒为单位
    float m_matureTime;//成熟所需时间,秒为单位
    int m_season;//当前处于第几季

    public PlantEntityData(PlantDefine define, Soil soil)
    {
        m_define = define;
        m_season = 1;
        owner = soil;
        m_growedTime = 0f;
        SwitchStage(0);
        m_matureTime = TimeConverter.DayToSecond(m_define.MatureTime);
    }

    public void Grow()//生长
    {
        m_growedTime += 1;
        TryNextStage();
    }
    public void Grow(float time)//time单位为天(day)
    {
        m_growedTime += TimeConverter.DayToSecond(time);
        foreach(var port in m_define.GrowthPercentPort)
        {
            TryNextStage();
        }
    }

    void TryNextStage()
    {
        if ((m_growedTime / m_matureTime) >= m_define.GrowthPercentPort[currentStage] && !harvestable)//到达突破口并且不可收获则进入下一阶段
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
