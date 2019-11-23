using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public static FadeInOut instance;

    public RawImage fadeOutUIImage;

    public string SceneToLoad;
//    public GameObject fadeInPanel;
//    public GameObject fadeOutPanel;
    public float fadeWait;

    public enum FadeDirection
    {
        In, //Alpha = 1
        Out, //Alpha = 0
    }
    private void Awake()
    {
        Debug.Log("inside FadeInOut Awake");
        if (instance != null)
        {
            Debug.LogWarning("Instance equals to null" + gameObject.name);
        }
        else
        {
            instance = this;
        }
        
//        if (fadeInPanel != null)
//        {
//            GameObject panel = Instantiate(fadeInPanel, Vector3.zero,Quaternion.identity) as GameObject;
//            Destroy(panel,1);
//        }

    }

    public void OnEnable()
    {
        StartCoroutine(FadeCo(FadeDirection.Out));
    }

//    public void LateUpdate()
//    {
//        if (DialogueManager.instance.getEndOfDialogue())
//        {
//            startFade(SceneToLoad);
//        }
//    }

//    public Vector2 playerPosition;
//    public VectorValue playerStorage;

//    public void startFade(string scene)
//    {
//        Debug.Log("inside startFade");
//        SceneToLoad = scene;
//        StartCoroutine(FadeCo());
//    }
//    
    public IEnumerator FadeCo(FadeDirection fadeDirection)
    {
        Debug.Log("inside FadeCo IEnumerator");

        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 0 : 1;

        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }

            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }  
        }



//        if(fadeOutPanel != null) 
//            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
//        yield return new WaitForSeconds(fadeWait);
//        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);
//        while (!asyncOperation.isDone)
//        {
//            yield return null;
//        }

    }

    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection)
    {
        yield return FadeCo(fadeDirection);
        SceneManager.LoadScene(SceneToLoad);
    }
    
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);

        alpha += Time.deltaTime * (1.0f / fadeWait) + ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }
}