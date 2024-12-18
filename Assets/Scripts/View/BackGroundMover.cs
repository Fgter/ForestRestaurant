using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackGroundMover : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    float sensitivity = 1;
    [SerializeField]
    [Tooltip("x是较小值，y是较大值")]
    Vector2 horizontalArea;
    [Tooltip("x是较小值，y是较大值")]
    [SerializeField]
    Vector2 verticalArea;

    bool _darg;
    float x;
    float y;
    private void Update()
    {
        if (_darg && Input.touchCount > 0)
        {
            x = Mathf.Clamp(Camera.main.transform.position.x - Input.GetTouch(0).deltaPosition.x * sensitivity , horizontalArea.x, horizontalArea.y);
            y = Mathf.Clamp(Camera.main.transform.position.y - Input.GetTouch(0).deltaPosition.y * sensitivity , verticalArea.x, verticalArea.y);
           
        }
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(x, y, -10),Time.deltaTime) ;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _darg = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _darg = true;
    }
}
