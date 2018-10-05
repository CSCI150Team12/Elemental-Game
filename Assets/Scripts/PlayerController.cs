using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 4f;
    public float rotateSpeed = 10f;
    public float jumpForce = 300f;
    public string spellStr = "Water";
    public GameObject pelvis;
    private bool ragdollToggle = false;
    private Transform root;
    private Spell currentSpell;
    public Animator animator;

    Vector3 forward, right;

    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = forward.normalized;
        right = Camera.main.transform.right;
        animator = GetComponent<Animator>();
        root = transform.Find("Root");
        SetRagdoll(false, true);
    }

    void Update()
    {
        Move();
        GetInput();
        if(currentSpell != null && currentSpell.dying)
        {
            animator.SetBool("IsChanneling", false);
        }
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Jump());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetRagdoll(ragdollToggle);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spellStr = "Water";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spellStr = "Air";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            spellStr = "Fire";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            spellStr = "Earth";
        }
        if (Input.GetMouseButtonDown(0))
        {
            CastSpell();
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
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        transform.position += rightMovement + upMovement;
    }

    IEnumerator Jump()
    {
        animator.SetTrigger("Jump");
        yield return new WaitForSeconds(0.3f);
        GetComponent<Rigidbody>().AddForce(0f, jumpForce, 0f);
    }

    void CastSpell()
    {
        GameObject spellPrefab = (GameObject)Instantiate(Resources.Load("Prefabs/Spells/" + spellStr + " Spell"));
        spellPrefab.transform.position = transform.TransformPoint(spellPrefab.GetComponent<Spell>().offset); ;
        spellPrefab.transform.rotation = transform.rotation;
        if (spellPrefab.GetComponent<Spell>().isChild)
        {
            spellPrefab.transform.parent = transform;
            currentSpell = spellPrefab.GetComponent<Spell>();
            animator.SetBool("IsChanneling", true);
        }
        else
        {
            animator.SetTrigger("GroundHit");
        }
        
    }

    void SetRagdoll(bool isRagdoll = true, bool initial = false)
    {

        foreach (Collider col in root.GetComponentsInChildren<Collider>())
        {
            col.enabled = isRagdoll;
            col.GetComponent<Rigidbody>().isKinematic = !isRagdoll;
        }
        GetComponent<BoxCollider>().enabled = !isRagdoll;
        GetComponent<Rigidbody>().isKinematic = isRagdoll;
        animator.enabled = !isRagdoll;
        ragdollToggle = !isRagdoll;
        if (isRagdoll)
        {
            root.parent = null;
        }
        else if (!initial)
        {
            transform.position = pelvis.transform.position;
            transform.rotation = pelvis.transform.rotation;
            root.parent = transform;
        }
    }

}


