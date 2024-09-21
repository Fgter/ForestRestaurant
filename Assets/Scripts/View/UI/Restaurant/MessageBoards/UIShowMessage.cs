using UnityEngine;
using TMPro;
using UnityEngine.UI;
/// <summary>
/// 显示留言板信息
/// </summary>
public class UIShowMessage : UIWindowBase
{
    [SerializeField]
    TMP_Text _text;
    [SerializeField]
    Button _back;
    [SerializeField]
    Image image;
    private void Start()
    {
        _back.onClick.AddListener(() =>
        {
            UIManager.instance.Close(typeof(UIShowMessage));
        });
    }
    public override void OnShow(IUIData showData)
    {

    }
    public void Set(string text,Sprite sprite) 
    {
        _text.text = text;
        image.sprite = sprite;
    }
}

