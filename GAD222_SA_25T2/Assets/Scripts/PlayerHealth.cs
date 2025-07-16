using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHealthHealth = 100;
    public Slider Playerhealthbar;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        PlayerHealthHealth += -33;
    }

    private void Update()
    {
        Debug.Log(PlayerHealthHealth);

        Playerhealthbar.value = PlayerHealthHealth;
    }
}
