using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{

    private int score;
    public Text scoreText;

    public Text fruitNotToGrabText;
    private string fruitNotToGrab;

    public Color orange;
    public Color green;
    public Color red;

    public Text lostText;
    private int wrongBalls;

    private bool gameHasEnded;
    public float restartDelay = 1.0f;

    public CameraShake cameraShake;

    void Awake()
    {
        score = 0;
        SetScoreText(); //we set the score text to "Score: 0" in the start.

        string str1 = "Do not collect the ";
        string str2 = "s!!";

        int rand_color = Random.Range(0, 4);

        if (rand_color == 0)
        {
            fruitNotToGrab = "carrot";
            fruitNotToGrabText.color = orange;
        }
        else if (rand_color == 1)
        {
            fruitNotToGrab = "orange";
            fruitNotToGrabText.color = orange; 
        }
        else if (rand_color == 2)
        {
            fruitNotToGrab = "apple";
            fruitNotToGrabText.color = green;
        }
        else
        {
            fruitNotToGrab = "watermelon";
            fruitNotToGrabText.color = red;
        }
        fruitNotToGrabText.text = str1 + fruitNotToGrab + str2; //in any case, the final text displayed will be this one.

        lostText.text = "";
        wrongBalls = 0;
        gameHasEnded = false;
    }

    public string getColorNotToGrab()
    {
        return fruitNotToGrab;
    }

    public void addWrong()
    {
        if(wrongBalls < 10) ///////////////////////////change to 5!
        {
            wrongBalls++;
            score -= 5;
            //Debug.Log("Wrong");

            StartCoroutine(cameraShake.Shake(1.2f, 11.5f));

        }
        else
        {
            if (!gameHasEnded)
            {
                gameHasEnded = true;
                lostText.text = "Wrong ball!!!";
                Invoke("restartGame", restartDelay); //we call restartGame() with a delay of 1 second
            }
        }
    }

    private void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void addCorrect()
    {
        //Debug.Log("Nice!");
        score += 25;


        SetScoreText();
    }


    void SetScoreText()
    {
        string str = "";

        int sc = int.Parse(scoreText.text);

        if (sc <= 0)
        {
            str = "000";
        }
        else if (sc <= 9 && sc > 0)
        {
            str = "000";
        }
        else if(sc <= 99 && sc >= 10)
        {
            str = "00";
        }
        else if (sc <= 999 && sc >= 100)
        {
            str = "0";
        }
        else if(sc <= 9999 && sc >= 1000)
        {
            str = "";
        }
        scoreText.text = str + score.ToString();
    }

}
