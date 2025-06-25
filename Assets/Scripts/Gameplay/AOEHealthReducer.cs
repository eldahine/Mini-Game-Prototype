using System.Collections;
using UnityEngine;

public class AOEHealthReducer : MonoBehaviour
{
    [SerializeField] float destroySelfAfter = 1.0f;
    [SerializeField] int damageAmount = 500;


    void OnEnable()
    {
        StartCoroutine(DestroySelfAfterDelay());
    }

    private IEnumerator DestroySelfAfterDelay()
    {
        yield return new WaitForSeconds(destroySelfAfter);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Debug.Log($"AOE Damage to: {collision.gameObject.name}");

            if (collision.transform.TryGetComponent<Health>(out Health health))
            {
                health.Damage(damageAmount);
            }
        }
    }
}
