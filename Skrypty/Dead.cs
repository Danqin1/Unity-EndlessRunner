using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    private Animator animator;
    private GameController gameController;
    private Sounds sounds;
    void Start()
    {
        sounds = FindObjectOfType<Sounds>();
        animator = GetComponent<Animator>();
        gameController = FindObjectOfType<GameController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            sounds.DeadMusic();
            gameController.IsDead = true;
            animator.SetBool("Moving", false);
            animator.SetBool("Dead",true);
        }
    }
}
