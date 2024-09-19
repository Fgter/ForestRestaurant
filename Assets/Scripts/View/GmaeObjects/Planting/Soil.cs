using QFramework;
using UnityEngine;
using UnityEngine.EventSystems;

public class Soil : MonoBehaviour, IPointerClickHandler, IController
{
    public SoilEntityData data { get => _data; }
    SoilEntityData _data;
    [SerializeField]
    GameObject m_plantPrefab;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_data.unlock)
            UIManager.instance.Show<UISeedBag>(new UISeedBagData(this));
        else
            UIManager.instance.ShowPop<PopUISoilUnlock>(new PopUISoilUnlockData(this),transform);
    }
    public void Init(SoilEntityData data)
    {
        _data = data;
    }

    public bool GrowPlant(int id)
    {
        if (_data.havePlant)
            return false;
        if (this.SendCommand(new GrowPlantCommand(id, this, m_plantPrefab)) != null)
            return true;
        else
            return false;
    }

    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }
}
