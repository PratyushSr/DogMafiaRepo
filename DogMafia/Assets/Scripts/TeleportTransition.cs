using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTransition : MonoBehaviour
{
    public GameObject Fader;
    public Vector2 teleportToPosition;
    private Animator anim;
    
//    public VectorValue playerStorage;
//    public GameObject fadeInPanel;
//    public GameObject fadeOutPanel;
    public float fadeWait;
    

    private void Awake()
    {
        if (Fader != null)
        {
            anim = Fader.GetComponent<Animator>();
//            GameObject panel = Instantiate(fadeInPanel, Vector3.zero,Quaternion.identity) as GameObject;
//            Destroy(panel,1);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            FadeOut();
            Invoke("GoToDestination",0.5f);
            Invoke("FadeIn", fadeWait);
            //SceneManager.LoadScene(SceneToLoad);
        }
    }

    public void GoToDestination()
    {
        GameManager.instance.player.position = teleportToPosition;
    }

    public void FadeOut()
    {
        anim.SetBool("FadeI", false);
        anim.SetBool("FadeO", true);
    }

    public void FadeIn()
    {
        anim.SetBool("FadeO", false);
        anim.SetBool("FadeI", true);
    }
    

//    public IEnumerator FadeCo()
//    {
//        if(fadeOutPanel != null) 
//            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);
//        yield return new WaitForSeconds(fadeWait);
//        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);
//        while (!asyncOperation.isDone)
//        {
//            yield return null;
//        }
//    }
}
