using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
using QFramework;
using UnityEngine.EventSystems;

public class Plant : MonoBehaviour,IController,IPointerClickHandler
{
    public Soil soil { get; private set; }
    public PlantEntityData entityData { get; private set; }
    AnimationPlayer anim;

    public void Init(PlantEntityData entityData,Soil soil)
    {
        this.entityData = entityData;
        this.soil = soil;
        anim = GetComponent<AnimationPlayer>();
        this.entityData.StageSwitchEvent += SwitchAnimation;
        RefreshAnimation();
    }
    public void Harvest()
    {
        if (entityData.TryHarvest())
        {
            PlantDefine define = entityData.define;
            this.SendCommand(new AddItemCommond(define.HarvestId, Random.Range(define.HarvestCountMin, define.HarvestCountMax)));
            if (entityData.canReGrow)
            {
                entityData.ReGrow();
            }
            else
            {
                this.SendCommand(new ClearSoilCommond(soil));
                Destroy(gameObject);
            }
        }

    }
    void SwitchAnimation(string path)
    {
        anim.SetAnimation(path);
    }

    void RefreshAnimation()
    {
        anim.SetAnimation(entityData.define.Animation[entityData.currentStage]);
    }



    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.instance.ShowPop<PopUIPlantInfo>(new PopUIPlantInfoData(this), transform);
    }
}
