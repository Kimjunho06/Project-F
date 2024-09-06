using UnityEngine;

public class FieldItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("FieldItem"))
            GetItem(other.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("FieldItem"))
            GetItem(collision.transform);
    }

    private void GetItem(Transform trm)
    {
        if (trm.TryGetComponent<Item>(out var item))
        {
            //Debug.Log(collision.name);
            Inventory.instance.AddItem(item);
        }
        else
        {
            Debug.LogError("Missing item Scripts");
        }
    }

}
