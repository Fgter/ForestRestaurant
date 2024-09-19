using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    float sensitivity = 1;
    [SerializeField]
    Vector2 horizontalArea;
    [SerializeField]
    Vector2 verticalArea;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            float x = Mathf.Clamp(transform.position.x - Input.GetTouch(0).deltaPosition.x * sensitivity * 0.01f, horizontalArea.x, horizontalArea.y);
            float y = Mathf.Clamp(transform.position.y - Input.GetTouch(0).deltaPosition.y * sensitivity * 0.01f, verticalArea.x, verticalArea.y);
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
