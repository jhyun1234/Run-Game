using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public enum SceneID
{
    TITLE,
    GAME,
}


public class AsyncSceneLoader : Singleton<AsyncSceneLoader>
{

    [SerializeField] float time;
    [SerializeField] Image fadeImage;

    public IEnumerator FadeIn()
    {
        Color color = fadeImage.color;

        color.a = 1.0f;

        fadeImage.gameObject.SetActive(true);
        while(color.a >0f)
        {
            color.a -= Time.deltaTime;
            fadeImage.color = color;
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(SceneID sceneID)
    {
        fadeImage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneID);

        // bool allowSceneActivation : 장면이 준비되는 즉시 장면을 활성화시킬 것 인지 허용하는 기능이다.

        asyncOperation.allowSceneActivation = false;

        Color color = fadeImage.color;

        color.a = 0f;


        // bool isDone : 해당 동작이 준비되었는지 판단하는 기능이다.

        while(asyncOperation.isDone ==false)
        {
            color.a += Time.deltaTime;
            fadeImage.color = color;

           // float progress : 작업의 진행 정도를 0~1 사이의 값으로 확인하는 기능이다.
            if(asyncOperation.progress >=0.9f)
            {
                // color의 alpha 값을 1.0f로 Lerp 함수를 통해서 올려준다.
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                fadeImage.color = color;
                // alpha값이 1.0보다 크거나 같다면 
                if(color.a>=1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
                // allowSceneActivation 을 활성화 한다.
            }

            yield return null;

        }




    }

    private void OnEnable()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
   
}
