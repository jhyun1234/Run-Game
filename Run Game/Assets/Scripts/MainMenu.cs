using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Animator animator;
    public void Execute()
    {

        animator.SetTrigger("Start");
        startButton.interactable = false;
        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.GAME));


    }
}
