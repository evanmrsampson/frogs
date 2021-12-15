using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System.Linq;

public class Speaker : MonoBehaviour
{
    public RectTransform bubble;
    public RectTransform canvas;
    public float yOffset = 1;
    private Animator mouthAnimator;
    
    public void Start()
    {
        mouthAnimator = transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    [YarnCommand("setSpeaker")]
    public void HoverText()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(new Vector3(
            transform.position.x,
            transform.position.y + yOffset,
            transform.position.z
        ));
        Vector2 canvasPos = new Vector2(
            ((pos.x*canvas.sizeDelta.x)-(canvas.sizeDelta.x*0.5f)),
            ((pos.y*canvas.sizeDelta.y)-(canvas.sizeDelta.y*0.5f)));

        bubble.anchoredPosition = canvasPos;
        Debug.Log(string.Join(",", mouthAnimator.parameters.Select(x => x.name)));
        mouthAnimator.SetBool("isTalking", true);

    }

    [YarnCommand("stopTalking")]
    public void StopTalking()
    {
        mouthAnimator.SetBool("isTalking", false);
        bubble.gameObject.SetActive(false);
    }

}
