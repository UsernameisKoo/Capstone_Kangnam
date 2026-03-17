using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicDebugMessage : MonoBehaviour
{
    [SerializeField] string message;

    public void Post()
    {
        Debug.Log(message);
    }
}
