using Define;
using QFramework;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plant : MonoBehaviour, IController, IPointerClickHandler
{
    public SoilEntityData soil { get; private set; }
    public PlantEntityData entityData { get; private set; }
    AnimationPlayer anim;

    public void Init(PlantEntityData entityData, SoilEntityData soil)
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
            int count = Random.Range(define.HarvestCountMin, define.HarvestCountMax);
            this.SendCommand(new AddItemCommand(define.HarvestId, count));
            var harvest = this.SendQuery(new GetDefineQuery<HarvestDefine>(define.HarvestId));
            UIManager.instance.ShowTip(string.Format("»ñµÃ {0} * {1}", harvest.Name, count));
            if (entityData.canReGrow)
            {
                entityData.ReGrow();
            }
            else
            {
                this.SendCommand(new ClearSoilCommand(soil));
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
