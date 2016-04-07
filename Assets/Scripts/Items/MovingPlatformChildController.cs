using UnityEngine;
using System.Collections;

public class MovingPlatformChildController : MonoBehaviour {

    private ArrayList onPlatformPlayers;

	// Use this for initialization
	void Start () {
        onPlatformPlayers = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            onPlatformPlayers.Add(col.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            onPlatformPlayers.Remove(col.gameObject);
        }
    }

    public void syncPlayerLocations(Vector3 delta)
    {
        foreach (GameObject player in onPlatformPlayers)
        {
            player.transform.localPosition += delta;
        }
    }
}
