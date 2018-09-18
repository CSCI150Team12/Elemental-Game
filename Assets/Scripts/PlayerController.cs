using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 200f;
    public float rotateSpeed = 10f;
    public float jumpForce = 300f;
    public int voidCount = 0;
    string bitstr = "Water/Water";
    float bitheight = 10;

    Vector3 forward, right;

	void Start () {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = forward.normalized;
        right = Camera.main.transform.right;
    }
	
	void Update () {
        Move();
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bitstr = "Water/Water";
            bitheight = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bitstr = "Magma/Magma";
            bitheight = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bitstr = "Grass/Dirt";
            bitheight = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Instantiate(Resources.Load("Prefabs/Blocks/" + bitstr + "Bit"), hit.point + new Vector3(0,bitheight,0), hit.transform.rotation);
            }
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
        Vector3 movement = rightMovement + upMovement;
        transform.GetComponent<Rigidbody>().velocity = new Vector3(movement.x, transform.GetComponent<Rigidbody>().velocity.y, movement.z);
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(0f, jumpForce, 0f);
    }
}
