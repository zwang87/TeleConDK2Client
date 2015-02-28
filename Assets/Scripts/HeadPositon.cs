using UnityEngine;
using System.Collections;

public class HeadPositon : MonoBehaviour {

    public GameObject oculus;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = oculus.transform.position;
        transform.eulerAngles = oculus.transform.eulerAngles;
	}
}
