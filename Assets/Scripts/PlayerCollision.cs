using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ICollisinable collisinable = collision.gameObject.GetComponent<ICollisinable>();

        collisinable.Collision();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagManager.FIREBALL))
        {
            Destroy(other.gameObject);
            Debug.Log("Game is Over");
        }
    }

}
