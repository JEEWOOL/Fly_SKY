using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        // ���ΰ��� ����
        Vector3 dir = Vector3.up;

        // �̵��� ���� = P = P0 + vt
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
