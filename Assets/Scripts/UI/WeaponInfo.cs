using UnityEngine;
[CreateAssetMenu(menuName = "New weapon")]
public class WeaponInfo : ScriptableObject
{
    public GameObject weaponPrefab;
    public float weaponCD;
}
