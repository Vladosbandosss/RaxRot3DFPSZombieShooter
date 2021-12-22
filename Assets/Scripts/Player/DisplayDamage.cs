using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] private Canvas damageRecieve;
    [SerializeField] private float impactTime = 0.3f;
    
    void Start()
    {
        damageRecieve.enabled = false;
    }
    
    public void ShowDamageCanvas()
    {
        StartCoroutine(nameof(ShowDamage));
    }

    IEnumerator ShowDamage()
    {
        damageRecieve.enabled = true;
        yield return new WaitForSeconds(impactTime);
        damageRecieve.enabled = false;
    }
}
