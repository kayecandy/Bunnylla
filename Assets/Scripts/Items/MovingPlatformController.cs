using UnityEngine;
using System.Collections;

public class MovingPlatformController : MonoBehaviour {

    private Vector3 targetPosition;
    private Vector3 startPosition;
    private float deltaPosition;

    private GameObject platform;
    private MovingPlatformChildController platformController;

    public float moveIndexX = 0.01f;
    public float moveIndexY = 0.01f;

    private Target currentTarget;

    public enum Target
    {
        TargetPosition, StartPosition
    }

	// Use this for initialization
	void Start () {

        startPosition = new Vector3(0, 0, 0);
        targetPosition = getTarget();
        platform = getPlatform();
        platformController = platform.GetComponent<MovingPlatformChildController>();

        deltaPosition = moveIndexX + moveIndexY;

        if (targetPosition.x < startPosition.x)
            moveIndexX *= -1;
        if (targetPosition.y < startPosition.y)
            moveIndexY *= -1;

        currentTarget = Target.TargetPosition;

        
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 delta = new Vector3(0, 0);

        int startDelta = isWithinDelta(startPosition);
        int targetDelta = isWithinDelta(targetPosition);

        if (currentTarget == Target.TargetPosition)
        {
            if (targetDelta != 11)
            {
                delta.x = (1 - (targetDelta / 10)) * moveIndexX;
                delta.y = (1 - (targetDelta % 10)) * moveIndexY;
            }
            else
            {
                currentTarget = Target.StartPosition;
            }

        }
        else if (currentTarget == Target.StartPosition)
        {
            if (startDelta != 11)
            {
                delta.x = (1 - (startDelta / 10)) * -moveIndexX;
                delta.y = (1 - (startDelta % 10)) * -moveIndexY;
            }
            else
            {
                currentTarget = Target.TargetPosition;
            }
        }

        platform.transform.localPosition += delta;
        platformController.syncPlayerLocations(delta);

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
        Vector3 anchor = platform.transform.localPosition;
        //Vector3 anchor = chains.transform.localPosition;
        if (anchor.x > target.x - deltaPosition && anchor.x < target.x + deltaPosition)
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

    private GameObject getPlatform()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Platform")
            {
                return child.gameObject;
            }
        }

        return null;
    }
}
