using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Moving",true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Jumping",true);
        }
        if(transform.position.y < 0.5f)
        {
            animator.SetBool("Jumping",false);
        }
    
    }
}
