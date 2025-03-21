using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoin, healthGlobe, staminaGlobe;


    public void DropItems()
    {
        int randonNum = Random.Range(1, 5);

        switch (randonNum)
        {
            case 1:
                Instantiate(healthGlobe, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(staminaGlobe, transform.position, Quaternion.identity);
                break;
            case 3:
                int randomAmountOfGold = Random.Range(1, 4);
                for (int i = 0; i < randomAmountOfGold; i++)
                {
                    Instantiate(goldCoin, transform.position, Quaternion.identity);
                }

                break;
        }
    }
}
