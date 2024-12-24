using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //инструмент вывода 
        //Debug.Log(other.name);  
        //чтобы достучаться до родителя - надо делать через transform
        Transform parent = other.transform.parent;
        if (parent != null)
        {
            Destroy(parent.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        Debug.Log(other.transform.parent.gameObject.name);

    }
}
