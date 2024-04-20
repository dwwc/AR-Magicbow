using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARParticleEffect : MonoBehaviour
{
    public GameObject particleEffectPrefab;
    private ARRaycastManager arRaycastManager;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            SpawnParticleEffect(touchPosition);
        }

        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键点击事件
        {
            Vector2 mousePosition = Input.mousePosition;
            SpawnParticleEffect(mousePosition);
        }
    }

    void SpawnParticleEffect(Vector2 position)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(position, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            GameObject newEffect = Instantiate(particleEffectPrefab, hitPose.position, hitPose.rotation);
            newEffect.GetComponent<ParticleSystem>().Stop(); // 停止播放粒子系统
            // 如果粒子系统需要手动启动，请在这里添加适当的代码
        }
    }
}
