using QFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UICashRegister : UIWindowBase
{
    [SerializeField]
    Button _back;
    [SerializeField]
    TMP_Text _GoldSum;
    [SerializeField]
    Button _Cash;
    private void Start()
    {
        this.RegisterEvent<UpdateCashRegisterUIEvent>(v =>
        {
            UpdateGold();
        });
        _back.onClick.AddListener(() =>
        {
            UIManager.instance.Close(typeof(UICashRegister));
        });
        _Cash.onClick.AddListener(() =>
        {
            this.SendCommand<CollectRestaurantGoldCommand>();
        });
        
    }
    public override void OnShow(IUIData showData)
    {
        UpdateGold();
    }
    void UpdateGold()
    {
        _GoldSum.text = $"µ±Ç°½ð±Ò:{this.SendQuery(new GetCashRegisterGoldSumQuery())}";
    }
}
