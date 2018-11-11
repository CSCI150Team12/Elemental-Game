using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpell : MonoBehaviour {

    public float scaleRate;
    private Spell spell;
    private SpellField field;
    private Vector3 scale;
    private float gravityModifier;

    private void Start()
    {
        scale = transform.localScale;
        transform.localScale = Vector3.zero;
        spell = GetComponent<Spell>();
        field = GetComponent<SpellField>();
        gravityModifier = field.gravityModifier;
        field.gravityModifier = 0f;
    }

    private void FixedUpdate()
    {
        if (transform.localScale.magnitude < scale.magnitude && spell.started && !spell.dying)
        {
            transform.localScale += Vector3.one * scaleRate;
        }
        if (spell.dying)
        {
            transform.localScale -= transform.localScale  / (spell.deathDelay*6);
        }
        field.gravityModifier = gravityModifier * transform.localScale.magnitude / scale.magnitude;
    }
}
