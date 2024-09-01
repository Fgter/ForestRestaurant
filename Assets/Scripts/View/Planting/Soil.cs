using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using QFramework;

public class Soil : MonoBehaviour, IPointerClickHandler,IController
{
    public bool havePlant { get => plant != null; }
    public Plant plant { get; set; }

    [SerializeField]
    GameObject m_plantPrefab;
    public void OnPointerClick(PointerEventData eventData)
    {
       
    }

    public void GrowPlant(int id)
    {
        this.SendCommand(new GrowPlantCommond(id, this, m_plantPrefab));
    }

    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }
}
