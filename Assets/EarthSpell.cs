using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpell : Spell
{

    public bool dying = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dying)
        {
            Slide(-5f, -1.1f, 1);
        }
        else
        {
            Slide(5f, -1.1f, 1);
        }
        
	}

    public override void Die(float delay)
    {
        dying = true;
        base.Die(2f);
    }

    void Slide(float speed, float min, float max)
    {
        if ((transform.position.y < max && speed > 0) || (transform.position.y > min && speed < 0 ))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
