using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private int currentPlayerIndex;
    private PlayerController currentPlayer;
	private PlayerController[] players;
    
    private Vector2 swipeStartLocation;

    private bool changeX = true;
    private bool changeY = true;

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;

	// Use this for initialization
	void Start () {
		players = FindObjectsOfType<PlayerController>();
        currentPlayerIndex = 0;
		currentPlayer = players[currentPlayerIndex];
        currentPlayer.activate();


        PlayerInputs.SetMainCamera(this.GetComponent<Camera>());

		//offset = transform.position - currentPlayer.transform.position;
	}

    public void changeCurrentPlayer(int offset)
    {
        if (offset != 0)
        {
            //Deactivate current player
            currentPlayer.deactivate();

            //Change current player
            currentPlayerIndex = (currentPlayerIndex + offset) % players.Length;
            if (currentPlayerIndex < 0)
            {
                currentPlayerIndex = players.Length + currentPlayerIndex;
            }
            currentPlayer = players[currentPlayerIndex];

            

            //Activate current player
            currentPlayer.activate();

            changeX = true;
            changeY = true;
        }
        


        
    }

    void FixedUpdate()
    {
        changeCurrentPlayer((int)PlayerInputs.GetChangePlayer());

        changeCameraPosition();
    }
	
	// LateUpdate is called once per frame after all other calls
	private void changeCameraPosition () {


		//transform.position = currentPlayer.transform.position + offset;
        float newX = transform.position.x;
        float newY = transform.position.y;

        float move = 0.3f;


        if (changeX || changeY)
        {
            if (newX > currentPlayer.transform.position.x + move || newX < currentPlayer.transform.position.x - move)
            {
                if (newX > currentPlayer.transform.position.x && newX > MinX)
                    newX -= move;
                else if (newX < currentPlayer.transform.position.x && newX < MaxY)
                    newX += move; 
                else
                    changeX = false;
                
            }
            else
            {
                changeX = false;
            }

            if ((newY > currentPlayer.transform.position.y + move || newY < currentPlayer.transform.position.y - move))
            {
                if (newY > currentPlayer.transform.position.y && newY > MinY)
                    newY -= move;
                else if (newY < currentPlayer.transform.position.y && newY < MaxY)
                    newY += move;
                else
                    changeY = false;
            }
            else
            {
                changeY = false;
            }


        }
        else
        {
            //transform.position = currentPlayer.transform.position;
            if (currentPlayer.transform.position.x > MinX && currentPlayer.transform.position.x < MaxX)
                newX = currentPlayer.transform.position.x;

            if (currentPlayer.transform.position.y > MinY && currentPlayer.transform.position.y < MaxY)
                newY = currentPlayer.transform.position.y;
        }

        transform.position = new Vector3(newX, newY, 0);


        

    }
}
