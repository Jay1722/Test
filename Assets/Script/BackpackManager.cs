using UnityEngine;

public class BackpackManager : MonoBehaviour
{
    public GameObject backpackWindow; 
    public GameObject backpackIconBtn; 
    
    // ARRAY BARU: Tempat menyimpan daftar semua slot yang ada di tas
    public SlotUI[] inventorySlots; 

    [HideInInspector] public bool isDeliveryMode = false; 

    private void Start()
    {
        backpackWindow.SetActive(false);
        backpackIconBtn.SetActive(true);
    }

    // --- FUNGSI BARU UNTUK MENDAPATKAN ITEM ---
    public void AddItemToInventory(ItemData itemToAdd)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            // Cari slot yang kosong
            if (inventorySlots[i].itemInSlot == null)
            {
                inventorySlots[i].SetItem(itemToAdd);
                Debug.Log(itemToAdd.itemName + " berhasil dimasukkan ke tas!");
                return; // Stop mencari jika sudah berhasil masuk tas
            }
        }
        Debug.Log("Tas penuh!");
    }

    public void OpenBackpackNormal()
    {
        isDeliveryMode = false; 
        OpenBackpack();
    }

    public void OpenBackpackMailbox()
    {
        isDeliveryMode = true; 
        OpenBackpack();
    }

    private void OpenBackpack()
    {
        backpackWindow.SetActive(true);
        backpackIconBtn.SetActive(false);
        FindObjectOfType<ItemDescriptionUI>().ClearDescription();
    }

    public void CloseBackpack()
    {
        backpackWindow.SetActive(false);
        backpackIconBtn.SetActive(true);
        isDeliveryMode = false; 
    }
}