using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpell : MonoBehaviour {

    new ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = transform.Find("Body").GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            particleSystem.Play();
            StartCoroutine(alterParticles(player.gameObject));
        }
    }

    private IEnumerator alterParticles(GameObject obj)
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
        print(particleSystem.particleCount);

        for (float t = 0f; t < 1f; t += 0.1f)
        {
            int count = particleSystem.GetParticles(particles);
            for (int i = 0; i < count; i++)
            {
                particles[i].position = Vector3.zero;//Vector3.Lerp(particles[i].position, obj.transform.position, t);
                print(particles[i].position);
            }
            particleSystem.SetParticles(particles, count);

            yield return null;
        }

        particleSystem.Clear();
    }

}
