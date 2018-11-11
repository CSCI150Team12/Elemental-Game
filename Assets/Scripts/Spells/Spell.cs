using System.Collections;
using UnityEngine;

public class Spell : MonoBehaviour {

    public bool isChild = true;
    public bool dying = false;
    public bool hasLifespan = false;
    public bool oneShot = false;
    public bool noCast = false;
    public float lifespan = 0f;
    public Vector3 offset = new Vector3(0, 1.25f, 1.5f);
    public float triggerForce = 0f;
    public string triggerEffectName = "";
    public float damageAmount = 0;
    public float deathDelay = 0f;
    public string animationVar = "IsChanneling";
    public bool started = false;
    public float startSpeed = 0f;
    private float lifeTime;
    protected Vector3 velocity = Vector3.zero;
    public bool stopAnimation = false;


    public virtual void Start()
    {
        Stop(true);
        if (oneShot)
        {
            StartCoroutine(OneShot());
        }
        if (noCast)
        {
            Initialize();
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
        if (!GetComponent<Rigidbody>())
        {
            transform.position += velocity;
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Rigidbody>() && !GetComponent<SpellField>())
        {
            
            ApplyEffect(other.gameObject);
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player)
            {
                player.TakeDamage(damageAmount);
                player.GetComponent<Rigidbody>().AddForce(velocity.normalized * DamageForceScale(player, 1500f));
            }
            else
            {
                other.GetComponentInParent<Rigidbody>().AddForce(velocity.normalized * triggerForce);
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
            
            ApplyEffect(other);
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if (player)
            {
                player.TakeDamage(damageAmount);
                player.GetComponent<Rigidbody>().AddForce(transform.forward * DamageForceScale(player));
            }
            else
            {
                other.GetComponentInParent<Rigidbody>().AddForce(transform.forward * triggerForce);
            }
        }
    }

    private float DamageForceScale(PlayerController player, float factor = 1.25f)
    {
        if (triggerForce == 0)
        {
            return 0;
        }
        return (triggerForce + (player.damage * factor) / triggerForce);
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
        if (GetComponent<BitEmitter>())
        {
            GetComponent<BitEmitter>().Initialize();
        }
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().velocity = velocity;
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
            collider.enabled = false;
        }
        if (isHidden)
        {
            foreach (MeshRenderer collider in GetComponentsInChildren<MeshRenderer>())
            {
                collider.enabled = false;
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
        stopAnimation = true;
    }

    public virtual void ApplyEffect(GameObject obj)
    {
        if (triggerEffectName != "" && !obj.transform.Find(triggerEffectName + " Effect(Clone)") && obj.gameObject.layer != 9)
        {
            Instantiate(Resources.Load("Prefabs/Spell Effects/" + triggerEffectName + " Effect"), obj.transform);
        }
    }

    public virtual void Die()
    {
        Stop();
        Destroy(gameObject, deathDelay);
        dying = true;
    }
}
