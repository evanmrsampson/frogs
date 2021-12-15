using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FadeOut : MonoBehaviour
{
    public bool FadeIn = true;
    public float fadeRate = 15f;
    private SpriteRenderer rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var color = rend.color;
        if (FadeIn && color.a >= 0)
        {
            color.a -= fadeRate * Time.deltaTime;
            rend.color = color;
            return;
        }

        if (!FadeIn && color.a <= 255)
        {
            color.a += fadeRate * Time.deltaTime;
            rend.color = color;
            return;
        }
    }

    [YarnCommand("fadeOut")]
    public void ByeBye()
    {
        FadeIn = false;
    }
}
