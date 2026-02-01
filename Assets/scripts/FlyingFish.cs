using UnityEngine;

public class FlyingFish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().ActivateJumpBuff();
            Destroy(gameObject);
        }
    }
}
