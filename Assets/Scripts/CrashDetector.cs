using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float loadDelay = 1.5f;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    PlayerController playerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");

        if (collision.tag == "snow" && !hasCrashed)
        {
            Debug.Log("My Head hurts");
            //playerController.DisableControls();
            hasCrashed = true;

            FindObjectOfType<PlayerController>().DisableControls();


            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            
            crashEffect.Play();
            
            Invoke("reloadScene",loadDelay);
            
        }
    }


    void reloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
