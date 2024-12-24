using UnityEngine;

public class TubeScript : MonoBehaviour
{
    //������ ��������
    [SerializeField]
    private float speed = 1.0f;
    void Start()
    {
        
    }

    void Update()
    {
        //Time.deltaTime - ���������� ������� ������� ������ �� ����������� ������ (������)
        //������� �� �������� ������ �� �����, �������� ������ � ����� ��� ��� ��� �������� �� �����
        //Vector3.left * speed* Time.deltaTime
        //���� ����������� ������� � ������� ��������� �����, ��� ����� ������� ��������
        //������� ���������� ����� � ���������� �����, � ����� ������
        this.transform.Translate(speed* Time.deltaTime*Vector3.left);
    }
}
