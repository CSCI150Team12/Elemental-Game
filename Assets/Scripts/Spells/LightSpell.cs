using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpell : MonoBehaviour
{

    public float duration;
    private void Start()
    {
        StartCoroutine(Blind());
    }

    IEnumerator Blind()
    {
        for (int i = 1; i <= 4; i++)
        {
            GlobalVariables.LightIntensity = i;
            yield return new WaitForSeconds(.05f);
        }

        yield return new WaitForSeconds(duration);

        for (int i = 4; i >= 1; i--)
        {
            GlobalVariables.LightIntensity = i;
            yield return new WaitForSeconds(.05f);

        }
        yield return new WaitForSeconds(0);
        
    }
}
