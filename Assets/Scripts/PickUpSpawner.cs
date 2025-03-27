using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mapEnder;
    [SerializeField] private List<GameObject> otherItems;


    public void DropItems()
    {
        if (mapEnder != null)
        {
            Instantiate(mapEnder, transform.position, Quaternion.identity);
        }
        if (otherItems.Count > 0)
        {
            int randomNum = Random.Range(0, otherItems.Count);
            Instantiate(otherItems[randomNum], transform.position, Quaternion.identity);
        }
    }
}
