using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerManager : MonoBehaviour
{
    public static PowerManager Instance;
    public int playerPower;

    [SerializeField]private int startPower = 1;

    private TextMeshPro playerPowerText;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        playerPowerText = GameObject.FindGameObjectWithTag(TagManager.PLAYER).transform.GetChild(2).GetChild(0).GetComponent<TextMeshPro>();
        playerPower = startPower;

        playerPowerText.text = playerPower.ToString();
    }

    public void AddPower(int power)
    {
        playerPower += power;
        playerPowerText.text = playerPower.ToString();
    }
}
