using UnityEngine;
using System.Collections;

public class ButterCreamControlls : MonoBehaviour {

    private Animator animator;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        animator.SetBool("isWalkingUp", false);
    }
}
