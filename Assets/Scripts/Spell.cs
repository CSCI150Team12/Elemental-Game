using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {
    public virtual void Die(float delay = 0f)
    {
        Destroy(gameObject, delay);
    }
}
