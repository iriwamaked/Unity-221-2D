using UnityEngine;

public class TubeScript : MonoBehaviour
{
    //задаем скорость
    [SerializeField]
    private float speed = 1.0f;
    void Start()
    {
        
    }

    void Update()
    {
        //Time.deltaTime - показывает сколько времени прошло от предыдущего фрейма (геттер)
        //Сначала мы умножаем вектор на число, получаем Вектор и потом еще раз его умножаем на число
        //Vector3.left * speed* Time.deltaTime
        //если переставить местами и сначала поставить числа, это более простая операция
        //сначала умножаются числа и получается число, а потом вектор
        this.transform.Translate(speed* Time.deltaTime*Vector3.left);
    }
}
