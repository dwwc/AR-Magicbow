using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Bubian2 : MonoBehaviour
{
    public Transform cameraTransform;
    private Transform modelTransform;
    private Vector3 initialOffset;

    private void Start()
    {
        modelTransform = transform;
        cameraTransform = Camera.main.transform;

        // 计算模型相对于相机的初始偏移
        initialOffset = modelTransform.position - cameraTransform.position;
    }

    private void Update()
    {
        // 更新模型的位置,使其保持在相机前的相对位置
        modelTransform.position = cameraTransform.position + initialOffset;
    }
}

