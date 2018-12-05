using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {


    public Transform followMarker;
    Rigidbody _body;

    void Start()
    {
        // Eject from our place in the child hierarchy,
        // so the parent's transform no longer affects us.
        followMarker = new GameObject().transform;
        followMarker.rotation = transform.rotation;
        followMarker.position = transform.position;
        followMarker.parent = transform.parent;
        PositionModifier pos = followMarker.gameObject.AddComponent<PositionModifier>();
        /*
        pos.focusPoint = followMarker.parent;
        pos.dynamic = false;
        pos.focusTimeOscillation = false;
        pos.focusOscillation = true;
        pos.oscillationAmplitude = Vector3.up * 0.01f;
        pos.oscillationRate = 1f;*/
        pos.velocity = new Vector3(0, -1, 0);
        pos.focusPoint = GameObject.Find("Player2").transform;
        pos.minPosition = Vector3.zero;
        pos.maxPosition = Vector3.one;
        pos.oscillationAmplitude = Vector3.up;
        pos.dynamic = true;

        transform.parent = null;

        _body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().isKinematic)
        {
            // Move (in world space) to match the position & orientation
            // of our marker object under its parent(s).
            _body.MovePosition(followMarker.position);
            _body.MoveRotation(followMarker.rotation);
        }
    }
}
