using UnityEngine;
using QFramework;
using UnityEngine.UI;
using TMPro;
using System;

struct PopUISoilUnlockData : IUIData
{
    public Soil soil;
    public PopUISoilUnlockData(Soil soil)
    {
        this.soil = soil;
    }
}
public class PopUISoilUnlock : UIWindowBase
{
    [SerializeField]
    TextMeshProUGUI price;
    [SerializeField]
    Button btnUnlock;

    Soil _soil;

    private void Start()
    {
        btnUnlock.onClick.AddListener(UnlockSoil);
    }

    public override void OnShow(IUIData showData)
    {
        PopUISoilUnlockData data = (PopUISoilUnlockData)showData;
        _soil = data.soil;
        price.text = _soil.data.define.Price.ToString();
    }

    private void UnlockSoil()
    {
        if (_soil == null)
            return;
        if (this.SendCommand(new DecreaseGoldCommand(_soil.data.define.Price)))
            this.SendCommand(new UnlockSoilCommand(_soil));
        else
            UIManager.instance.ShowTip("moneyºÃÏñ²»Ì«¹»Å¶");
        this.CloseNo();
    }
}
