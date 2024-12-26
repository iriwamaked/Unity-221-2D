using Unity.VisualScripting;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject TubePrefab;
    [SerializeField]
    private float TubeSpawnShift = 1.0f;

    [SerializeField]
    private float timeout = 4.0f;
    private float leftTime;
    void Start()
    {
        //leftTime = timeout; Первый запуск через таймаут
        leftTime = 0;  //Первый запуск сразу
    }

    void Update()
    {
        leftTime -= Time.deltaTime;
        if(leftTime <= 0)
        {
            SpawnTube();
            leftTime = timeout;
        }
    }
    private void SpawnTube()
    {
       var tube =  GameObject.Instantiate(TubePrefab); //замена элемента new TubePrefab()
        //В Unity вместе наследования использовуется агрегация => вместо конструктора используем
        //GameObject.Instantiate, который и создает объект
        tube.transform.position = this.transform.position; //this - Spawner => труба появится в его координатах
        tube.transform.position += Vector3.up * Random.Range(-TubeSpawnShift, TubeSpawnShift);
    }
}
/*
 Скрипт, который отвечает за появление объектов
Идея: отсчет времени (таймер)
 */
