using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameController gameController;
    public AudioClip pick;
    private AudioSource audioSource;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        gameController = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        audioSource.PlayOneShot(pick,0.7f);
        gameController.score++;
        DestroyInTime();
    }
    private IEnumerator DestroyInTime()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
