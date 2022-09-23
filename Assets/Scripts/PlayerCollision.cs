using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public static event Action<int> OnCollectPotion;

    [SerializeField] private int potionPower;
    private void OnCollisionEnter(Collision collision)
    {
        ICollisinable collisinable = collision.gameObject.GetComponent<ICollisinable>();
        if (collisinable != null)
        {
            collisinable.Collision();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(TagManager.FIREBALL))
        {
            Destroy(other.gameObject);
            Debug.Log("Game is Over");
        }
        else if(other.gameObject.CompareTag(TagManager.POTION))
        {
            OnCollectPotion?.Invoke(potionPower);
            Destroy(other.gameObject);
        }
    }

}
