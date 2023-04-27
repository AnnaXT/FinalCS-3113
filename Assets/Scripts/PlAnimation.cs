using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlAnimation : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
