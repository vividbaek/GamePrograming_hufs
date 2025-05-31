using UnityEngine;
// ��Light 2D (Experimental)�� ������Ʈ�� ���� �ִٸ� �� ���ӽ����̽��� �߰��ϼ���.
using UnityEngine.Experimental.Rendering.Universal;

public class LightToggleController : MonoBehaviour
{
    [Header("�Ѱ�/���� �� Point Light 2D��")]
    public Light2D[] lightsToToggle;

    public void TurnOnLights()
    {
        foreach (Light2D l in lightsToToggle)
            if (l != null) l.enabled = true;
    }

    public void TurnOffLights()
    {
        foreach (Light2D l in lightsToToggle)
            if (l != null) l.enabled = false;
    }

    public void ToggleLights()
    {
        foreach (Light2D l in lightsToToggle)
            if (l != null) l.enabled = !l.enabled;
    }
}
