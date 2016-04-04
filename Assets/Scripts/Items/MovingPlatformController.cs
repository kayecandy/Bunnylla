using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {

    private SwitchController platformSwitch;
    private Vector3 targetPosition;
    private Vector3 startPosition;
    private float deltaPosition = 0.02f;

    private GameObject[] anchorPoints;

    private float moveIndexX = 0.01f;
    private float moveIndexY = 0.01f;

    public enum State
    {
        AtTarget, AtStart
    }


	// Use this for initialization
	void Start () {
        platformSwitch = getSwitch();
        startPosition = new Vector3(0, 0, 0);
        targetPosition = getTarget();

        anchorPoints = getAnchorPoints();

        Debug.Log(anchorPoints[0].transform.localPosition);

        if (targetPosition.x > startPosition.x)
            moveIndexX *= -1;
        if (targetPosition.y > startPosition.y)
            moveIndexY *= -1;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(platformSwitch.isOn);
        Vector2 delta = new Vector2(0,0);

        int startDelta = isWithinDelta(startPosition);
        int targetDelta = isWithinDelta(targetPosition);

        if (platformSwitch.isOn && targetDelta != 11)
        {
            delta.x = (1 - (targetDelta / 10)) * moveIndexX;
            delta.y = (1 - (targetDelta % 10)) * moveIndexY;
            Debug.Log("on" + targetDelta);

        }
        else if (!platformSwitch.isOn && startDelta != 11)
        {
            delta.x = (1 - (startDelta / 10)) * -moveIndexX;
            delta.y = (1 - (startDelta % 10)) * -moveIndexY;
            Debug.Log("off" + startDelta);
        }

        anchorPoints[0].GetComponent<FixedJoint2D>().anchor += delta;
        anchorPoints[1].GetComponent<FixedJoint2D>().anchor += delta;

	
	}

    private SwitchController getSwitch()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Switch")
                return child.GetComponent<SwitchController>();
        }

        return null;
    }

    /*
     * RETURN VALUES
     * 11 - isWithinDelta true for x & y
     * 00 - isWithinDelta false for x & y
     * 10 - isWithinDelta true for x only
     * 01 - isWithinDelta true for y only
     */
    private int isWithinDelta(Vector3 target)
    {
        int value = 0;
        Vector3 anchor = anchorPoints[0].transform.localPosition;
        if( anchor.x > target.x - deltaPosition && anchor.x < target.x + deltaPosition)
            value += 10;

        if (anchor.y > target.y - deltaPosition && anchor.y < target.y + deltaPosition)
            value += 1;

        return value;
    }

    private Vector3 getTarget()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Target")
            {
                return child.localPosition;
            }
        }

        return new Vector3();
    }

    private GameObject[] getAnchorPoints()
    {
        GameObject[] anchorPoints = new GameObject[2];
        int i=0;
        foreach (Transform child in transform)
        {
            if (child.name == "Chains")
            {
                foreach (Transform chain in child.transform)
                {
                    foreach (Transform link in chain.transform)
                    {
                        if (link.tag == "AnchorPoint")
                        {
                            anchorPoints[i] = link.gameObject;
                            i++;
                        }
                    }
                }
            }
           
        }

        return anchorPoints;
    }
}
