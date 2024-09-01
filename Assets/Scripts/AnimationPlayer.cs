using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

public class AnimationPlayer:MonoBehaviour
{
    Sprite[] sprites;
    SpriteRenderer spriteRenderer;
    Coroutine cor;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetAnimation(string animationName,bool play=true)
    {
        sprites = ResLoader.LoadAll<Sprite>(PathConfig.AnimationPath + animationName);
        if (!play) return;
        if (cor != null)
            Stop();
        if (sprites.Length <= 0)
        {
            Debug.LogError("Animation:" + animationName + "can not find");
            return;
        }
        cor = StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        int i = 0;
        WaitForSeconds seconds = new WaitForSeconds(0.1f);
        while(this!=null)
        {
            spriteRenderer.sprite = sprites[i];
            i = ++i % sprites.Length;
            yield return seconds;
        }
    }

    public void Stop()
    {
        StopCoroutine(cor);
    }
}
