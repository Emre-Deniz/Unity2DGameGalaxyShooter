using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")] //grouping for shooting releated
    [SerializeField] AudioClip shootingClip; //field for shooting sound
    [SerializeField] [Range(0f,1f)] float shootingVolume = 1f; //shooting volume

    [Header("Damage")] //grouping for damage releated
    [SerializeField] AudioClip damageClip; //damage sound
    [SerializeField] [Range(0f,1f)] float damageVolume = 1f; //damage sound volume

    void Awake() // monobehavior function for run during scene start
    {
        ManageSingleton(); // singleton function call
    }

    void ManageSingleton() //function body
    {
        int instancecount = FindObjectsOfType(GetType()).Length; //find number of types about audio
        if(instancecount > 1)
        {
            gameObject.SetActive(false); //deactivate 
            Destroy(gameObject); //delete
        }
        else
        {
            DontDestroyOnLoad(gameObject); //keep 
        }
    }

    public void PlayShootingClip() //shooting audio clip function body
    {
        PlayClip(shootingClip,shootingVolume); //play clip with variables

         /* if(shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position,shootingVolume);
        }  // left for understanding      */
    }

    public void PlaydamageClip() //damage audio clip function body
    {
        PlayClip(damageClip,damageVolume); //play clip with variables
        /*if(damageClip != null)
        {
            AudioSource.PlayClipAtPoint(damageClip, Camera.main.transform.position,damageVolume);
        } //  left for understanding    */
    }

    void PlayClip(AudioClip clip , float volume) //generalized function
    {
        if(clip != null) // error catching
        {
            Vector3 camerapos = Camera.main.transform.position; //get camera position
            AudioSource.PlayClipAtPoint(clip,camerapos,volume); //play clip
        }
    }
}
