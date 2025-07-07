using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public int health;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TakeDamage();
        }
    }
    
    public void TakeDamage()
    {
        health += -1;
    }

   
}
