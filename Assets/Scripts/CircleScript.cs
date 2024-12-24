using UnityEngine;

public class CircleScript : MonoBehaviour
{
    //������ �� ��� ��������� ������� Circle
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d= this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //��� �� ���������� �������, � Input ������ ������ ���������
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //������������ ���� �����, Vector2=1
            rb2d.AddForce(Vector2.up * 500);
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
}
