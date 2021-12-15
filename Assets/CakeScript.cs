using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CakeScript : MonoBehaviour
{
    private bool isDroppingCake;
    public float dropSpeed = 1f;
    public float targetY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDroppingCake || transform.position.y <= targetY)
        {
            return;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y - (dropSpeed * Time.deltaTime), transform.position.z);
    }

    [YarnCommand("drop")]
    public void Drop()
    {
        Debug.Log("hi");
        isDroppingCake = true;
    }
}
