using Unity.Mathematics;
using UnityEngine;

public class Health : MonoBehaviour
{
    //player and enemies both have health
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect; //for hit effect
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake() // to find necessary components and objects on scene start
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other) //bumping to each other
    {
        DamageDealer damagedealer = other.GetComponent<DamageDealer>(); // find component
        if(damagedealer != null) //error catching
        {
            TakeDamage(damagedealer.GetDamage());// take damage
            PlayHitEffect(); //play effect
            audioPlayer.PlaydamageClip(); // play audio
            ShakeCamera(); 
            damagedealer.Hit(); //die
        }
    }

    public int GetHealth() //health getter
    {
        return health;
    }

    void TakeDamage(int damage) //to take damage
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die() //if health reaches 0 or below
    {
        if(!isPlayer) // enemy death
        {
            scoreKeeper.ModifyScore(score); // increase score
        }
        else // player death
        {
            levelManager.LoadEnding(); // load ending scene
        }
        Destroy(gameObject);// destroy dead object
    }



    void PlayHitEffect()
    {
        if(hitEffect != null) //error catching
        {
            ParticleSystem instance = Instantiate(hitEffect , transform.position , quaternion.identity); //create effect
            Destroy(instance.gameObject , instance.main.duration + instance.main.startLifetime.constantMax); // end effect
        }
    }

     void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake ) // error catching
        {
            cameraShake.Play(); 
        }
    }
}
