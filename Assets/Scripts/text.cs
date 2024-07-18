using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("Move", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void Move()
	{
        animator.SetTrigger("Move");
	}
}
