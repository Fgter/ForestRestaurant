using Models;
using QFramework;
using UnityEngine;

public class PlantingController : MonoBehaviour, IController
{
    [SerializeField]
    GameObject plantPrefab;
    [SerializeField]
    GameObject soilPrefab;

    PlantModel _model;
    Sprite normalSoilSprite;
    Sprite lockSoilSprite;
    private void Start()
    {
        normalSoilSprite = ResLoader.Load<Sprite>(PathConfig.SoilSpritePath);
        lockSoilSprite = ResLoader.Load<Sprite>(PathConfig.lockSoilSpritePath);
        _model = this.GetModel<PlantModel>();
        Init();
        this.RegisterEvent<UnlockSoilEvent>(v => RefreshSoil(v.soil));
    }

    void Init()
    {
        CreateSoil();
        CreatePlant();
    }

    private void CreatePlant()
    {
        foreach (var plant in _model.plants)
        {
            GameObject go = Instantiate(plantPrefab, this.transform);
            go.GetComponent<Plant>().Init(plant.Value, _model.soils[plant.Key]);

        }
    }

    void CreateSoil()
    {
        foreach (var soil in _model.soils.Values)
        {
            GameObject go = Instantiate(soilPrefab, this.transform);
            go.GetComponent<Soil>().Init(soil);
            go.transform.position = soil.position;
            if (soil.unlock)
                go.GetComponent<SpriteRenderer>().sprite = normalSoilSprite;
            else
                go.GetComponent<SpriteRenderer>().sprite = lockSoilSprite;
        }
    }

    /// <summary>
    /// 解锁土地的时候更新表现
    /// </summary>
    void RefreshSoil(Soil soil)
    {
        soil.GetComponent<SpriteRenderer>().sprite = normalSoilSprite;
    }
    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }
}
