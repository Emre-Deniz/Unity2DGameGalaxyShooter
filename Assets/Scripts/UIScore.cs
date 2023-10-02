using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {
      scoreText.text = scoreKeeper.GetScore().ToString(); // write score to end text  
    }
}
