using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
public class LightController : MonoBehaviour
{
    public Light2D pointLight;          // ����Ʈ ����
    public GameObject targetButton;     // �浹�� ��ư ������Ʈ ���� ����
    private void Start()
    {
        if (pointLight != null)
            pointLight.enabled = false; // ���� �� ���� ����
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
