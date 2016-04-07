using UnityEngine;
using System.Collections;

public class PlayerInputs : MonoBehaviour {

    private const int MIN_SWIPE_DISTANCE = 50;


    private static Camera MainCamera;

    private static Vector2 analogStickPosition;
    private static Vector2 touchInitialPosition;

    private static bool isEnabled = true;

    private static AnalogController analogController;
    private static ButtonsController buttonsController;

	// Use this for initialization
	void Start () {
        analogController = FindObjectOfType<AnalogController>();
        buttonsController = FindObjectOfType<ButtonsController>();
	}

    public static void SetMainCamera(Camera cam)
    {
        MainCamera = cam;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Touch  position
        if (Input.touchCount == 1){
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    touchInitialPosition = Input.GetTouch(0).position;
                    break;
               
            }

        }




	}

    public static float GetWalk(PlayerController bunny)
    {
        if (!isEnabled)
            return 0;

        if (analogController.getPosition().x != 0)
        {
            return analogController.getPosition().x;
        }
        else if(!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            return Input.GetAxis("Horizontal");
        }

        return 0;
    }

    public static float GetChangePlayer()
    {
        if (!isEnabled)
            return 0;

        if (Input.touchCount== 1 && Input.GetTouch(0).phase == TouchPhase.Ended && Input.GetTouch(0).tapCount == 1
            && analogController.getPosition().x == 0 && analogController.getPosition().y == 0)
        {
           // Debug.Log("start: " + touchInitialPosition.x);
            //Debug.Log("end: " + Input.GetTouch(0).position.x);

            float xDistance = Input.GetTouch(0).position.x - touchInitialPosition.x;

            if (xDistance > MIN_SWIPE_DISTANCE)
            {
                return 1;
            }
            else if (xDistance < -MIN_SWIPE_DISTANCE)
            {
                return -1;
            }

        }
        else if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) 
            && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                return -1;
            else
                return 1;
        }

        return 0;
    }

    public static bool GetDoAction()
    {
        if (!isEnabled)
            return false;

        return Input.GetKeyDown(KeyCode.Space) || buttonsController.GetAButtonDown();
    }

    public static float GetClimbLadder()
    {
        if (!isEnabled)
            return 0;

        if (analogController.getPosition().y != 0)
        {
            return analogController.getPosition().y;
        }else if (!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            return Input.GetAxis("Vertical");
        }

        return 0;
    }

    public static bool GetInteractWithObject()
    {
        return Input.GetKeyDown(KeyCode.Z) || buttonsController.GetIButtonDown();
    }

    public static bool GetToggleSwitch()
    {
        if (!isEnabled)
            return false;

        return Input.GetKeyDown(KeyCode.Z);
    }

    public static bool GetReadSign()
    {
        return Input.GetKeyDown(KeyCode.Z);
    }

    public static bool GetShowItems()
    {
        return Input.GetKeyDown(KeyCode.X);
    }

    public static void enable()
    {
        isEnabled = true;
    }

    public static void disable()
    {
        isEnabled = false;
    }


    public static void moveAnalog()
    {
        Debug.Log("moved");
    }

}
