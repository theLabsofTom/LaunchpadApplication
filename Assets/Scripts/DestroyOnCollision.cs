using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {
    public string CollidersTag;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(CollidersTag))
        {
            Destroy(gameObject);
        }
    }
}
