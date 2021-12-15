using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CandleGame : MonoBehaviour
{
    public GameObject mainFrog;
    public Animator mouthAnimator;
    public float moveSpeed = 1.5f;
    public float maxDistance = 4f;
    public Sprite blownOutCandle;
    private int direction = 1; //right
    private bool canBlow = true;
    public int canBlowCooldownFrames = 90; 
    private int canBlowCounter = 0;
    private GameObject currentCandle;
    public bool isStarted {get; set;} = false;
    private int candleCounter;
    private int totalCandles = 8;
    public DialogueRunner runner;

    // Update is called once per frame
    void Update()
    {
        if (!isStarted)
        {
            return;
        }

        // move!
        var newX = mainFrog.transform.position.x + (moveSpeed * Time.deltaTime * direction);
        if (Mathf.Abs(newX) >= maxDistance)
        {
            direction *= -1;
            newX = mainFrog.transform.position.x + (moveSpeed * Time.deltaTime * direction);
        }

        mainFrog.transform.position = new Vector3(
            newX,
            mainFrog.transform.position.y,
            mainFrog.transform.position.z
        );

        if (candleCounter == totalCandles && (mainFrog.transform.position.x <= 0.1 && mainFrog.transform.position.x >= -0.1))
        {
            runner.StartDialogue("end");
            Destroy(this);
        }
        
        if (!canBlow)
        {
            mouthAnimator.SetBool("isBlowing", false);
            canBlowCounter++;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            mouthAnimator.SetBool("isBlowing", true);
            canBlow = false;
        }

        if (mouthAnimator.GetCurrentAnimatorStateInfo(0).IsName("blowing"))
        {
            if (currentCandle != null)
            {
                currentCandle.GetComponent<Animator>().enabled = false;
                currentCandle.GetComponent<SpriteRenderer>().sprite = blownOutCandle;
                currentCandle.GetComponent<CapsuleCollider>().enabled = false;
                currentCandle = null;
                candleCounter++;
                Debug.Log(candleCounter);
                moveSpeed += 0.25f;
            }

            return;
        }

        if (canBlowCounter >= canBlowCooldownFrames)
        {
            canBlow = true;
            canBlowCounter = 0;
        }
    }

    public void SetCandle(GameObject candle)
    {
        currentCandle = candle;
    }

    public void RemoveCandle(GameObject candle)
    {
        if (GameObject.ReferenceEquals(candle, currentCandle))
        {
            currentCandle = null;
        }
    }

    [YarnCommand("startMiniGame")]
    public void StartMiniGame()
    {
        isStarted = true;
    }
}
