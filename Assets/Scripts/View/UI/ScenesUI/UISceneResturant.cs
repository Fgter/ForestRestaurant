using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISceneResturant : MonoBehaviour
{
    [SerializeField]
    Button _btnFoodMenu;
    [SerializeField]
    Button _btnCashRegister;
    [SerializeField]
    Button _btnMessageBoards;
    [SerializeField]
    Button _btnPlanting;

    private void Start()
    {
        _btnFoodMenu.onClick.AddListener(OpenFoodMenu);
        _btnCashRegister.onClick.AddListener(OpenCashRegister);
        _btnMessageBoards.onClick.AddListener(OpenMessageBoard);
        _btnPlanting.onClick.AddListener(OpenScenePlanting);
    }

    private void OpenScenePlanting()
    {
        SceneLoader.instance.LoadSceneAsync("Test");
    }

    private void OpenMessageBoard()
    {
        UIManager.instance.Show<UIMessageBoards>(null);
    }

    private void OpenCashRegister()
    {
        UIManager.instance.Show<UICashRegister>(null);
    }

    private void OpenFoodMenu()
    {
        UIManager.instance.Show<UIFoodMenu>(null);
    }
}
