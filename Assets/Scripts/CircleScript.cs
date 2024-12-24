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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //������������ ���� �����, Vector2=1
            rb2d.AddForce(Vector2.up * 500);
        }
    }
}
