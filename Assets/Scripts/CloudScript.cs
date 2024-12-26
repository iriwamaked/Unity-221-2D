using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.2f; //�������� �������� ������� (���������������, ����� ��������������� � Unity �� ����)
    //public Vector3 startPosition;
    //public Vector3 resetPosition;
    //private Vector3[] cloudStartPositions;

    //������ �� ������� ������
    private Camera mainCamera;
    //������ ������� ������
    private float screenRightEdge;

    private Transform[] clouds;
    void Start()
    {
        clouds= GetComponentsInChildren<Transform>();
        //������ �� ������� ������
        mainCamera=Camera.main;
        //������������ ������ ������� ������
        screenRightEdge=mainCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        //cloudStartPositions = new Vector3[clouds.Length];

        //for (int i = 0; i < clouds.Length; i++)
        //{
        //    cloudStartPositions[i] = clouds[i].position;
        //}
    }

    void Update()
    {
        //������� ������ ������ � ������
        foreach (Transform cloud in clouds)
        {
            //����� ��� ��������
            if (cloud == transform) continue;
            //�������� ������ �����
            cloud.Translate(speed * Time.deltaTime * Vector3.left);
            //�������, ����� ������ ������ �� ������� ����� ������� ������
            if(cloud.position.x<mainCamera.ViewportToWorldPoint(new Vector3(-0.1f, 0, 0)).x)
            {
                //����������� ������ �� ������ ������� ������
                cloud.position=new Vector3(screenRightEdge + 1f, cloud.position.y, cloud.position.z);
            }

            //if (cloud.position.x < resetPosition.x)
            //{
            //    cloud.position=new Vector3(startPosition.x, cloud.position.y, cloud.position.z);
            //}
        }

        ////Time.deltaTime - ���������� ������� ������� ������ �� ����������� ������ (������)
        ////������� �� �������� ������ �� �����, �������� ������ � ����� ��� ��� ��� �������� �� �����
        ////Vector3.left * speed* Time.deltaTime
        ////���� ����������� ������� � ������� ��������� �����, ��� ����� ������� ��������
        ////������� ���������� ����� � ���������� �����, � ����� ������
        //this.transform.Translate(speed * Time.deltaTime * Vector3.left);

        //if (transform.position.x < resetPosition.x)
        //{
        //    transform.position= new Vector3(startPosition.x, Random.Range(-2f, 2f), startPosition.z);
        //}
    }
}
