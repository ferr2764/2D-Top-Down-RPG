using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Stamina: Singleton<Stamina>
{
    public int CurrentStamina { get; private set; }

    [SerializeField] private Sprite fullStaminaImage, emptyStaminaImage;
    [SerializeField] private int timeBetweenStaminaRefresh = 3;

    private Transform staminaContainer;
    private int startingStamina = 3;
    private int maxStamina;
    const string STAMINA_CONTAINER_TEXT = "Stamina Container";

    protected override void Awake()
    {
        base.Awake();

        maxStamina = startingStamina;
        CurrentStamina = startingStamina;
    }

    private void Start()
    {
        staminaContainer = GameObject.Find(STAMINA_CONTAINER_TEXT).transform;
    }

    public void UserStamina()
    {
        CurrentStamina -= 1;
        UpdateStaminaImages();
    }

    public void RefreshStamina()
    {
        if (CurrentStamina < maxStamina)
        {
            CurrentStamina += 1;
        }

        UpdateStaminaImages();
    }

    private IEnumerator RefreshStaminaRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenStaminaRefresh);
            RefreshStamina();
        }
    }

    private void UpdateStaminaImages()
    {
        for (int i = 0; i < maxStamina; i++)
        {
            staminaContainer.GetChild(i).GetComponent<UnityEngine.UI.Image>().sprite = i <= CurrentStamina - 1 ? fullStaminaImage : emptyStaminaImage;
        }
    }
}
