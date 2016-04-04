using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	private PlayerController[] players;
	//private PlayerController currPlayer;
	//int[] hp = new int[3] {3, 3, 3};

	// Use this for initialization

    private ArrayList itemsList;

    private bool isSignOpen = false;
    private string signMessage;

	void Start () {
		players = FindObjectsOfType<PlayerController>();

        itemsList = new ArrayList();
	}

	void OnGUI() {
		string text;
		for (int i = 0; i < players.Length; i++) {
			if (players[i].getHP() > 0) {
                text = players[i].name + "'s HP: " + players[i].getHP();
			} 
			else {
				text = players[i].name + " died!";
			}
			GUI.Label (new Rect (0, 20 * i, 150, 20), text);
		}

        if (isSignOpen)
        {
            //Debug.Log(signMessage);

            GUIStyle style = new GUIStyle();
            style.fontSize = 40;
            int padding = 40;
            style.padding = new RectOffset(padding, padding, padding, padding);
            style.alignment = TextAnchor.MiddleCenter;
            style.wordWrap = true;

            GUI.Label(new Rect(0,  0, Screen.width, Screen.height), signMessage, style);
        }

        //Debug.Log("update");
	}

	// Update is called once per frame
	void Update () {
	}

    public bool hasItem(GameObject item)
    {
        return itemsList.Contains(item);
    }

    public void addItem(GameObject item)
    {
        itemsList.Add(item);
    }

    public void removeItem(GameObject item)
    {
        itemsList.Remove(item);
    }

    public void openSign(string message)
    {
        isSignOpen = true;
        signMessage = message;
    }

    public void closeSign()
    {
        if (isSignOpen)
        {
            isSignOpen = false;
        }
    }

}
