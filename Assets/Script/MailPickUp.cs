using UnityEngine;
using UnityEngine.InputSystem;

public class MailPickup : MonoBehaviour
{
    // BARU: Array untuk menyimpan daftar pilihan surat yang tersedia (misal 9 surat)
    public ItemData[] possibleMails; 
    
    // Jumlah surat yang akan terambil secara acak (misal 3)
    public int amountToPickup = 3; 
    
    private bool isPlayerNear = false;
    private BackpackManager backpackManager;

    private void Start()
    {
        backpackManager = FindObjectOfType<BackpackManager>();
    }

    private void Update()
    {
        if (isPlayerNear && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            // Mencegah error jika Anda lupa memasukkan data di Inspector
            if (possibleMails.Length > 0)
            {
                for (int i = 0; i < amountToPickup; i++)
                {
                    // Menentukan indeks acak dari 0 hingga batas akhir array
                    int randomIndex = Random.Range(0, possibleMails.Length);
                    
                    // Mengambil data surat berdasarkan indeks acak tersebut
                    ItemData randomMail = possibleMails[randomIndex];
                    
                    // Memasukkan surat acak tersebut ke dalam tas
                    backpackManager.AddItemToInventory(randomMail); 
                }
                
                Debug.Log("Berhasil mengambil " + amountToPickup + " surat acak!");
                
                // Opsional: Hapus objek dari scene setelah diambil agar tidak bisa di-spam
                // Destroy(gameObject); 
            }
            else
            {
                Debug.LogWarning("Kotak Possible Mails di Inspector masih kosong!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isPlayerNear = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) isPlayerNear = false;
    }
}