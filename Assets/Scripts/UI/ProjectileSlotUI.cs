using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileSlotUI : MonoBehaviour
{
    [SerializeField]
    private Image iconPlacement;

    [SerializeField]
    private TextMeshProUGUI countPlacement;

    [SerializeField]
    private GameObject onChoosen;

    public void SetProjectile(Inventory.ProjectileSlot Slot)
    {
        iconPlacement.sprite = Slot.Projectile
            .GetComponent<SpriteRenderer>().sprite;

        countPlacement.text = Slot.Count.ToString();
    }

    public void SetChoosen(bool IsChoosen)
    {
        onChoosen.SetActive(IsChoosen);
    }
}
