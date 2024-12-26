using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public static int score;
    [SerializeField]
    private float forceFactor = 400;
    //ссылка на наш компонент объекта Circle
    private Rigidbody2D rb2d;

    private PauseScript pauseScript; //ссылка на объект скрипта
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        score = 0;
        GameObject pauseCanvas = GameObject.Find("PauseCanvas");
        if (pauseCanvas != null)
        {
            pauseScript = pauseCanvas.GetComponent<PauseScript>();
        }
        else
        {

            Debug.LogError("PauseCanvas not found");


        }
    }

        void Update()
        {
            //тут не событийная системи, а Input просто меняет состояние
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //прикладываем силу вверх, Vector2=1
                //deltaTime зависит от предыдущего фрейма, поэтому используем TimeScale
                rb2d.AddForce(forceFactor * Time.timeScale * Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector2 newPosition = rb2d.position + new Vector2(-20f * Time.deltaTime, 0);
                rb2d.MovePosition(newPosition);
                //rb2d.AddForce(Vector2.left * 500);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector2 newPosition = rb2d.position + new Vector2(20f * Time.deltaTime, 0);
                rb2d.MovePosition(newPosition);
                //rb2d.AddForce(Vector2.left * 500);
            }
        }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name + " " + other.tag);
        if (other.CompareTag("Fault"))
        {
            //Debug.Log("Game over");
            if (pauseScript != null)
            {
                pauseScript.ShowMessage("Game over");
            }
            else
            {
                Debug.Log("Game over");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tube"))
        {
            score += 1;
            //Debug.Log("+1");
        }
    }
}
