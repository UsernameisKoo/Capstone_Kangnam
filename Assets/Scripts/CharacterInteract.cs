using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    [SerializeField] Transform pivot;
    [SerializeField] Vector3 interactAreaSize = Vector3.one;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    public void Interact()
    {
        Collider[] colliders = Physics.OverlapBox(pivot.position, interactAreaSize);

        foreach (Collider c in colliders)
        {
            Interactable interactable = c.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact(playerCharacter);
                break;
            }
        }
    }
}
