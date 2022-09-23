using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyBase : MonoBehaviour , ICollisinable
{
    protected Animator animator;
    protected GameObject player;
    protected GameObject powerBar;
    protected int power;
    [SerializeField] protected TextMeshPro powerText;

    [SerializeField] private int minimumPower;
    [SerializeField] private int maximumPower;
    [SerializeField] private float movementSpeed;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER);
        powerBar = transform.GetChild(2).gameObject;
        animator = GetComponent<Animator>();
        powerText = transform.GetChild(2).GetChild(0).GetComponent<TextMeshPro>();
        power = Random.Range(minimumPower, maximumPower);
    }
    protected void Chasing()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);
        transform.LookAt(player.transform.position);

        PowerBarPosition();
    }

    protected void PowerBarPosition()
    {
        powerText.text = power.ToString();
        powerBar.transform.position = new Vector3(transform.position.x, 3f, transform.position.z);
        powerBar.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public void Collision()
    {
        if (PowerManager.Instance.playerPower > power)
        {
            PowerManager.Instance.AddPower(5);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Game is over");
            Destroy(this.gameObject);
        }

    }
}
