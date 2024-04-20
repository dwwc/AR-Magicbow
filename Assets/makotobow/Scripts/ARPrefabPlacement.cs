using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPrefabPlacement : MonoBehaviour
{
    public GameObject prefabToGenerate;
    public ARPlaneManager arPlaneManager;
    private int generatedPrefabCount = 0;
    private bool canGeneratePrefab = true;

    void Start()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
        StartCoroutine(GeneratePrefabPeriodically());
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (var plane in eventArgs.added)
        {
            if (generatedPrefabCount >= 3) return;

            Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * 5f; // 修改生成位置为摄像机远处
            Instantiate(prefabToGenerate, spawnPosition, Quaternion.identity); // 使用默认旋转
            generatedPrefabCount++;
        }
    }

    IEnumerator GeneratePrefabPeriodically()
    {
        while (canGeneratePrefab)
        {
            yield return new WaitForSeconds(8f);
            if (generatedPrefabCount < 3)
            {
                List<ARPlane> arPlanes = new List<ARPlane>();
                foreach (var plane in arPlaneManager.trackables)
                {
                    arPlanes.Add(plane);
                }
                if (arPlanes.Count > 0)
                {
                    ARPlane targetPlane = arPlanes[Random.Range(0, arPlanes.Count)];
                    Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * 5f; // 修改生成位置为摄像机远处
                    Instantiate(prefabToGenerate, spawnPosition, Quaternion.identity); // 使用默认旋转
                    generatedPrefabCount++;
                }
            }
        }
    }
}



