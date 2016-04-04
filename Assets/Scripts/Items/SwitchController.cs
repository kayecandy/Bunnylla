using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

    public bool isOn = false;
    private bool isTouching = false;

	// Use this for initialization
	void Start () {

        GetComponent<Animator>().SetBool("isOn", isOn);
	}
	
	// Update is called once per frame
	void Update () {
        if (isTouching && PlayerInputs.GetToggleSwitch())
        {
            if (isOn)
                isOn = false;
            else
                isOn = true;

        }
        GetComponent<Animator>().SetBool("isOn", isOn);

	    
	}

    void OnTriggerEnter2D(Collider2D col){
        isTouching = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isTouching = false;
    }
}
