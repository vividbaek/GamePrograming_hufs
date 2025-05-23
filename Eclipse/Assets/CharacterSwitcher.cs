using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public CharacterController2D lowerCtrl;
    public CharacterController2D upperCtrl;
    public CameraFollow camFollow;    // Main Camera에 붙은 스크립트

    void Start()
    {
        // 시작 시 아래 캐릭터 조작 + 카메라 타겟도 아래 캐릭터
        lowerCtrl.canControl = true;
        upperCtrl.canControl = false;
        camFollow.target = lowerCtrl.transform;
    }

    public void ToggleCharacter()
    {
        bool wasLower = lowerCtrl.canControl;
        lowerCtrl.canControl = !wasLower;
        upperCtrl.canControl = wasLower;

        // 조작 캐릭터가 바뀌었으니 카메라도 따라갈 대상 변경
        camFollow.target = (wasLower ? upperCtrl : lowerCtrl).transform;
    }
}
