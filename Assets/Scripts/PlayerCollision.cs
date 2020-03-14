using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject deathFx;
    
    void OnTriggerEnter(Collider other)
    {
        DeathSequence();
    }

    private void DeathSequence()
    {
        SendMessage("OnPlayerDeath");
        deathFx.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void ReloadScene() //String referenced
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
