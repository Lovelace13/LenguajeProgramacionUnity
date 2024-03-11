using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text textScore;

    // Start is called before the first frame update
    public void AddScore()
    {
        score++;
        textScore.text = score.ToString();
    }
}
