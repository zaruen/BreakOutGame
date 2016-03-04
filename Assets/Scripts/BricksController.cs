using UnityEngine;
using System.Collections;

public class BricksController : MonoBehaviour
{

    public GameObject BrickParticle;

    void OnCollisionEnter(Collision other)
    {
        Instantiate(BrickParticle, transform.position, Quaternion.identity);
        GameManager.Instance.DestroyBrick();
        Destroy(gameObject);
    }
}
