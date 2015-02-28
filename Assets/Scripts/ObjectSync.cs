using UnityEngine;
using System.Collections;

public class ObjectSync : MonoBehaviour {
    public Vector3 objPos;
    public Vector3 objOrien;
    public bool isServer;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!NetworkConnection.connected)
        {
            return;
        }
        
      
        
        
        

        //if (networkView.isMine)
        // {
        //objPos = transform.position;
        //objOrien = transform.eulerAngles;
       
        networkView.RPC("sendObjectTransform", RPCMode.All, transform.position, transform.eulerAngles);
        
        // }
	}

    [RPC]
    public void sendObjectTransform(Vector3 position, Vector3 eulerAngles)
    {
        objPos = position;
        objOrien = eulerAngles;
    }
}
