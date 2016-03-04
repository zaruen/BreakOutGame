using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{

    public float PaddleSpeed = 1f;

    private Vector3 playerPos = new Vector3(0,0,0);

	
	// Update is called once per frame
	void Update ()
	{
	    float xPos = transform.position.x + (Input.GetAxis("Horizontal") * PaddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), 0f, 0f);

	    transform.position = playerPos;
	}
}
