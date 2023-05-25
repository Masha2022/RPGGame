using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Action OnOpenChest;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Open()
    {
        _animator.SetTrigger("open");
    }
}