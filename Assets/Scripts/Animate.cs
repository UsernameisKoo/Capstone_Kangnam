using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;
    public float motion;

    public void Awake()
    {
        animator= GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("motion", motion);
    }
}
