using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    private int activeIndex = 0;
    private PlayerControls playerControls;
    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += control => ToggleActiveSlot((int)control.ReadValue<float>());

        ToggleActiveHighlight(0);
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
        ChangeActiveWeapon();
    }
    private void ChangeActiveWeapon()
    {
        var currentWeapon = ActiveWeapon.Instance.CurrentWeapon;
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        if (!transform.GetChild(activeIndex).GetComponentInChildren<InventorySlot>())
        {
            ActiveWeapon.Instance.WeaponNull();
            return;
        }
        GameObject weaponToSpawn = transform.GetChild(activeIndex).GetComponentInChildren<InventorySlot>().GetWeaponInfo().weaponPrefab;

        GameObject newWeapon = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform.position, Quaternion.identity);
        ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, 0);
        newWeapon.transform.parent = ActiveWeapon.Instance.transform;
        ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
    }
}
