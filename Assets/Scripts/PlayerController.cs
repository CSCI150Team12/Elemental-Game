using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber = 1;
    public float moveSpeed = 4f;
    public float rotateSpeed = 10f;
    public float damage = 0f;
    public float jumpForce = 300f;
    public string spellStr = "Water";
    public GameObject pelvis;
    private bool ragdollToggle = false;
    private Transform root;
    private Spell currentSpell;
    private Animator animator;
    private bool canJump = true;
    private bool canCast = true;

    Vector3 camForward, right;

    void Start()
    {
        camForward = Camera.main.transform.forward;
        camForward.y = 0;
        camForward = camForward.normalized;
        right = Camera.main.transform.right;
        animator = GetComponent<Animator>();
        root = transform.Find("Root");
        SetRagdoll(false, true);
    }

    void FixedUpdate()
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
        if (canJump && Input.GetAxis("Jump P"+playerNumber) == 1)
        {
            StartCoroutine(Jump());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetRagdoll(ragdollToggle);
        }
        if (Input.GetButtonDown("Air P" + playerNumber))
        {
            spellStr = "Air";
            print(playerNumber);
        }
        if (Input.GetButtonDown("Fire P" + playerNumber))
        {
            spellStr = "Fire";
        }
        if (Input.GetButtonDown("Water P" + playerNumber))
        {
            spellStr = "Water";
        }
        if (Input.GetButtonDown("Earth P" + playerNumber))
        {
            spellStr = "Earth";
        }
        if (canCast && Input.GetAxis("Cast P" + playerNumber) == 1)
        {
            StartCoroutine(CastSpell());
        }
    }

    void Move()
    {
        Vector3 direction = Input.GetAxis("Turn X P" + playerNumber) * right + -camForward * Input.GetAxis("Turn Y P" + playerNumber);
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Move X P" + playerNumber);
        Vector3 upMovement = camForward * moveSpeed * Time.deltaTime * Input.GetAxis("Move Y P" + playerNumber);
        float forwardDot = Vector3.Dot(upMovement + rightMovement, transform.forward);

        if (direction.magnitude > 0.2f)
        {
            transform.forward = Vector3.RotateTowards(transform.forward, direction.normalized, rotateSpeed * Time.deltaTime, 0.0f);
        }
        else
        {
            transform.forward = Vector3.RotateTowards(transform.forward, (upMovement+rightMovement).normalized, rotateSpeed * Time.deltaTime, 0.0f);
        }

        if (forwardDot > 0)
        {
            animator.SetFloat("RunFront", 1f);
        }
        else if (forwardDot < 0)
        {
            animator.SetFloat("RunFront", -1f);
        }
        else
        {
            animator.SetFloat("RunFront", 0);
        }

        transform.GetComponent<Rigidbody>().MovePosition(transform.position + rightMovement + upMovement);
    }

    IEnumerator Jump()
    {
        animator.SetTrigger("Jump");
        canJump = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody>().AddForce(0f, jumpForce, 0f);
        yield return new WaitForSeconds(1f);
        canJump = true;
    }

    IEnumerator CastSpell()
    {
        GameObject spellPrefab = (GameObject)Instantiate(Resources.Load("Prefabs/Spells/" + spellStr + " Spell"));
        Spell spellComponent = spellPrefab.GetComponent<Spell>();
        if (spellComponent.animationVar == "IsChanneling")
        {
            spellPrefab.transform.parent = transform;
            currentSpell = spellPrefab.GetComponent<Spell>();
            animator.SetBool("IsChanneling", true);
        }
        else if (spellComponent.animationVar == "GroundHit")
        {
            animator.SetTrigger("GroundHit");
        }
        canCast = false;
        yield return new WaitForSeconds(0.3f);
        spellPrefab.transform.position = transform.TransformPoint(spellComponent.offset); ;
        spellPrefab.transform.rotation = transform.rotation;
        spellComponent.Initialize();
        yield return new WaitForSeconds(1f);
        canCast = true;
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


