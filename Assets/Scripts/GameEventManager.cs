using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager instance;

    private void Awake()
    {
        instance = this;
    }
    public UnityEvent GameStart;

    public UnityEvent<bool> GameOver;

    public UnityEvent<float,float> SpicyRate;
}
