using System;
using UnityEngine;
using UnityEngine.UI;

internal class Score : MonoBehaviour
{
    private static int coins;
    private static event EventHandler CoinsIncremented;

    public Text scoreText;

    public static int Coins
    {
        get { return coins; }
        set
        {
            coins = value;
            if (CoinsIncremented != null)
            {
                CoinsIncremented(null, null);
            }
        }
    }

    private void Start()
    {
        if (scoreText != null)
        {
            CoinsIncremented += UpdateScore;
            scoreText.text = "0";
        }
    }

    private void OnDestroy()
    {
        CoinsIncremented = null;
        coins = 0;
    }

    private void UpdateScore(object p, EventArgs eventArgs)
    {
        scoreText.GetComponent<Animation>().Play();
        scoreText.text = coins.ToString();
    }
}