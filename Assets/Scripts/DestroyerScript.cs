using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //���������� ������ 
        //Debug.Log(other.name);  
        //����� ����������� �� �������� - ���� ������ ����� transform
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
