using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBoarding : MonoBehaviour
{
    [SerializeField] ParticleSystem snowEffect;
    [SerializeField] AudioClip skiSFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "snow")
        {
            Debug.Log("I am snowboarding");
            snowEffect.gameObject.SetActive(true);
            snowEffect.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "snow" && !snowEffect.isPlaying)
        {
            snowEffect.gameObject.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(skiSFX);
            snowEffect.Play();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "snow")
        {
            Debug.Log("Stopped snowboarding");
            snowEffect.Stop();
            snowEffect.gameObject.SetActive(false);
        }
    }
}
