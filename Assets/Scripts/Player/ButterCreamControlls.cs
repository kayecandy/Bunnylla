using UnityEngine;
using System.Collections;

public class ButterCreamControlls : MonoBehaviour {


    private Animator animator;
    private bool isSmall = false;

    private Vector3 normalScale;
    public Vector3 smallScale = new Vector3(0.1f, 0.1f, 0.1f);



	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalkingUp", false);
        normalScale = transform.localScale;

	}

    void FixedUpdate()
    {
        if (PlayerInputs.GetDoAction() && GetComponent<PlayerController>().getActive())
        {
            if (isSmall)
            {
                transform.localScale = normalScale;
                isSmall = false;
            }
            else
            {
                transform.localScale = smallScale;
                isSmall = true;
            }
        }
    }

}
