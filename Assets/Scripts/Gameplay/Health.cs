using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Variables")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int health = 100;
    [SerializeField] private bool disableInsteadDestroyOnDeath = false;

    void Start()
    {
        health = maxHealth;
    }

    public void DamageFull() {
        Damage(health);
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            while (damageAmount > 9)
            {
                var amount = Random.Range(3, 8);
                damageAmount -= amount;

                var textPosition = new Vector2(transform.position.x, transform.position.y);
                textPosition += transform.localScale * (Random.insideUnitCircle * 0.5f);

                DamageTextPool.SharedInstance.Spawn(amount, textPosition);
            }

            if (damageAmount > 0)
            {
                var textPosition = new Vector2(transform.position.x, transform.position.y);
                textPosition += transform.localScale * (Random.insideUnitCircle * 0.5f);

                DamageTextPool.SharedInstance.Spawn(damageAmount, textPosition);
            }
        }
    }

    public void Die() {
        if (disableInsteadDestroyOnDeath) 
        {
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log($"{gameObject.name} died");
    }

    public void Revive()
    {
       health = maxHealth;
       gameObject.SetActive(true);
    }

}
