using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : MonoBehaviour {
    public AudioSource audioSrc;
    public AudioClip footstep;

    public void PlayFootsteps()
    {
        audioSrc.PlayOneShot(footstep);
    }
}
