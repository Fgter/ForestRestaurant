using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using QFramework;
using Define;

public class Soil : MonoBehaviour, IPointerClickHandler, IController
{
    public SoilEntityData data { get => _data; }
    SoilEntityData _data;
    [SerializeField]
    GameObject m_plantPrefab;
    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.instance.Show<UISeedBag>(new UISeedBagData(this));
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
