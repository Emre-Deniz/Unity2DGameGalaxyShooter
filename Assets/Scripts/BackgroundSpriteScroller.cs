using UnityEngine;

public class BackgroundSpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed; //background move speed
    Vector2 offset; //background offset
    Material material; //background material
    void Awake() // monobehavior function for run during scene start
    {
        material = GetComponent<SpriteRenderer>().material; // get related material
    }

    // Update is called once per frame
    void Update()
    {
        offset = moveSpeed * Time.deltaTime; //offset for real time moving
        material.mainTextureOffset += offset; //moving
    }
}
