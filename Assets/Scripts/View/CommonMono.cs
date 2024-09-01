using UnityEngine;
using System;

public class CommonMono : MonoBehaviour
{
    static Action m_UpdateAction;
    static Action m_FixedUpdateAction;

    public static void AddUpdateAction(Action fun) => m_UpdateAction += fun;
    public static void RemoveUpdateAction(Action fun) => m_UpdateAction -= fun;

    public static void AddFixedUpdateAction(Action fun) => m_FixedUpdateAction += fun;
    public static void RemoveFixedUpdateAction(Action fun) => m_FixedUpdateAction -= fun;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        m_UpdateAction?.Invoke();
    }

    private void FixedUpdate()
    {
        m_FixedUpdateAction?.Invoke();
    }
}
