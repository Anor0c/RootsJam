using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPan : MonoBehaviour
{
    Animator _animator;
    bool isGameOver = false;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Pan()
    {
        isGameOver = true;
    }
}
