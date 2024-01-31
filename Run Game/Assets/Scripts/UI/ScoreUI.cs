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
        
    }

    IEnumerator IncreaseScore()
    {
        yield return CoroutineCache.WaitForSeconds(0.25f);
    }

}
