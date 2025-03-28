using UnityEngine;

public class Map3Ender : MapEnder
{
    public override void Action()
    {
        //Open slot 2
        var activeInv = ActiveInventory.Instance;
        //Inventory 2 (game object)
        var inventory2 = activeInv.transform.GetChild(2).gameObject;
        var slot = inventory2.GetComponent<InventorySlot>();
        slot.enabled = true;
        //Item (game object)
        inventory2.transform.GetChild(1).gameObject.SetActive(true);
        //Open exit
        AreaExit.GotItem = true;
    }
}
