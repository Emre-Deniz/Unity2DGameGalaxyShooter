using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab; // create gameobject
    [SerializeField] float projectileSpeed = 15f; // speed
    [SerializeField] float projectileLifeTime = 5f; // how long it stays on game
    [SerializeField] float baseFireRate = 0.2f;

    [Header("AI Releated")]
    [SerializeField] bool useAI; // checkbox for enemies
    [SerializeField] float firingRateVariance = 0.5f;
    [SerializeField] float minimumFiringRate = 0.3f;
    [HideInInspector] public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindAnyObjectByType<AudioPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(useAI) // to non-stop firing for ai
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null){
        firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring  && firingCoroutine != null )
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab,
            transform.position,
            quaternion.identity); // create projectile to shooters position

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

            if(rb != null) // errror catching
            {
                rb.velocity = transform.up * projectileSpeed ; // move projectile
            }

            Destroy(instance , projectileLifeTime); // destroy projectile after lifetime ends

            float timeToNextProjectile = UnityEngine.Random.Range(baseFireRate - firingRateVariance , baseFireRate + firingRateVariance); // for next projectile

            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile , minimumFiringRate , float.MaxValue); // range

            audioPlayer.PlayShootingClip(); // play audio


            yield return new WaitForSeconds(timeToNextProjectile); // coroutine waiting
        }
    }
}
