using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private ProjectileSlotUI slotPrefab;

    [SerializeField]
    private Transform itemsPlacement;

    private List<ProjectileSlotUI> existedSlots = new();

    private void Start()
    {
        inventory.OnInventoryChanged.AddListener(ReloadItems);
        inventory.OnChoosenChanged.AddListener(ReloadChoosen);
    }

    public void ReloadItems(List<Inventory.ProjectileSlot> Slots)
    {
        ClearItems();

        AddItems(Slots);
    }

    public void AddItems(List<Inventory.ProjectileSlot> Slots)
    {

        foreach (Inventory.ProjectileSlot slot in Slots)
        {
            ProjectileSlotUI newSlotUI =
                Instantiate(slotPrefab.gameObject, itemsPlacement.transform)
                .GetComponent<ProjectileSlotUI>();

            newSlotUI.SetProjectile(slot);

            existedSlots.Add(newSlotUI);
        }

        SetChoosen(inventory.ChoosenProjectile);
    }

    public void ClearItems()
    {
        int childCount = itemsPlacement.childCount;

        for (int i = childCount; i > 0; i--)
        {
            Destroy(itemsPlacement.GetChild(i - 1).gameObject);
        }

        existedSlots.Clear();
    }

    public void ReloadChoosen(int choosen)
    {
        ReloadItems(inventory.Projectiles);

        SetChoosen(choosen);
    }

    public void SetChoosen(int choosen)
    {
        for (int i = 0; i < existedSlots.Count; i++)
        {
            existedSlots[i].SetChoosen(i == choosen);
        }
    }
}
