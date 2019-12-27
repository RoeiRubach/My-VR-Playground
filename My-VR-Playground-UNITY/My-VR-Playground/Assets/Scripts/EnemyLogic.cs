﻿using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField]
    private Transform playerLocation;
    
    [Header("Enemy properties")]
    private float runningSpeed = 2f;
    private bool isZombieDead;

    [Space]

    [Header("Audio variables")]
    [SerializeField]
    private AudioClip zombieDead;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        transform.LookAt(playerLocation);

        if (!isZombieDead)
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * runningSpeed;
        }
        else
        {
            transform.position = transform.position - transform.up * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            isZombieDead = true;
            gameObject.GetComponent<Collider>().isTrigger = true;
            audioSource.Stop();
            audioSource.volume = 0.4f;
            audioSource.PlayOneShot(zombieDead);

            Destroy(gameObject, 2.3f);
        }
    }
}
