using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnPlane : MonoBehaviour
{
    public GameObject prefab;  // 预制件
    public GameObject planePrefab;  // 包含平面的预制件
    public int maxPrefabCount = 3;  // 最大预制件数量
    private List<GameObject> spawnedPrefabs = new List<GameObject>();  // 已生成的预制件列表
    private GameObject planeInstance; // 实例化的平面对象

    void Start()
    {
        // 实例化包含平面的预制件
        planeInstance = Instantiate(planePrefab);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && spawnedPrefabs.Count < maxPrefabCount)
        {
            Vector3 mousePosition = Input.mousePosition;
            // 将屏幕坐标转换为世界坐标
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));

            // 确保生成的位置在平面上
            if (IsPointOnPlane(spawnPosition))
            {
                GameObject newPrefab = Instantiate(prefab, spawnPosition, Quaternion.identity);
                spawnedPrefabs.Add(newPrefab);
            }
        }
    }

    // 检查生成位置是否在平面上，允许一定误差
    private bool IsPointOnPlane(Vector3 point)
    {
        Plane targetPlane = new Plane(planeInstance.transform.up, planeInstance.transform.position);
        float distance = targetPlane.GetDistanceToPoint(point);
        return Mathf.Abs(distance) < 0.1f;  // 设置一个允许的误差范围
    }
}
