using UnityEngine;

public class ActiveInventory : Singleton<ActiveInventory>
{
    private int activeIndex = 0;
    private PlayerControls playerControls;
    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += control => ToggleActiveSlot((int)control.ReadValue<float>());
    }
    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    public void EquipStartingWeapon()
    {
        ToggleActiveHighlight(0);
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
        var currentWeapon = ActiveWeapon.Instance.CurrentActiveWeapon;
        if (currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }

        Transform childTransform = transform.GetChild(activeIndex);
        InventorySlot inventorySlot = childTransform.GetComponentInChildren<InventorySlot>();
        if (!inventorySlot.isActiveAndEnabled)
        {
            return;
        }
        WeaponInfo weaponInfo = inventorySlot.GetWeaponInfo();
        GameObject weaponToSpawn = weaponInfo.weaponPrefab;

        if (weaponInfo == null)
        {
            ActiveWeapon.Instance.WeaponNull();
            return;
        }

        GameObject newWeapon = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform);
        //ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, 0);
        //newWeapon.transform.parent = ActiveWeapon.Instance.transform;

        ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
    }
}
