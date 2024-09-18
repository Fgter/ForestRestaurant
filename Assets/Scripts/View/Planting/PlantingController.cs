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
    private void Start()
    {
        _model = this.GetModel<PlantModel>();
        Init();
    }

    void Init()
    {
        CreateSoil();
        CreatePlant();
    }

    private void CreatePlant()
    {
       foreach(var plant in _model.plants)
        {
            GameObject go = Instantiate(plantPrefab, this.transform);
            go.GetComponent<Plant>().Init(plant.Value, _model.soils[plant.Key]);

        }
    }

    void CreateSoil()
    {
       foreach(var soil in _model.soils.Values)
        {
            GameObject go = Instantiate(soilPrefab, this.transform);
            go.GetComponent<Soil>().Init(soil);
            go.transform.position = soil.position;
        }
    }
    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }
}
