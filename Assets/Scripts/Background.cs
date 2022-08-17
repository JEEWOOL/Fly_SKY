using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // ��� ���͸���
    public Material bgMaterial;

    // ��ũ�� �ӵ�
    public float scrollSpeed = 0.2f;

    // ��� �ִ� ���� �ݺ��Ѵ�.
    private void Update()
    {
        // ����
        Vector2 direction = Vector2.up;

        // ��ũ���Ѵ�. P = P0 + vt
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
