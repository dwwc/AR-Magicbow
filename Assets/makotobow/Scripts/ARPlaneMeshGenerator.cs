using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARPlaneManager))]
public class ARPlaneMeshGenerator : MonoBehaviour
{
    private ARPlaneManager arPlaneManager;

    void Start()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs eventArgs)
    {
        foreach (var plane in eventArgs.added)
        {
            GenerateMesh(plane);
        }
    }

    void GenerateMesh(ARPlane plane)
    {
        Mesh mesh = new Mesh();
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();

        // 获取 AR 平面的边界点信息
        List<Vector3> boundaryPoints = new List<Vector3>();
        Vector2[] boundary = new Vector2[plane.boundary.Length];
        plane.boundary.CopyTo(boundary);

        for (int i = 0; i < boundary.Length; i++)
        {
            boundaryPoints.Add(new Vector3(boundary[i].x, 0, boundary[i].y));
        }

        // 添加顶点
        foreach (Vector3 point in boundaryPoints)
        {
            vertices.Add(point);
        }

        // 添加三角形顶点索引
        for (int i = 1; i < boundaryPoints.Count - 1; i++)
        {
            triangles.Add(0);
            triangles.Add(i);
            triangles.Add(i + 1);
        }

        // 设置 Mesh 的其他属性
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();

        // 创建 GameObject 并设置 Mesh Filter 和 Mesh Renderer
        GameObject planeObject = new GameObject("PlaneMesh");
        MeshFilter meshFilter = planeObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        MeshRenderer meshRenderer = planeObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Standard"));

        // 将生成的 Mesh 对象烘焙到场景中
        planeObject.transform.position = plane.center;
        planeObject.transform.rotation = plane.transform.rotation;
    }
}
