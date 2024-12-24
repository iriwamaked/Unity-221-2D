using UnityEngine;

public class CircleScript : MonoBehaviour
{
    //ссылка на наш компонент объекта Circle
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d= this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //тут не событийная системи, а Input просто меняет состояние
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //прикладываем силу вверх, Vector2=1
            rb2d.AddForce(Vector2.up * 500);
        }
    }
}
