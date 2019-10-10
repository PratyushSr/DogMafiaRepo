using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    public Color defaultColor;
    public GameObject[] healthSegments;

    private float healthPerSeg;
    private float numOfSeg;
    private PlayerHealth pHealth;

    void Start()
    {
        pHealth = player.GetComponent<PlayerHealth>();
        numOfSeg = healthSegments.Length;
        healthPerSeg = pHealth.maxHealth / numOfSeg;
        for (int i = 0; i < numOfSeg; i++)
        {
            healthSegments[i].GetComponent<Image>().DOColor(defaultColor, 0f);
        }
    }

    // Update is called once per frame

    public void UpdateHealth()
    {
        Debug.Log("Health Updated: " + pHealth.currentHealth);
        for (int i = 0; i < numOfSeg; i++)
        {
            if(new Color(defaultColor.r, defaultColor.g, defaultColor.b, PercentFull(i)) != healthSegments[i].GetComponent<Image>().color)
            {
                healthSegments[i].GetComponent<Transform>().DOShakePosition(.5f, 15, 10);
            }
            //healthSegments[i].GetComponent<Image>().color = new Color(defaultColor.r, defaultColor.g, defaultColor.b, PercentFull(i));
            healthSegments[i].GetComponent<Image>().DOFade(PercentFull(i), .5f);

        }
    }
    float PercentFull(int index)
    {
        float lowerBound = index * healthPerSeg;
        float upperBound = (index + 1) * healthPerSeg;


        if(pHealth.currentHealth >= upperBound)
        {
            return 1;
        }else if (pHealth.currentHealth <= lowerBound)
        {
            return 0;
        }
        else
        {
            return (pHealth.currentHealth % healthPerSeg) / healthPerSeg;

        }

    }
}

