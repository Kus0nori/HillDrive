using UnityEngine;

public class HeadBumpDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            AudioManager.Instance.PlayCrackSound();
            GameManager.Instance.GameOver();
        }
    }
}
