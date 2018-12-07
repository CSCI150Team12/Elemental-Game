using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int playerNumber = 1;
    public Slider damageUI;
    public TMP_Text spellQueueUI;
    public TMP_SpriteAsset spellIcon;
    public float moveSpeed = 4f;
    public float rotateSpeed = 10f;
    public float damage = 0f;
    public float jumpForce = 300f;
    private SpellQueue spellQueue;
    public GameObject pelvis;
    private bool ragdollToggle = false;
    private Transform root;
    private Spell currentSpell;
    private Animator animator;
    private bool canJump = true;
    private bool canCast = true;
    private float castReset = 0f;
    private bool frozen = false;

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
        spellQueue = gameObject.AddComponent<SpellQueue>();
    }

    void Update()
    {
        if (!frozen)
        {
            GetInput();
        }
        if (currentSpell != null && (currentSpell.dying || currentSpell.stopAnimation))
        {
            animator.SetBool("IsChanneling", false);
            currentSpell = null;
            canCast = true;
        }
    }

    void FixedUpdate()
    {
        if (!frozen)
        {
            Move();
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
            spellQueue.Enqueue("Air");
        }
        if (Input.GetButtonDown("Fire P" + playerNumber))
        {
            spellQueue.Enqueue("Fire");
        }
        if (Input.GetButtonDown("Water P" + playerNumber))
        {
            spellQueue.Enqueue("Water");
        }
        if (Input.GetButtonDown("Earth P" + playerNumber))
        {
            spellQueue.Enqueue("Earth");
        }
        if (castReset < Time.time && (Input.GetAxis("Cast P" + playerNumber) == 1 || Input.GetButtonDown("Cast2 P" + playerNumber)))
        {
            castReset = Time.time + 1f;
            if (canCast)
            {
                if (Input.GetAxis("Cast P" + playerNumber) == 1)
                {
                    StartCoroutine(CastSpell(spellQueue.Dequeue()));
                }else if (Input.GetButtonDown("Cast2 P" + playerNumber))
                {
                    StartCoroutine(CastSpell(spellQueue.Pop()));
                }
                
            }
            else if (currentSpell)
            {
                currentSpell.SecondaryCast();
            }
            
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

    IEnumerator CastSpell(string spellStr)
    {
        GameObject spellPrefab = (GameObject)Instantiate(Resources.Load("Prefabs/Spells/" + spellStr + " Spell"));
        Spell spellComponent = spellPrefab.GetComponent<Spell>();
        currentSpell = spellComponent;
        if (spellComponent.isChild)
        {
            spellPrefab.transform.parent = transform;
        }
        if (spellComponent.animationVar == "IsChanneling")
        {
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
        spellComponent.SetVelocity(transform.forward);
        spellComponent.Initialize();
      
    }

    public void AddElement(string element)
    {
        spellQueue.Enqueue(element);
    }

    public void TakeDamage(float amount)
    {
        damage += amount;
        damageUI.value = damage;
    }

    public void SetFrozen(bool isFrozen)
    {
        frozen = isFrozen;
        if (frozen)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
        }
    }


    void SetRagdoll(bool isRagdoll = true, bool initial = false)
    {

        foreach (Collider col in root.GetComponentsInChildren<Collider>())
        {
            col.enabled = isRagdoll;
            col.GetComponent<Rigidbody>().isKinematic = !isRagdoll;
        }
        GetComponent<CapsuleCollider>().enabled = !isRagdoll;
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


