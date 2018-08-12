using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesOnCollision : MonoBehaviour {

    ParticleSystem particles;
    Rigidbody rigid;
	void Start () {
        particles = GetComponentInChildren<ParticleSystem>();
        rigid = GetComponent<Rigidbody>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        float x = rigid.velocity.x;
        float y = rigid.velocity.y;

        if (x > 1 || x < -1 || y > 1 || y < -1)
            particles.Play();
    }
}
