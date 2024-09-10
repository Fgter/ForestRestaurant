using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Define;
using System.Text;
using System;
using TMPro;

public class PopUIPlantInfoData : IUIData
{
    public PopUIPlantInfoData(Plant plant)
    {
        this.plant = plant;
    }
    public Plant plant;
}
public class PopUIPlantInfo : UIWindowBase
{
    [SerializeField]
    TextMeshProUGUI m_name;
    [SerializeField]
    TextMeshProUGUI m_season;
    [SerializeField]
    TextMeshProUGUI m_stageName;
    [SerializeField]
    TextMeshProUGUI m_needtime;
    [SerializeField]
    TextMeshProUGUI m_progressText;
    [SerializeField]
    Image m_proress;
    [SerializeField]
    Button m_btnHarvest;

    StringBuilder m_sb;
    Plant m_plant;
    PlantEntityData m_data;
    PlantDefine m_define;

    public override void OnShow(IUIData uiData)
    {
        PopUIPlantInfoData udata = uiData as PopUIPlantInfoData;
        m_plant = udata.plant;
        m_data = m_plant.entityData;
        m_define = m_data.define;
        m_sb = new StringBuilder();

        m_needtime.gameObject.SetActive(true);
        RefreshUI();
    }

    private void Start()
    {
        m_btnHarvest.onClick.AddListener(Harvest);
        TimeSystem.AddSecondUpdateAction(RefreshUI);
    }
    public override void OnDestroyClose()
    {
        TimeSystem.RemoveSecondUpdateAction(RefreshUI);
    }

    void Harvest()
    {
        m_plant?.Harvest();
        this.HideNo();
    }
    void RefreshUI()
    {
        if (m_plant == null || m_data == null || m_define == null)
            return;
        m_name.text = m_define.Name;
        m_season.text = FormatSeason(m_data.season, m_define.SeasonCount);
        m_stageName.text = FormatStageName(m_define.StagesName[m_data.currentStage]);
        if (m_data.harvestable)
            m_needtime.gameObject.SetActive(false);
        else
        {
            m_needtime.text = FormatTime(GetNeedTime());
        }
        SetPercent();
        m_btnHarvest.interactable = m_data.harvestable;
    }
    string FormatSeason(int currentSeason, int seasonCount)
    {
        m_sb.Clear();
        m_sb.AppendFormat("第{0}/{1}季", currentSeason, seasonCount);
        return m_sb.ToString();
    }

    string FormatStageName(string stageName)
    {
        m_sb.Clear();
        m_sb.AppendFormat("({0})", stageName);
        return m_sb.ToString();
    }

    float GetNeedTime()
    {
        if (m_data.harvestable)
            return 0;
        float time = m_define.GrowthPercentPort[m_data.currentStage + 1] * m_define.MatureTime - m_data.growedTime;
        return time > 0 ? time : 0;
    }
    string FormatTime(float time)
    {
        TimeSpan t = TimeSpan.FromDays(time);
        double totalSeconds = Math.Round(t.TotalSeconds);
        TimeSpan roundedTimespawn = TimeSpan.FromSeconds(totalSeconds);
        m_sb.Clear();
        m_sb.AppendFormat("{0} 后进入下一生长阶段", roundedTimespawn.ToString(@"hh\:mm\:ss"));
        return m_sb.ToString();
    }

    float GetPercent()
    {
        float percent = m_data.growedTime / m_define.MatureTime;
        return percent > 1 ? 1 : percent;
    }

    void SetPercent()
    {
        float percent = GetPercent();
        m_sb.Clear();
        m_sb.AppendFormat("{0}%", MathF.Round(percent * 100, 2));
        m_progressText.text = m_sb.ToString();
        m_proress.fillAmount = percent;
    }
}
