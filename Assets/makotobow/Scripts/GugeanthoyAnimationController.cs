using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GugeanthoyAnimationController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("IsWalkingToDown");
        Invoke("DestroyGameObject", 3f); // 延迟三秒后调用销毁方法
    }

    void DestroyGameObject()
    {
        Destroy(gameObject); // 销毁触发器所在的游戏对象
    }
}
