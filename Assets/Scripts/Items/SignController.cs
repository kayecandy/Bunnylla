using UnityEngine;
using System.Collections;

public class SignController : MonoBehaviour {

    public string message;

    private bool isOnSign = false;
    private bool isSignOpen = false;

    private PlayerController currentPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	void FixedUpdate () {
        //Debug.Log("isOnSign: " + isOnSign + " key: " + PlayerInputs.GetReadSign());
        if (isOnSign && PlayerInputs.GetReadSign() && currentPlayer.getActive())
        {
            LevelManager l = FindObjectOfType<LevelManager>();
            if (!isSignOpen)
            {
                l.openSign(message);
                PlayerInputs.disable();
                isSignOpen = true;
            }
            else
            {
                l.closeSign();
                PlayerInputs.enable();
                isSignOpen = false;
            }
        }

	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("sign enter");
            isOnSign = true;
            currentPlayer = col.GetComponent<PlayerController>();
        }

        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("sign exit");
            isOnSign = false;
            currentPlayer = null;
        }

        
    }
}
