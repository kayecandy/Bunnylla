using UnityEngine;
using System.Collections;

public abstract class Interactable : MonoBehaviour {

    protected bool isCollidedWithPlayer = false;
    protected PlayerController collidedPlayer;

	// Update is called once per frame
	protected void FixedUpdate () {

        FixedUpdateEnter();

        if (isCollidedWithPlayer && collidedPlayer.getActive() && PlayerInputs.GetInteractWithObject())
        {
            InteractPressed();
        }

        FixedUpdateExit();
	}

    protected abstract void InteractPressed();

    protected virtual void FixedUpdateEnter() { }
    protected virtual void FixedUpdateExit() { }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //Debug.Log("Interactable enter");
            isCollidedWithPlayer = true;
            collidedPlayer = col.GetComponent<PlayerController>();
        }
    }

    protected void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && col.GetComponent<PlayerController>().Equals(collidedPlayer))
        {
            //Debug.Log("Interactable enter");
            isCollidedWithPlayer = false;
            collidedPlayer = null;
        }
    }

}
