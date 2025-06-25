using UnityEngine;

public class DisableObjectOnMobile : MonoBehaviour
{
    void Awake()
    {
        // TODO(Ahmed) this could cause issues, for wider
        // compatibility detect if the system uses touch input
        #if UNITY_IPHONE || UNITY_ANDROID
        #else
            gameObject.SetActive(false);
        #endif
    }
}
