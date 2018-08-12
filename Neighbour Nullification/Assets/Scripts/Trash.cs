using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    public ParticleSystem particles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CanBePickedUp")
        {
            Destroy(other.gameObject);
            SFXPlayer.instance.PlayAudioClip(0);
            particles.Play();
        }
    }
}
