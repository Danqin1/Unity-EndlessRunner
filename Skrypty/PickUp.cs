using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameController gameController;
    private Sounds sounds;

    private void Start() {
        sounds = FindObjectOfType<Sounds>();
        gameController = FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter(Collider other) 
    { 
        sounds.PlayPickUp();
        gameController.score++;
        DestroyInTime();
    }
    private IEnumerator DestroyInTime()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
