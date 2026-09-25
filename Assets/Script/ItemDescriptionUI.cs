using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDescriptionUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image iconImage;
    public GameObject deliveryButton; 
    
    private BackpackManager backpackManager;
    private SlotUI activeSlot; // Menyimpan slot mana yang sedang di-klik

    private void Start()
    {
        backpackManager = FindObjectOfType<BackpackManager>();
        deliveryButton.SetActive(false); 
    }

    // Perubahan: Sekarang menerima 'SlotUI' bukan 'ItemData'
    public void UpdateDescription(SlotUI slot)
    {
        if (slot != null && slot.itemInSlot != null)
        {
            activeSlot = slot; // Simpan memori slot yang sedang di-klik
            ItemData item = slot.itemInSlot;

            nameText.text = item.itemName;
            descriptionText.text = item.itemDescription;
            iconImage.sprite = item.itemIcon;
            iconImage.gameObject.SetActive(true);

            if (backpackManager.isDeliveryMode == true)
            {
                deliveryButton.SetActive(true);
            }
            else
            {
                deliveryButton.SetActive(false);
            }
        }
        else
        {
            ClearDescription();
        }
    }

    // Fungsi baru untuk dipanggil saat tombol Deliver diklik
    public void DeliverItem()
    {
        if (activeSlot != null)
        {
            activeSlot.ClearItem(); // Hapus item dari slot tas
            ClearDescription();     // Bersihkan tampilan panel kiri
            Debug.Log("Surat berhasil dikirim!");
        }
    }

    public void ClearDescription()
    {
        activeSlot = null;
        nameText.text = "";
        descriptionText.text = "";
        iconImage.gameObject.SetActive(false);
        deliveryButton.SetActive(false); 
    }
}