using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionModifier : MonoBehaviour {

    public Transform focusPoint;
    public bool dynamic;
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 maxPosition = Vector3.positiveInfinity;
    public Vector3 minPosition = Vector3.negativeInfinity;
    public bool focusOscillation;
    public bool focusTimeOscillation;
    public float oscillationRate;
    public Vector3 oscillationAmplitude;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate () {
        if (focusPoint)
        {
            Vector3 amplitude = oscillationAmplitude;
            Vector3 position;
            if (dynamic)
            {
                position = transform.position;
            }
            else
            {
                position = startPosition;
            }
            
            float timeRate = oscillationRate;
            if (focusOscillation)
            {
                amplitude = (position - focusPoint.position).normalized * amplitude.magnitude;
            }
            if (focusTimeOscillation)
            {
                timeRate *= (position - focusPoint.position).magnitude;
            }
            transform.position += amplitude * Mathf.Sin(Time.time * Mathf.PI *  timeRate);
        }
        transform.position = velocity + startPosition;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minPosition.y, maxPosition.y), transform.position.z);
        velocity += acceleration;
	}
}
