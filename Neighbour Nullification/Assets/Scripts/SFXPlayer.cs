using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{

    public static SFXPlayer instance = null;
    public AudioClip[] clips;
    public AudioSource src;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public void PlayAudioClip(int index)
    {
        src.clip = clips[index];
        src.Play();
    }
	
}
