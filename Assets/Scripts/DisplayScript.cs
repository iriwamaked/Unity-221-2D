using UnityEngine;


/*Скрипт, отвечающий за взаимодействие с полотном Display
 Отображение динамических показателей*/
public class DisplayScript : MonoBehaviour
{
    //[SerializeField]
    private TMPro.TextMeshProUGUI scoreText;
   // [SerializeField]
    private TMPro.TextMeshProUGUI timeText;

    private float gameTime;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMPro.TextMeshProUGUI>();
        timeText = GameObject.Find("TimeText").GetComponent<TMPro.TextMeshProUGUI>();
        gameTime = 0f;
    }

    void Update()
    {
        gameTime+=Time.deltaTime;

        int hours = Mathf.FloorToInt(gameTime/3600);
        int minutes = Mathf.FloorToInt((gameTime%3600)/60);
        int seconds = Mathf.FloorToInt(gameTime%60);

        timeText.text = $"{hours:00}:{minutes:00}:{seconds:00}";

        scoreText.text=CircleScript.score.ToString();
    }
}
