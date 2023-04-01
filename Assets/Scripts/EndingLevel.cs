using UnityEngine;

public class EndingLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayCongratsSound();
            GameManager.Instance.DoVictory();
        }
    }
}
