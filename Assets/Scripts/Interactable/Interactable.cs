using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent<PlayerCharacter> onInteract;


    public void Interact(PlayerCharacter playerCharacter)
    {
        onInteract?.Invoke(playerCharacter);
    }
}
