using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    private int activeIndex = 0;
    private PlayerControls playerControls;
    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += control => ToggleActiveSlot((int)control.ReadValue<float>());
    }
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void ToggleActiveSlot(int value)
    {
        ToggleActiveHighlight(value - 1);
    }
    private void ToggleActiveHighlight(int value)
    {
        activeIndex = value;
        foreach (Transform item in this.transform)
        {
            item.GetChild(0).gameObject.SetActive(false);
        }
        this.transform.GetChild(value).GetChild(0).gameObject.SetActive(true);
    }
}
