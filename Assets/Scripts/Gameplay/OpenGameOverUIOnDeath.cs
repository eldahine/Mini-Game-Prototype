using UnityEngine;

public class OpenGameOverUIOnDeath : MonoBehaviour
{
    private void OnDisable()
    {
        if (gameObject.scene.isLoaded)
        {
            GameOverMenuEvents.SharedInstance.ShowUI();
        }
    }
}
