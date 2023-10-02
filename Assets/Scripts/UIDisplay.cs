using UnityEngine;
using UnityEngine.UI; //!!!!!!!!!!!
using TMPro;  //!!!!!!!!!!!

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]

    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth(); //get max health
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth(); //get health while playing
        scoreText.text = scoreKeeper.GetScore().ToString("0000000000000"); // write score with 0's
    }
}
