using System.Collections;
using UnityEngine;

public class RespawnPrefab : MonoBehaviour
{
    public GameObject prefabToRespawn;
    private Vector3 originalPosition;
    private bool isDestroyed = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (isDestroyed)
        {
            StartCoroutine(RespawnAfterDelay());
            isDestroyed = false;
        }
    }

    void OnDestroy()
    {
        isDestroyed = true;
    }

    IEnumerator RespawnAfterDelay()
    {
        float timer = 0f;
        float respawnDelay = 8f;

        while (timer < respawnDelay)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        if (prefabToRespawn != null)
        {
            Instantiate(prefabToRespawn, originalPosition, Quaternion.identity);
        }
    }
}
