using UnityEngine;
using System.Collections;

public class NetworkConnection : MonoBehaviour {

    public string connectionIP = "127.0.0.1";
    public int portNumber = 8632;

    public static bool connected { get; private set; }

    private void  OnServerInitialized()
    { 
        connected = true;
    }

    private void OnConnectedToServer()
    {
        connected = true;
        transform.GetComponent<TextMesh>().text = "Connected!!";
    }

    private void OnDisconnectedFromServer()
    {
        connected = false;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if(!connected)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Network.Connect(connectionIP, portNumber);
                transform.GetComponent<TextMesh>().text = "CLIENT!!";
            }
                
            else if (Input.GetKey(KeyCode.H))
            {
                Network.InitializeServer(2, portNumber, true);
                transform.GetComponent<TextMesh>().text = "HOST!!";
            }
                
        }
	}
}
