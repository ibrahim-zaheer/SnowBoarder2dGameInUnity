using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticles;
    [SerializeField] AudioClip skiSFX;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "snow")
        {
            if (!audioSource.isPlaying) // Ensure the sound is not already playing
            {
                audioSource.PlayOneShot(skiSFX);
            }
            dustParticles.Play();
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "snow")
        {
            if (!audioSource.isPlaying) // Ensure the sound is playing as long as collision is happening
            {
                audioSource.PlayOneShot(skiSFX);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "snow")
        {
            dustParticles.Stop();
            audioSource.Stop(); // Stop the sound when collision ends
        }
    }
}
