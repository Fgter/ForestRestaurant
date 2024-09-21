using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScenePlanting : MonoBehaviour
{
    [SerializeField]
    Button _btnBag;
    [SerializeField]
    Button _btnResturant;

    private void Start()
    {
        _btnBag.onClick.AddListener(OpenBag);
        _btnResturant.onClick.AddListener(OpenSceneResturant);
    }

    private void OpenSceneResturant()
    {
        SceneLoader.instance.LoadSceneAsync("³óÍÃ×ÓµÄ²âÊÔ");
    }

    private void OpenBag()
    {
        UIManager.instance.Show<UIBag>(null);
    }


}
