using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    public enum Movement
    {
        Horizontal, Vertical
    }
    public enum MovementTarget
    {
        Start, End
    }

    public bool isMoving = false;
    public Movement movementDirection = Movement.Horizontal;
    public float movementStart;
    public float movementEnd;
    public MovementTarget movementTarget = MovementTarget.Start;
    public float movementSpeed = 0.017f;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
        if (isMoving && movementStart != 0 && movementEnd != 0)
        {
            float position;
            Vector3 deltaPosition;
            if (movementDirection == Movement.Horizontal)
            {
                position = transform.position.x;
                deltaPosition = new Vector3(1, 0, 0);
            }
            else if (movementDirection == Movement.Vertical)
            {
                position = transform.position.y;
                deltaPosition = new Vector3(0, 1, 0);
            }
            else
            {
                position = 0;
                deltaPosition = new Vector3();
            }

            if (movementTarget == MovementTarget.Start)
            {
                if (position > movementStart)
                    deltaPosition *= -movementSpeed;
                else
                {
                    deltaPosition *= 0;
                    movementTarget = MovementTarget.End;
                }
            }
            else if (movementTarget == MovementTarget.End)
            {
                if (position < movementEnd)
                    deltaPosition *= movementSpeed;
                else
                {
                    deltaPosition *= 0;
                    movementTarget = MovementTarget.Start;
                }
            }

            //Debug.Log(position);

            transform.position = new Vector3(
                    transform.position.x + deltaPosition.x,
                    transform.position.y + deltaPosition.y,
                    transform.position.z + deltaPosition.z
                );

        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().reduceHP();
        }
    }
}
