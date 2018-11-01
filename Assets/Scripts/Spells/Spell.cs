using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour {

    public bool isChild = true;
    public bool dying = false;
    public bool hasLifespan = false;
    public bool oneShot = false;
    public float lifespan = 0f;
    public Vector3 offset = Vector3.zero;
    public float triggerForce = 0f;
    public string triggerEffectName = "";
    public float damageAmount = 0;
    public float deathDelay = 0f;
    public string animationVar = "IsChanneling";
    public bool started = false;
    public float startSpeed = 0f;
    private float lifeTime;
    protected Vector3 velocity = Vector3.zero;
    
    

    
    public virtual void Start()
    {
        Stop(true);
        if (oneShot)
        {
            StartCoroutine(OneShot());
        }
    }

    public virtual void Update()
    {
        if (!dying && hasLifespan && lifeTime <= Time.time && started)
        {
            Die();
        }
    }

    public virtual void FixedUpdate()
    {
        transform.position += velocity;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Rigidbody>())
        {
            other.GetComponentInParent<Rigidbody>().AddForce(velocity * triggerForce);
            ApplyEffect(other.gameObject);
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }

    protected virtual void OnParticleCollision(GameObject other)
    {
        if ((triggerForce != 0f || triggerEffectName != "" || damageAmount != 0) && other.GetComponentInParent<Rigidbody>())
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100, 1 << 9))
            {
                return;
            }
            other.GetComponentInParent<Rigidbody>().AddForce(transform.forward * triggerForce);
            ApplyEffect(other);
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }

    public virtual void Initialize()
    {
        lifeTime = Time.time + lifespan;
        foreach (ParticleSystem particleSystem in GetComponentsInChildren<ParticleSystem>())
        {
            particleSystem.Play();
        }
        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            collider.enabled = true;
        }
        foreach (MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.enabled = true;
        }
        started = true;
    }

    public virtual void Stop(bool isHidden = false)
    {
        foreach(ParticleSystem particleSystem in GetComponentsInChildren<ParticleSystem>())
        {
            particleSystem.Stop();
        }
        foreach (Collider collider in GetComponentsInChildren<Collider>())
        {
            GetComponent<Collider>().enabled = false;
        }
        if (isHidden)
        {
            foreach (MeshRenderer collider in GetComponentsInChildren<MeshRenderer>())
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public virtual void SetVelocity(Vector3 vector3)
    {
        velocity = vector3 * startSpeed;
    }

    protected virtual IEnumerator OneShot()
    {
        yield return new WaitForSeconds(0.1f);
        dying = true;
    }

    public virtual void ApplyEffect(GameObject obj)
    {
        if (triggerEffectName != "" && !obj.transform.Find(triggerEffectName + " Effect(Clone)") && obj.gameObject.layer != 9)
        {
            Instantiate(Resources.Load("Prefabs/Spells/" + triggerEffectName + " Effect"), obj.transform);
        }
    }

    public virtual void Die()
    {
        Stop();

        Destroy(gameObject, deathDelay);
        dying = true;
    }

}
