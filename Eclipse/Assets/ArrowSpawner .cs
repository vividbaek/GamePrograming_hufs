using System.Collections;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [Header("����߸� Arrow ������")]
    public GameObject arrowPrefab;

    [Header("���� X ����")]
    public float spawnXMin = -8f;
    public float spawnXMax = 8f;

    [Header("���� Y ��ġ")]
    public float spawnY = 6f;

    [Header("���� ���� (��), ���� ����")]
    public float intervalMin = 0.5f;
    public float intervalMax = 1.5f;

    [Header("�� ĳ���� ��Ʈ�ѷ� (������ ���� ����)")]
    public CharacterController2D upperCtrl;

    void Start()
    {
        if (arrowPrefab == null || upperCtrl == null)
            Debug.LogError("ArrowSpawner: arrowPrefab �� upperCtrl �� �����Ϳ��� �ݵ�� �Ҵ��ϼ���!");

        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            // 1) �� ĳ���Ͱ� ���� ������ ���� ����
            if (upperCtrl.canControl)
            {
                // 2) ���� ���
                float wait = Random.Range(intervalMin, intervalMax);
                yield return new WaitForSeconds(wait);

                // 3) ���� X, ���� Y ��ġ���� Instantiate
                float x = Random.Range(spawnXMin, spawnXMax);
                Vector3 pos = new Vector3(x, spawnY, 0f);
                Instantiate(arrowPrefab, pos, Quaternion.identity);
            }
            else
            {
                // �� ĳ���Ͱ� ��Ȱ��ȭ ���¸� �� ������ ��Ȯ��
                yield return null;
            }
        }
    }
}
