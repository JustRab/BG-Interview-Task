using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public float speed;
    public int health;
    public int maxHealth;
    public int attackDamage;
    public int money;


    public GameObject inventoryPanel;
    public PlayerStatsSO playerStats; // Reference to the PlayerStatsSO
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI moneyText;

    [SerializeField] private GameObject attackHitbox;
    private CharacterView CharacterView;

    [SerializeField] private bool isInteracting = false;
    [SerializeField] private bool isWalking = false;

    // Start is called before the first frame update
    public void Start()
    {
        CharacterView = GetComponent<CharacterView>();

        // Load stats from the PlayerStatsSO
        LoadStats();
    }

    // Method to load stats from the PlayerStatsSO
    void LoadStats()
    {
    // Assuming PlayerStatsSO has properties for health, speed, etc.
    if (playerStats.MaxHealth <= 0 || playerStats.Speed <= 0 || playerStats.AttackDamage <= 0)
    {
        playerStats.ResetStats(); // Call the reset method
    }

    maxHealth = playerStats.MaxHealth;
    health = playerStats.Health;
    speed = playerStats.Speed;
    attackDamage = playerStats.AttackDamage;
    money = playerStats.Money;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

        // Get the horizontal and vertical input (between -1 and 1)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a new vector for the movement direction
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);

        // Apply the movement to the player's position
        transform.position += movement * speed * Time.deltaTime;

        // If there's any horizontal input
        if (horizontalInput != 0)
        {
            // Rotate the player to face the direction of movement
            transform.rotation = Quaternion.Euler(0, horizontalInput > 0 ? 0 : 180, 0);
        }

        // If the player is moving
        if (movement.magnitude > 0.01f)
        {
            isWalking = true;
            // Play the "Walking" animation
            CharacterView.PlayAnimation("Rogue_walk_01");
        }
        else if(!isInteracting && movement.magnitude <= 0.01f)
        {
            isWalking = false;
            // If the player is not moving, stop the "Walking" animation
            CharacterView.StopAnimation("Rogue_walk_01");
            CharacterView.PlayAnimation("Rogue_idle_01");
        }

            // If the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the Attack method
            Attack();
        }

        if (isWalking) 
        {
            isInteracting = false;
        }
        else if (isInteracting)
        {
            isWalking = false;
        }
        
        // Update the health and money text
        UpdateHealthAndMoneyText();

    }


    void UpdateHealthAndMoneyText()
    {
        // Update the health text
        healthText.text = health.ToString();

        // Update the money text
        moneyText.text = money.ToString();
    }
    void Attack()
    {
        if (isWalking) return;
        isInteracting = true;
        CharacterView.PlayAnimation("Rogue_attack_03");
        attackHitbox.SetActive(true);

        // Damage enemies in the attack hitbox
        DamageEnemiesInHitbox();
    }

    void DamageEnemiesInHitbox()
    {
        // Get the position and size of the attack hitbox
        Vector2 point = attackHitbox.transform.position;
        Vector2 size = attackHitbox.GetComponent<BoxCollider2D>().size;

        // Get all colliders that overlap with the attack hitbox
        Collider2D[] colliders = Physics2D.OverlapBoxAll(point, size, 0);

        // Loop through the colliders
        foreach (Collider2D collider in colliders)
        {
            // If the collider is an enemy
            if (collider.gameObject.CompareTag("Enemy"))
            {
                // Get the enemy script
                EnemyController enemy = collider.gameObject.GetComponent<EnemyController>();

                // If the enemy script is not null
                if (enemy != null)
                {
                    // Damage the enemy
                    enemy.TakeDamage(attackDamage);
                }
            }
        }
    }   

    public void EndAttack()
    {
        isInteracting = false;
        attackHitbox.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        isInteracting = true;
        // Play the "Hurt" animation
        CharacterView.PlayAnimation("Rogue_hit_01");

        // Reduce the player's health by the damage amount
        health -= damage;

        // Start the EndInteract coroutine
        StartCoroutine(EndInteract(0.45f)); 
    }

    private IEnumerator EndInteract(float waitTime)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(waitTime);

        // Set isInteracting to false
        isInteracting = false;
    }

    public void Heal(int healAmount)
    {
        // Increase the player's health by the heal amount
        health += healAmount;

        // Clamp the health to the max health
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public void AddMoney(int moneyAmount)
    {
        // Increase the player's money by the money amount
        money += moneyAmount;
    }

    public void SaveStats()
    {
        // Save the player's stats to the PlayerStatsSO
        playerStats.SaveStats(maxHealth, health, attackDamage, speed, money);
    }

    private void OnApplicationQuit()
    {
        // Save the player's stats when the application quits
        SaveStats();
    }
}