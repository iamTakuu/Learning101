using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] public UnityEvent onGameStart;

    private void Start()
    {
        onGameStart.AddListener(Game);
    }

    private void Game()
    {
        Debug.Log("Game Start!");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onGameStart.Invoke();
        }
    }
}
