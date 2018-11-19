using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpell : Spell {

    new ParticleSystem particleSystem;

    public override void Start()
    {
        base.Start();
        particleSystem = transform.Find("Body").GetComponent<ParticleSystem>();
    }

    public override void Initialize()
    {
        base.Initialize();
        particleSystem.Stop();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player) { 
            particleSystem.Play();
            GetComponent<Collider>().enabled = false;
            ApplyEffect(other.gameObject);
            StartCoroutine(alterParticles(player.gameObject));
        }
    }

    private IEnumerator alterParticles(GameObject obj)
    {
        yield return new WaitForSeconds(0.15f);
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
        print(particleSystem.particleCount);

        int count = particleSystem.GetParticles(particles);
        for(float t = 0f; t < 1f; t+= 0.1f)
        {
            for (int i = 0; i < count; i++)
            {
                particles[i].position = obj.transform.position + Vector3.one * 0.05f;//Vector3.Lerp(particles[i].position, obj.transform.position, t);
            }
            particleSystem.SetParticles(particles, count);
        }
        yield return new WaitForSeconds(1f);
        particleSystem.Clear();
        Die();
    }

}
