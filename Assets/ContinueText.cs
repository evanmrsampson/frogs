using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class ContinueText : MonoBehaviour
{
    public DialogueUI ui;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ui.MarkLineComplete();
        }
    }
}
