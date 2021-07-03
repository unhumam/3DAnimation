using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI victoryText;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            score++; 
            Destroy(collision.gameObject);
            Debug.Log(collision);
        }

    }

    void Update()
    {
        scoreText.SetText("Score = " + score);
        Objective();
    }

    void Objective()
    {
        if (score <= 3)
        {
            victoryText.SetText("Pick up all the coins!");

        }
        else
        {
            victoryText.SetText("You got it son!");
        }
    }
}

