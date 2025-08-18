using UnityEngine;

public enum CarState //Health Related States for the car 
{
    Normal,
    Invincible,
    Dead
}
public class CarStateMachine : MonoBehaviour
{
    public CarState currentState = CarState.Normal;
    
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [Header("Invincibility")]
    [SerializeField] private float invincibleDuration = 3f;
    [SerializeField] private float invincibleTimer;

    [Header("Get Components")]
    private CarMovement movement;
    private Animator animator;
    private BoostStateMachine boost;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        movement = GetComponent<CarMovement>();
        boost = GetComponent<BoostStateMachine>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case CarState.Normal:
                if (currentHealth < maxHealth * 0.25f) //To check if the helth is less than 25% 
                {
                    animator.Play("Damaged");
                }
                    
                else
                {
                    animator.Play("Normal");
                }
                break; 

            case CarState.Dead:
                movement.enabled = false;
                animator.Play("Dead");
                break; 

            case CarState.Invincible:
                animator.Play("Invincible");
                HandleInvincible();
                break; 
        }
    }

    public void TakeDamage(int damage = 10)
    {
        if(currentState == CarState.Dead || currentState == CarState.Invincible)
        {
            return;
        }

        currentHealth -= damage; //Take Damage

        if (currentHealth <=0)//Check if the player is dead 
        {
            currentHealth = 0;
            currentState = CarState.Dead;
        }
        else //Start Invincible after taking dmg 
        {
            currentState = CarState.Invincible;
            invincibleTimer = invincibleDuration;
        }
    }

    public void HandleInvincible()
    {
        invincibleTimer -= Time.deltaTime; //Decrease Timer per Frame 

        if (invincibleTimer <= 0)
        {
            currentState = CarState.Normal;
        }
    }


}
