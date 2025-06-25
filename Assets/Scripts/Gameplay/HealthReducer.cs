using System.Collections;
using UnityEngine;

public class HealthReducer : MonoBehaviour
{
    Health health;
    [SerializeField] float destroyAfter = 3.0f;

    private void Awake()
    {
        health = GetComponent<Health>();
    }
    void OnEnable()
    {
        StartCoroutine(ApplyDamage());
    }

    private IEnumerator ApplyDamage()
    {
        yield return new WaitForSeconds(destroyAfter);

        health.DamageFull();
    }
}
