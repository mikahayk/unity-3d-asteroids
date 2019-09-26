using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class CountdownController : MonoBehaviour
{
    public int timeLeft = 60; 
    public Text countdown;
    private GameController myController;
    void Start()
    {
        myController = FindObjectOfType<GameController>();
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }
    void Update()
    {
        if(myController.isGameOver != true)
        {
            countdown.text = ("TIME LEFT 00:" + timeLeft);
        }
        if(timeLeft <= 0)
        {
            countdown.text = ("TIME IS UP");
        }
        
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
            if(timeLeft == -1)
            {
                myController.GameOver();
            }
        }


    }
}