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
            color.a -= Time.unscaledDeltaTime;
            fadeImage.color = color;
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(SceneID sceneID)
    {
        fadeImage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneID);

        // bool allowSceneActivation : ����� �غ�Ǵ� ��� ����� Ȱ��ȭ��ų �� ���� ����ϴ� ����̴�.

        asyncOperation.allowSceneActivation = false;

        Color color = fadeImage.color;

        color.a = 0f;


        // bool isDone : �ش� ������ �غ�Ǿ����� �Ǵ��ϴ� ����̴�.

        while(asyncOperation.isDone ==false)
        {
            color.a += Time.unscaledDeltaTime;
            fadeImage.color = color;

           // float progress : �۾��� ���� ������ 0~1 ������ ������ Ȯ���ϴ� ����̴�.
            if(asyncOperation.progress >=0.9f)
            {
                // color�� alpha ���� 1.0f�� Lerp �Լ��� ���ؼ� �÷��ش�.
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                fadeImage.color = color;
                // alpha���� 1.0���� ũ�ų� ���ٸ� 
                if(color.a>=1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
                // allowSceneActivation �� Ȱ��ȭ �Ѵ�.
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
