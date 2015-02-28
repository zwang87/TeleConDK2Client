using UnityEngine;
using System.Collections;

public class CubeCollision : MonoBehaviour {
    public Material alterMat;
    public int count = 0;
    private Material originMat;

    private float lastTime = 0;
    private float currentTime = 0;

	// Use this for initialization
	void Start () {
        originMat = transform.renderer.material;
	}

    bool isColliding = false;
    bool isExited = true;
	// Update is called once per frame
	void Update () {
        isColliding = false;
	}

    void OnCollisionEnter(Collision other)
    {
        if (isColliding || !isExited) return;
        isColliding = true;
        isExited = false;
        currentTime = Time.realtimeSinceStartup;

        float time = currentTime - lastTime;

        Debug.Log(time);

        if (time >= 0.3)
        {
            if (count % 2 == 0)
            {
                transform.renderer.material = alterMat;
                count++;
            }
            else
            {
                transform.renderer.material = originMat;
                count++;
            }
        }
        lastTime = currentTime;
    }

    void OnCollisionExit(Collision other)
    {
        isExited = true;
    }
}
