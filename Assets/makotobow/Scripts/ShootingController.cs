using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject projectile; // 要抛出的游戏对象
    public GameObject lookAtTarget; // 作为抛射物朝向的目标游戏对象
    public float initialSpeed = 10f; // 抛出物体的初始速度
    public Camera mainCamera; // 对主摄像机的引用

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 检测鼠标点击或触屏
        {
            ThrowProjectile(Input.mousePosition); // 抛出抛射物
        }
    }

    void ThrowProjectile(Vector3 position)
    {
        Vector3 throwDirection = mainCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, mainCamera.nearClipPlane)) - mainCamera.transform.position; // 计算抛出方向
        GameObject thrownObject = Instantiate(projectile, mainCamera.transform.position, Quaternion.identity); // 创建抛出物体
        if (lookAtTarget != null)
        {
            thrownObject.transform.LookAt(lookAtTarget.transform.position); // 使物体朝向指定的目标位置
        }
        thrownObject.GetComponent<Rigidbody>().velocity = throwDirection.normalized * initialSpeed; // 设置初始速度（需要刚体组件）
    }
}
