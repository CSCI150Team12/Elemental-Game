using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 4f;
    public float rotateSpeed = 10f;
    public float jumpForce = 300f;

    Vector3 forward, right;

	void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = forward.normalized;
        right = Camera.main.transform.right;
    }
	
	void Update () {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        Vector3 heading = (rightMovement + upMovement).normalized;

        if (direction.magnitude > 0.2f)
        {
            transform.forward = Vector3.RotateTowards(transform.forward, heading, rotateSpeed * Time.deltaTime, 0.0f);
        }
        transform.position += rightMovement + upMovement;
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(0f, jumpForce, 0f);
    }
}
