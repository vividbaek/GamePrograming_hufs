using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public CharacterController2D lowerCtrl;
    public CharacterController2D upperCtrl;
    public CameraFollow camFollow;    // Main Camera�� ���� ��ũ��Ʈ

    void Start()
    {
        // ���� �� �Ʒ� ĳ���� ���� + ī�޶� Ÿ�ٵ� �Ʒ� ĳ����
        lowerCtrl.canControl = true;
        upperCtrl.canControl = false;
        camFollow.target = lowerCtrl.transform;
    }

    public void ToggleCharacter()
    {
        bool wasLower = lowerCtrl.canControl;
        lowerCtrl.canControl = !wasLower;
        upperCtrl.canControl = wasLower;

        // ���� ĳ���Ͱ� �ٲ������ ī�޶� ���� ��� ����
        camFollow.target = (wasLower ? upperCtrl : lowerCtrl).transform;
    }
}
