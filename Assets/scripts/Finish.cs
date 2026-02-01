using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winPanel; // drag WinPanel di Inspector

    void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false); // panel awalnya tidak muncul
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger hit: " + other.name);

        if (other.CompareTag("Player"))
        {
            if (winPanel != null)
            {
                winPanel.SetActive(true);
                Debug.Log("WinPanel aktif: " + winPanel.activeSelf);
            }
            else
            {
                Debug.LogError("WinPanel belum di-link!");
            }
        }
    }
}
