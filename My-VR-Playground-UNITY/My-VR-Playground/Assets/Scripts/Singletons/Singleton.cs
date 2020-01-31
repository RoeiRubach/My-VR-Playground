﻿using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
            Instance = (T)FindObjectOfType(typeof(T));
        else
            Destroy(gameObject);
    }
}