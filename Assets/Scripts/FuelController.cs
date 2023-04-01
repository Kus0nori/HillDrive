using UnityEngine;

public class FuelController : MonoBehaviour
{
    public static FuelController Instance;
    [SerializeField, Range(0.1f, 5f)] private float fuelDrainSpeed = 1f;
    public float maxFuelAmount = 100f;
    
    
    public float currentFuelAmount;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        currentFuelAmount = maxFuelAmount;
    }

    private void Update()
    {
        currentFuelAmount -= Time.deltaTime * fuelDrainSpeed;
        if (currentFuelAmount <= 0f)
        {
            GameManager.Instance.GameOver();
        }
    }

    public void FillFuel()
    {
        currentFuelAmount = maxFuelAmount;
    }
}
