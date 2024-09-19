using Define;
using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public struct PopUIPlantInfoData : IUIData
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
    TextMeshProUGUI _name;
    [SerializeField]
    TextMeshProUGUI _season;
    [SerializeField]
    TextMeshProUGUI _stageName;
    [SerializeField]
    TextMeshProUGUI _needtime;
    [SerializeField]
    TextMeshProUGUI _progressText;
    [SerializeField]
    Image _proress;
    [SerializeField]
    Button _btnHarvest;

    StringBuilder _sb;
    Plant _plant;
    PlantEntityData _data;
    PlantDefine _define;

    public override void OnShow(IUIData uiData)
    {
        PopUIPlantInfoData udata = (PopUIPlantInfoData)uiData;
        _plant = udata.plant;
        _data = _plant.entityData;
        _define = _data.define;
        _sb = new StringBuilder();

        _needtime.gameObject.SetActive(true);
        RefreshUI();
    }

    private void Start()
    {
        _btnHarvest.onClick.AddListener(Harvest);
        TimeSystem.RegisterSecondUpdateAction(RefreshUI);
    }
    public override void OnDestroyClose()
    {
        TimeSystem.UnRegisterSecondUpdateAction(RefreshUI);
    }

    void Harvest()
    {
        _plant?.Harvest();
        this.HideNo();
    }
    void RefreshUI()
    {
        if (_plant == null || _data == null || _define == null)
            return;
        _name.text = _define.Name;
        _season.text = FormatSeason(_data.season, _define.SeasonCount);
        _stageName.text = FormatStageName(_define.StagesName[_data.currentStage]);
        if (_data.harvestable)
            _needtime.gameObject.SetActive(false);
        else
        {
            _needtime.text = FormatTime(GetNeedTime());
        }
        SetPercent();
        _btnHarvest.interactable = _data.harvestable;
    }
    string FormatSeason(int currentSeason, int seasonCount)
    {
        _sb.Clear();
        _sb.AppendFormat("第{0}/{1}季", currentSeason, seasonCount);
        return _sb.ToString();
    }

    string FormatStageName(string stageName)
    {
        _sb.Clear();
        _sb.AppendFormat("({0})", stageName);
        return _sb.ToString();
    }

    float GetNeedTime()
    {
        if (_data.harvestable)
            return 0;
        float time = _define.GrowthPercentPort[_data.currentStage + 1] * _define.MatureTime - _data.growedTime;
        return time > 0 ? time : 0;
    }
    string FormatTime(float time)
    {
        TimeSpan t = TimeSpan.FromDays(time);
        double totalSeconds = Math.Round(t.TotalSeconds);
        TimeSpan roundedTimespawn = TimeSpan.FromSeconds(totalSeconds);
        _sb.Clear();
        _sb.AppendFormat("{0}:{1}:{2} 后进入下一生长阶段", roundedTimespawn.Days * 24 + roundedTimespawn.Hours, roundedTimespawn.Minutes, roundedTimespawn.Seconds);
        return _sb.ToString();
    }

    float GetPercent()
    {
        float percent = _data.growedTime / _define.MatureTime;
        return percent > 1 ? 1 : percent;
    }

    void SetPercent()
    {
        float percent = GetPercent();
        _sb.Clear();
        _sb.AppendFormat("{0}%", MathF.Round(percent * 100, 2));
        _progressText.text = _sb.ToString();
        _proress.fillAmount = percent;
    }
}
