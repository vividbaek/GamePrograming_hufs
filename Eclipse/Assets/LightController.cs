using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class LightController : MonoBehaviour
{
    public Light2D pointLight;          // 라이트 연결
    public GameObject targetButton;     // 충돌할 버튼 오브젝트 직접 연결
    private void Start()
    {
        if (pointLight != null)
            pointLight.enabled = false; // 시작 시 꺼져 있음
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == targetButton)
        {
            if (pointLight != null)
                pointLight.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == targetButton)
        {
            if (pointLight != null)
                pointLight.enabled = false;
        }
    }
}
