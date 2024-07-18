using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Animator animator;
    public Animator wallAnim;
    private bool buttonIsPressed;


    // Start is called before the first frame update
    void Start()
    {
        buttonIsPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if(collision.collider.tag == "Player")
		{
            animator.SetTrigger("ButtonPressed");
            buttonIsPressed = true;
            //FindObjectOfType<AudioManager>().Play("Button");

            if(buttonIsPressed)
			{
                wallAnim.SetTrigger("Pressed");
                FindObjectOfType<AudioManager>().Play("Door");
            }
        }
        
	}
}
