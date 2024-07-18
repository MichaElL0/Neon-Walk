using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class somethingMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject target;

    private Animator animator;

    public destroyDoor door;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(door.trigger == true)
		{
            Invoke("DoStuff", 5);
		}
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.tag == "Player")
		{
            //print("DEATH");
            SceneManager.LoadScene("End");
		}
	}

    public void DoStuff()
	{
        animator.SetTrigger("Scary");
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        audio.Play();
    }

}
