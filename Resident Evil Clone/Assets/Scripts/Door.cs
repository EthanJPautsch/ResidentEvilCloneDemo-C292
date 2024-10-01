using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            animator.SetTrigger("ToggleDoor");
        }
    }

    void onTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            animator.SetTrigger("ToggleDoor");
        }
    }
}
