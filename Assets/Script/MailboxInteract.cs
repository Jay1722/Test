using UnityEngine;
using UnityEngine.InputSystem; // Wajib ditambahkan untuk New Input System

public class MailboxInteract : MonoBehaviour
{
    private bool isPlayerNear = false;
    private BackpackManager backpackManager;

    private void Start()
    {
        backpackManager = FindObjectOfType<BackpackManager>();
    }

    private void Update()
    {
        // Mengecek apakah keyboard aktif DAN tombol E ditekan menggunakan sistem baru
        if (isPlayerNear && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            backpackManager.OpenBackpackMailbox();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}