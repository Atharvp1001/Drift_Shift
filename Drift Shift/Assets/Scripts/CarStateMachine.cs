using UnityEngine;

public enum CarState //Health Related States for the car 
{
    Normal,
    Damaged,
    Invincible,
    Dead
}
public class CarStateMachine : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [Header("Invincibility")]
    [SerializeField] private float invincibleDuration = 3f;
    [SerializeField] private float invincibleTimer;

    [Header("Get Components")]
    private CarMovement movement;
    private BoostStateMachine boost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<CarMovement>();
        boost = GetComponent<BoostStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
