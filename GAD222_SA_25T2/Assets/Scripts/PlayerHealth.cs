using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHealthHealth = 100;
    public Slider Playerhealthbar;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        PlayerHealthHealth -= 33;

        if (PlayerHealthHealth <= 0)
        {
            PlayerHealthHealth = 0;
            Respawn();
        }
    }

    private void Respawn()
    {
        PlayerHealthHealth = 100;
        transform.position = spawnPoint;
        Debug.Log("Player respawned!");
    }

    private void Update()
    {
        Debug.Log(PlayerHealthHealth);
        Playerhealthbar.value = PlayerHealthHealth;
    }
}
