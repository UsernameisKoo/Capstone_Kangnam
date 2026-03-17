using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickUp : MonoBehaviour
{
    [SerializeField] int money;

    public void PickUp(PlayerCharacter playerCharacter)

    {
        playerCharacter.AddMoney(money);
    }
}
