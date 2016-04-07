using UnityEngine;
using System.Collections;

public class ButtonsController : MonoBehaviour {

    private bool isAButtonDown;
    private bool isIButtonDown;

    private int iCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

    public void setAButtonDown(bool isDown)
    {
        isAButtonDown = isDown;
        
    }

    public void setIButtonDown(bool isDown)
    {
        isIButtonDown = isDown;
    }

    public void setIButtonUp()
    {
        iCount = 0;
        isIButtonDown = false;
    }

    public bool GetAButtonDown()
    {
        
        return isAButtonDown;
    }

    public bool GetIButtonDown()
    {
        return isIButtonDown;
    }
}
