using UnityEngine;
using System.Collections;

public class SignController : Interactable {

    public string message;
    
    private bool isSignOpen = false;

    private PlayerController currentPlayer;

	// Use this for initialization
	void Start () {
	
	}

    protected override void InteractPressed()
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
