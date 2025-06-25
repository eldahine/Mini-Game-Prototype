using UnityEngine;

public class SpawnObjectOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject spawnObject;

    private void OnDestroy()
    {
        // NOTE(Ahmed) be careful! OnDestroy is called when a scene is unloaded
        // instantating object during this process can cause memory leaks
        if (gameObject.scene.isLoaded)
        {
            var tmp = Instantiate(spawnObject);
            tmp.transform.SetParent(gameObject.transform.parent, false);
            tmp.transform.position = gameObject.transform.position;
            tmp.SetActive(true);
        }
    }
}
