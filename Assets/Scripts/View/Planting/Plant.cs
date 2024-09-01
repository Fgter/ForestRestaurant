using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using QFramework;
using UnityEngine.EventSystems;

public class Plant : MonoBehaviour,IController,IPointerClickHandler
{
    public Soil soil { get; private set; }
    PlantEntityData m_entityData;
    AnimationPlayer anim;

    public void Init(PlantEntityData entityData,Soil soil)
    {
        m_entityData = entityData;
        this.soil = soil;
        anim = GetComponent<AnimationPlayer>();
        m_entityData.StageSwitchEvent += SwitchAnimation;
        RefreshAnimation();
    }

    void SwitchAnimation(string path)
    {
        anim.SetAnimation(path);
    }

    void RefreshAnimation()
    {
        anim.SetAnimation(m_entityData.define.Animation[m_entityData.currentStage]);
    }

    void Harvest()
    {
        if( m_entityData.TryHarvest())
        {
            PlantDefine define = m_entityData.define;
            this.SendCommand(new AddItemCommond(define.HarvestId,Random.Range(define.HarvestCountMin,define.HarvestCountMax)));
        }
        if (m_entityData.canReGrow)
        {
            m_entityData.ReGrow();
        }
        else
        {
            this.SendCommand(new ClearSoilCommond(soil));
            Destroy(gameObject);
        }
    }

    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Harvest();
    }
}
