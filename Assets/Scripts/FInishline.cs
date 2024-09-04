using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FInishline : MonoBehaviour
{
    [SerializeField] float loadDelay = 3f;
    [SerializeField] ParticleSystem finishEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            finishEffect.Play();
            Debug.Log("You finished");
            GetComponent<AudioSource>().Play();
            Invoke("reloadScene",loadDelay);
        }
    }
    void reloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
