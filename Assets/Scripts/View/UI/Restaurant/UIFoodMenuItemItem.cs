using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIFoodMenuItemItem : MonoBehaviour
{
    [SerializeField]
    TMP_Text text;
    [SerializeField]
    Image image;
    public void Set(string text, Sprite sprite)
    {
        this.text.text = text;
        image.sprite = sprite;
    }
}

