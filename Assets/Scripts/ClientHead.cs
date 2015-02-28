using UnityEngine;
using System.Collections;

public class ClientHead : MonoBehaviour {
    public Vector3 headPosition;
    public Vector3 headOrientation;

    public GameObject oculus;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!NetworkConnection.connected) 
        {
            return;
        }

        if (networkView.isMine)
        {
            transform.position = headPosition;
            transform.eulerAngles = headOrientation;
        }
        else
        {
            transform.position = oculus.transform.position;
            transform.eulerAngles = oculus.transform.eulerAngles;
            networkView.RPC("sendClientTransform", RPCMode.AllBuffered, transform.position, transform.eulerAngles);
        }
    }

    [RPC]
    public void sendClientTransform(Vector3 position, Vector3 eulerAngles)
    {
        headPosition = position;
        headOrientation = eulerAngles;
    }
}
