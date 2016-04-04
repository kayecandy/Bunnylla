using UnityEngine;
using System.Collections;

public class StrawberryControls : MonoBehaviour {

    public float jumpForce = 1000;
    public float maxVelocity = 100;

	private bool doubleJumped = false;
    private bool isGrounded = false;

	// Use this for initialization
	void Start () {
	
	}

	void FixedUpdate() {
        if (isGrounded)
        {
            doubleJumped = false;
        }

        bool onLadder = GetComponent<PlayerController>().isOnLadder();

        //Jump
        if (!onLadder && PlayerInputs.GetDoAction() && isGrounded && GetComponent<PlayerController>().getActive())
        {
            Jump();
        }

        //Double Jump
        if (!onLadder && PlayerInputs.GetDoAction() && !isGrounded && !doubleJumped && GetComponent<PlayerController>().getActive())
        {
            Jump();
            doubleJumped = true;
        }

        //Debug.Log(this.gameObject.GetComponent<Rigidbody2D>().velocity);

	}

	public void Jump() {
		//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();

        //Debug.Log(jumpForce);
        rb.velocity = new Vector2(rb.velocity.x * 2, jumpForce);
        //Debug.Log(rb.velocity);
        //rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);


        //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //Debug.Log(this.gameObject.GetComponent<Rigidbody2D>().velocity);


    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            Debug.Log("Collide Ground");
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            Debug.Log("Exit Ground");
            isGrounded = false;
        }
    }

}
