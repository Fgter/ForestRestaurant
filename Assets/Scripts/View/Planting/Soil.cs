using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using QFramework;
using Define;

public class Soil : MonoBehaviour, IPointerClickHandler, IController
{
    public int Id { get => 0; }
    public bool havePlant { get => plant != null; }
    public Plant plant { get; set; }

    [SerializeField]
    GameObject m_plantPrefab;
    [SerializeField]
    SoilDefine define;
    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.instance.Show<UISeedBag>(new UISeedBagData(this));
    }

    public bool GrowPlant(int id)
    {
        if (havePlant)
            return false;
        if (this.SendCommand(new GrowPlantCommond(id, this, m_plantPrefab)) != null)
            return true;
        else
            return false;
    }

    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }
}
