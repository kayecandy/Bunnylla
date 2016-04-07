using UnityEngine;
using System.Collections;

public class SwitchController : Interactable {

    public bool isOn = false;

	// Use this for initialization
	void Start () {

        GetComponent<Animator>().SetBool("isOn", isOn);
	}


    protected override void InteractPressed()
    {
        if (isOn)
            isOn = false;
        else
            isOn = true;
    }

    protected override void FixedUpdateExit()
    {
        GetComponent<Animator>().SetBool("isOn", isOn);
    }

}
