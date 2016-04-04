using UnityEngine;
using System.Collections;

public class LockController : MonoBehaviour {

    private GameObject key;
    private bool isLocked = true;
    private bool isOpenFinished = false;

    private float openSpeed = 0.03f;

	// Use this for initialization
	void Start () {
        key = getKey();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocked && !isOpenFinished)
        {
            Debug.Log("open");
            openLock();
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && isLocked)
        {
            LevelManager l = FindObjectOfType<LevelManager>();

            if (l.hasItem(key))
            {
                Debug.Log("Open lock");
                isLocked = false;

                GetComponent<BoxCollider2D>().size = new Vector2(0, 0);

                l.removeItem(key);

            }
        }
    }

    private void openLock()
    {
        bool noMoves = true;
        foreach (Transform child in transform)
        {
            Vector3 newPos = child.localPosition;
            

            if (newPos.y < 0)
            {
                newPos.y += openSpeed;
                noMoves = false;
            }
            if (newPos.x > 0)
            {
                newPos.x -= openSpeed;
                noMoves = false;
            }

            child.localPosition = newPos;

            Debug.Log(child.localPosition);
        }

        isOpenFinished = noMoves;
    }

    private GameObject getKey()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Key")
            {
                return child.gameObject;
            }
        }

        return null;
    }

    

}
