using UnityEngine;
using System.Collections;

public class KeyController : MonoBehaviour {

    private bool isAdded = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !isAdded)
        {
            isAdded = true;
            pickUpKey();
        }
    }

    private void pickUpKey()
    {
        LevelManager l = FindObjectOfType<LevelManager>();

        l.addItem(this.gameObject);

        Debug.Log("key added");

        GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);

    }
}
