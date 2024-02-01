using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] int score;

    void Start()
    {
        StartCoroutine(IncreaseScore());
    }

    IEnumerator IncreaseScore()
    {
        while(GameManager.instance.state)
        {
         yield return CoroutineCache.WaitForSeconds(0.25f);
            if(GameManager.instance.state ==false)
            {

                 DataManager.instance.RenewalScore(score);

                yield break;
            }

              score = score + 10;
              
              scoreText.text = score.ToString() + "m";


        }


        
    }

}
