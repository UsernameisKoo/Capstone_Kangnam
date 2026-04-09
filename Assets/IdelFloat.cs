using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleFloat : MonoBehaviour
{
    public RectTransform target;
    public float amplitude = 4f;
    public float speed = 2f;

    private Vector2 basePos;

    void Start()
    {
        basePos = target.anchoredPosition;
    }

    void Update()
    {
        target.anchoredPosition = basePos + new Vector2(0, Mathf.Sin(Time.time * speed) * amplitude);
    }
}
