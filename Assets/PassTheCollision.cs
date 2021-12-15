using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTheCollision : MonoBehaviour
{
    public CandleGame master;
    void OnTriggerEnter(Collider collider)
    {
        master.SetCandle(collider.gameObject);
    }

    void OnTriggerExit(Collider collider)
    {
        master.RemoveCandle(collider.gameObject);
    }
}
