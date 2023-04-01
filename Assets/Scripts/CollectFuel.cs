using UnityEngine;

public class CollectFuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            FuelController.Instance.FillFuel();
            Destroy(gameObject);
        }
    }
}
