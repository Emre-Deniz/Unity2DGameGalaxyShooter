using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 0.5f; // camera shake duration
    [SerializeField] float shakeMagnitude = 0.2f; // camera shake magnitude
    Vector3 initialPosition; // camera starting position


    // Start is called before the first frame update
    void Start()
    {
        initialPosition =transform.position; // camera starting position 
    }

    public void Play() // monobehavior play
    {
        StartCoroutine(Shake());//coroutine
    }
    IEnumerator Shake() // coroutine body
    {
        float elapsedTime = 0f; // elapsed time variable
        while(elapsedTime < shakeDuration) //shake till duration
        {
        transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude; //shake once
        elapsedTime += Time.deltaTime; //increase elapsed time

        yield return new WaitForEndOfFrame(); //wait
        }
        transform.position = initialPosition; // return camera to starting position
    }
}
