using System.Collections;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float cooldown = 0.5f;

    private void OnEnable()
    {
        StartCoroutine(killObject());
    }

    private IEnumerator killObject()
    {
        yield return new WaitForSeconds(cooldown);
        this.gameObject.SetActive(false);
    }
}
