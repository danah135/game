using UnityEngine;
using UnityEngine. UI;
public class PlayerHealth: MonoBehaviour
{
    public Slider healthbar;
    public int health=100;
    public void TakeDamage(int damage)
    {
        Debug.Log("Player takes "+damage+" damage! \n health is at: "+health);
        health-=damage;
        healthbar.value=health;
       if(health<=0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Player has died!");
    Destroy(gameObject);
    }
}
