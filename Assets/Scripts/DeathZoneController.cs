using UnityEngine;
using System.Collections;

public class DeathZoneController : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        GameManager.Instance.LoseLife();
    }
}
