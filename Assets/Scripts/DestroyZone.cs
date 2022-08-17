using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // �����ȿ� �ٸ� ��ü�� �����ɶ�
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ��ü�� �Ѿ��̰ų� ���̶��
        if(other.gameObject.name.Contains("Bullet") ||
            other.gameObject.name.Contains("Enemy"))
        {
            // �ε��� ��ü ��Ȱ��ȭ
            other.gameObject.SetActive(false);

            // �ε��� ��ü�� �Ѿ��� ��� �Ѿ˸���Ʈ�� �ֱ�
            if (other.gameObject.name.Contains("Bullet"))
            {
                PlayerShot player = GameObject.Find("Plater").
                GetComponent<PlayerShot>();

                // ����Ʈ�� �Ѿ� ����
                player.bulletObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Enemy"))
            {
                GameObject emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();

                // ����Ʈ�� �Ѿ� ����
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }
}
