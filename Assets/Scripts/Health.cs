using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Variables")]
    [SerializeField] private int max_health = 100;
    [SerializeField] private int health = 100;
    
    void Start()
    {
        health = max_health;    
    }

    public void Damage(int damageAmount) {
        health -= damageAmount;

        if (health <= 0) {
            Die();
        }
    }

    public void Die() { 
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} died");
    }
    
}
