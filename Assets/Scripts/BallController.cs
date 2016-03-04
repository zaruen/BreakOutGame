using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public float BallInitialVelocity = 600f;

    private Rigidbody rb;
    private bool ballInPlay;

	// Use this for initialization
	void Awake ()
	{
	    rb = GetComponent<Rigidbody>();
	    ballInPlay = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Fire1 is the left mouse click
	    if (Input.GetButtonDown("Fire1") && !ballInPlay)
	    {
	        transform.parent = null;
	        ballInPlay = true;
	        rb.isKinematic = false;
            rb.AddForce(new Vector3(BallInitialVelocity, BallInitialVelocity, 0));
	    }
	}
}
