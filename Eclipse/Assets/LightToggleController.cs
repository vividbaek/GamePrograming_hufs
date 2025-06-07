using UnityEngine;
// “Light 2D (Experimental)” 컴포넌트를 쓰고 있다면 이 네임스페이스를 추가하세요.
using UnityEngine.Experimental.Rendering.Universal;

public class LightToggleController : MonoBehaviour
{
    [Header("켜고/끄고 할 Point Light 2D들")]
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
