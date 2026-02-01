using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform player;   // Player yang akan diikuti
    public Vector3 offset;     // Posisi relatif terhadap player

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
