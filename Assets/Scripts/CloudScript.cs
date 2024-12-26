using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.2f; //скорость движения облаков (сериализируемая, можно отредактировать в Unity на лету)
    //public Vector3 startPosition;
    //public Vector3 resetPosition;
    //private Vector3[] cloudStartPositions;

    //ссылка на главную камеру
    private Camera mainCamera;
    //правая граница экрана
    private float screenRightEdge;

    private Transform[] clouds;
    void Start()
    {
        clouds= GetComponentsInChildren<Transform>();
        //ссылка на главную камеру
        mainCamera=Camera.main;
        //рассчитываем правую границу экрана
        screenRightEdge=mainCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        //cloudStartPositions = new Vector3[clouds.Length];

        //for (int i = 0; i < clouds.Length; i++)
        //{
        //    cloudStartPositions[i] = clouds[i].position;
        //}
    }

    void Update()
    {
        //двикаем каждое облако в группе
        foreach (Transform cloud in clouds)
        {
            //игнор для родителя
            if (cloud == transform) continue;
            //движение облака влево
            cloud.Translate(speed * Time.deltaTime * Vector3.left);
            //условие, когда облако уходит за пределы левой границы экрана
            if(cloud.position.x<mainCamera.ViewportToWorldPoint(new Vector3(-0.1f, 0, 0)).x)
            {
                //перемещение облака за правую границу экрана
                cloud.position=new Vector3(screenRightEdge + 1f, cloud.position.y, cloud.position.z);
            }

            //if (cloud.position.x < resetPosition.x)
            //{
            //    cloud.position=new Vector3(startPosition.x, cloud.position.y, cloud.position.z);
            //}
        }

        ////Time.deltaTime - показывает сколько времени прошло от предыдущего фрейма (геттер)
        ////Сначала мы умножаем вектор на число, получаем Вектор и потом еще раз его умножаем на число
        ////Vector3.left * speed* Time.deltaTime
        ////если переставить местами и сначала поставить числа, это более простая операция
        ////сначала умножаются числа и получается число, а потом вектор
        //this.transform.Translate(speed * Time.deltaTime * Vector3.left);

        //if (transform.position.x < resetPosition.x)
        //{
        //    transform.position= new Vector3(startPosition.x, Random.Range(-2f, 2f), startPosition.z);
        //}
    }
}
