using UnityEngine;
using UnityEngine.SceneManagement;
/*Включение-выключение кнопкой Escape
 Деактивация GameObject приводит к деактивации его скриптов, 
поэтому обратная активация становится невозможной.
- Пауза физических процессов задается введением нулевого маштаба времени

 */
public class PauseScript : MonoBehaviour
{

    [SerializeField]
    private GameObject content;

    [SerializeField]
    private TMPro.TextMeshProUGUI messageText;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = content.activeInHierarchy?1.0f:0f;
            //Когда игра ставится на паузу, хотя процесс стоит на паузе, некоторые вещи 
            //продолжают выполняться. Время влияет на просчет законов движения(физики), но
            //не останавливает выполнение методов Update, они также продолжают выполняться.
            //Если движение обеспечивается принудительным перемещением, то он будет продолжаться.
            //Также будуть учитываться все действия типа AddForce(). Скрипты продолжают работать.
            //deltaTime=0.
            //!! Если предусматривается пауза игры, то все действия и перемещения должны 
            //учитывать или deltaTime, или timeScale
            //deltaTime зависит от предыдущего фрейма, поэтому используем timeScale
            content.gameObject.SetActive(!content.activeInHierarchy);
            //Time.timeScale = 1.0f;
        }
        
    }

    public void ShowMessage(string message)
    {
        Time.timeScale = 0.0f;
        content.SetActive(true);
        messageText.text = message;
    }

    public void OnResumeClick()
    {
        Time.timeScale = 1.0f;
        content.SetActive(false);
        GameObject go = GameObject.FindWithTag("Tube");
        Destroy(go);
    }

    public void OnRestartClick()
    {
        //Перезапуск сцены. Необходимо добавить сцену к Build, чтобы
        //менеджер сцены мог к ней обращаться 
        //File => Build profile => Scene List (переконатися, що сцена есть)
      

        SceneManager.LoadScene(0); //0-индекс сцены, который указан в Build

        Time.timeScale = 1.0f;
        content.SetActive(false);
    }
}
