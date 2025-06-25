using System.Collections.Generic;
using UnityEngine;

public class DamageTextPool : MonoBehaviour
{
    [SerializeField] private List<Sprite> digitSprites;
    
    public static DamageTextPool SharedInstance;
    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            tmp.transform.SetParent(gameObject.transform, false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public void Spawn(int damageAmount, Vector2 position)
    {
        GameObject digit = GetPooledObject();
        if (digit != null)
        {
            digit.transform.position = position;
            digit.GetComponent<SpriteRenderer>().sprite = digitSprites[damageAmount];
            digit.SetActive(true);
        }
    }

}
