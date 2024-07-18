using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDoor : MonoBehaviour
{
    public AudioSource audio;
    public GameObject text;
    public Rigidbody2D player;
    public bool trigger;

    public GameObject some;

    // Start is called before the first frame update
    void Start()
    {
        trigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
		{
            trigger = true;
            print(trigger);
            Destroy(gameObject);
            Destroy(text);
            Destroy(GameObject.FindGameObjectWithTag("AUDIO"));
            audio.Play();
            player.bodyType = RigidbodyType2D.Static;
            some.SetActive(true);
        }
	}
}
