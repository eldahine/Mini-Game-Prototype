using System.Collections;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [Tooltip("Usually set to the total time an object is alive")]
    [SerializeField] private float flashTimeLength = 3.0f;
    [SerializeField] private float minBlinkTimeLength = 0.2f;
    private float blinkTimeLength;
    private float flashTime;
    private Material originalMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        flashTime = flashTimeLength;
        originalMaterial = GetComponent<SpriteRenderer>().material;
        StartCoroutine(Flash());
    }

    private void Update()
    {
        flashTime = Mathf.Max(flashTime - Time.deltaTime, 0);
        blinkTimeLength = Mathf.Max(flashTime * 0.3f, minBlinkTimeLength);
    }

    private IEnumerator Flash()
    {
        if (flashTime > 0) { 
            yield return new WaitForSeconds(blinkTimeLength);

            GetComponent<SpriteRenderer>().material = flashMaterial;

            StartCoroutine(UnFlash());
        }
    }

    private IEnumerator UnFlash()
    {
        if (flashTime > 0)
        {
            yield return new WaitForSeconds(blinkTimeLength);

            GetComponent<SpriteRenderer>().material = originalMaterial;

            StartCoroutine(Flash());
        }
    }

}
