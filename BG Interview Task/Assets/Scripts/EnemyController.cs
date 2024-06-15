using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float attackRange = 1.0f;
    [SerializeField] private int damage = 10;
    [SerializeField] private int moneyDrop = 10; // The amount of money the enemy drops when it dies

    private Transform player;
    private bool isAttacking = false;

    private CharacterView characterView;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerController = player.GetComponent<PlayerController>();
        characterView = GetComponent<CharacterView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        if (health <= 0)
        {
            StartCoroutine(Die());
        }
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!isAttacking && distanceToPlayer <= attackRange && health > 0)
        {
            StartCoroutine(Attack());
        }
        else if (distanceToPlayer > attackRange && !isAttacking && health > 0)
        {
            MoveTowardsPlayer();
        }

    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Rotate the enemy y axis to face the player
        transform.rotation = Quaternion.Euler(0, direction.x > 0 ? 0 : 180, 0);

        // If the player is moving
        if (direction.magnitude > 0.01f)
        {
            // Play the "Walking" animation
            characterView.PlayAnimation("Rogue_walk_01");
        }
        else if(!isAttacking)
        {
            // If the player is not moving, stop the "Walking" animation
            characterView.StopAnimation("Rogue_walk_01");
            characterView.PlayAnimation("Rogue_idle_01");
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;

        characterView.PlayAnimation("Rogue_attack_01");

        if (player != null)
        {
            // Apply damage to player here
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
        }

        yield return new WaitForSeconds(1.6f); // Wait for 1 second to simulate attack duration

        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

    }

    IEnumerator Die()
    {
        isAttacking = true;
        // Play death animation
        characterView.PlayAnimation("Rogue_death_01");
        yield return new WaitForSeconds(1.5f); // Wait for 1 second to simulate death animation duration
        playerController.AddMoney(moneyDrop);
        Destroy(gameObject);
    }
}