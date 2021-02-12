using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public float ScrollSpeed = -1.5f;
    public GameObject GameOvahText;
    public Text ScoreText;
    public bool gameOver = false;

    private int score = 0;


    // Awaken, my masters!
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy (gameObject);
        }
    }

    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
                SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
        }
    }

    public void BordScored()
    {
        if (gameOver)
        {
            return;
        }
        score++;
        ScoreText.text = "Score: " + score.ToString();
    }


    public void BordDied ()
    {
        GameOvahText.SetActive(true);
        gameOver = true;
    }
}
