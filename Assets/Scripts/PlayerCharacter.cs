using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerData playerData;

    public void AddMoney(int money)
    {
        playerData.money += money;
    }
}
