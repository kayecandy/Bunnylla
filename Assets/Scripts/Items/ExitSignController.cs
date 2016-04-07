using UnityEngine;
using System.Collections;

public class ExitSignController : SignController {

    public const int PLAYER_NUM = 3;
    private ArrayList players;

	// Use this for initialization
	void Start () {
        players = new ArrayList();
        message = "All 3 bunnies have to be on the exit sign to be able to exit";
	}
	
	// Update is called once per frame
    protected override void InteractPressed()
    {
        if (players.Count == PLAYER_NUM)
        {
            Debug.Log("exited");
        }else
            base.InteractPressed();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (col.tag == "Player" && !players.Contains(col.gameObject))
        {
            players.Add(col.gameObject);
            Debug.Log("enter count: "+players.Count);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        base.OnTriggerExit2D(col);
        if (col.tag == "Player")
        {
            players.Remove(col.gameObject);
            Debug.Log("exit count: " + players.Count);

        }
    }
}
