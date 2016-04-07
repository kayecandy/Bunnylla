using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public const int MAX_HP = 3;

    private int currentHP;

    private float speed = 3.5f;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isActive = false;
    private bool onLadder = false;

    private float tempGravityScale;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHP = MAX_HP;
    }

    void FixedUpdate()
    {
        if (isActive)
        {
            walk();
            climbLadder();
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            //rb.isKinematic = true;
            tempGravityScale = rb.gravityScale;
            rb.gravityScale = 0;
            onLadder = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            Debug.Log("exit");
            //rb.isKinematic = false;
            rb.gravityScale = tempGravityScale;
            onLadder = false;
        }
    }

    private void walk()
    {
        float moveHorizontal = PlayerInputs.GetWalk(this);

        if (moveHorizontal != 0)
        {
            animator.SetBool("isWalking", true);
            if (moveHorizontal > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }

            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        //rb.AddForce(moveHorizontal * speed * Vector2.right);

    }

    private void climbLadder()
    {
        float moveVertical = PlayerInputs.GetClimbLadder();
        //Debug.Log(moveVertical);

        if (moveVertical != 0 && onLadder)
            rb.velocity = new Vector2(rb.velocity.x, moveVertical);

    }

    public void activate()
    {
        isActive = true;
        Debug.Log(this.gameObject.name + "activated");
    }
    public void deactivate()
    {
        isActive = false;
    }
    public bool getActive()
    {
        return isActive;
    }

    public bool isOnLadder()
    {
        return onLadder;
    }

    public int getHP()
    {
        return currentHP;
    }

    public void restoreHP()
    {
        currentHP = MAX_HP;
    }

    public void reduceHP(){
        currentHP--;
    }

    

}
