using UnityEngine;

public class PickUpLast : MonoBehaviour
{
    [SerializeField] private GameObject finalReward;

    public void DropFinalItem()
    {
        if (finalReward != null)
        {
            Instantiate(finalReward, transform.position, Quaternion.identity);
        }
    }    
    }
}
