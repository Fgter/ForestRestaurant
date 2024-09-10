using UnityEngine;
using System;
using QFramework;

public class CommonMono : MonoBehaviour,IController
{
    static Action m_UpdateAction;
    static Action m_FixedUpdateAction;
    static Action m_QuitAction;

    public static void AddUpdateAction(Action fun) => m_UpdateAction += fun;
    public static void RemoveUpdateAction(Action fun) => m_UpdateAction -= fun;

    public static void AddFixedUpdateAction(Action fun) => m_FixedUpdateAction += fun;
    public static void RemoveFixedUpdateAction(Action fun) => m_FixedUpdateAction -= fun;

    public static void AddQuitAction(Action fun) => m_QuitAction += fun;
    public static void RemoveQuitAction(Action fun) => m_QuitAction -= fun;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Awake()
    {
        this.GetArchitecture();
    }
    private void Update()
    {
        m_UpdateAction?.Invoke();
    }

    private void FixedUpdate()
    {
        m_FixedUpdateAction?.Invoke();
    }

    private void OnApplicationQuit()
    {
        m_QuitAction?.Invoke();
    }

    public IArchitecture GetArchitecture()
    {
        return ForestRestaurant.Interface;
    }
}
