using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoSpell : MonoBehaviour {
    public float wobble;

    private void Update()
    {
        transform.position +=  new Vector3(Random.Range(-wobble, wobble), 0, Random.Range(-wobble, wobble)) * Time.deltaTime;
    }

}
