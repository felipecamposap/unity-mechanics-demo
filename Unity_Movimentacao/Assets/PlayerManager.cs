using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetPlayerEnabled(0);
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetPlayerEnabled(1);
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetPlayerEnabled(2);
        }

        if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetPlayerEnabled(3);
        }
    }

    void SetPlayerEnabled(byte index)
    {
        for (byte i = 0; i < players.Length; i++)
        {
            if(i == index)
            {
                players[i].SetActive(true);
            }
            else
            {
                players[i].SetActive(false);
            }
        }
    }
}
