using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    GameObject player;
    Vector3 dir;

    // ���߰����ּ�
    public GameObject explosionFactory;

    void Start()
    {
        player = GameObject.Find("Player");
        if (player != null)
        {
            int random = Random.Range(0, 100);

            if (random < 50)
            {
                dir = player.transform.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
        }
        else
        {
            dir = Vector3.down;
        }
    }

    void Update()
    {
        // ������ ���Ѵ�.
        //Vector3 dir = Vector3.down;

        // �̵��ϴ� ���� : P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;

    }

    // ���� �ٸ� ��ü�� �浹
    private void OnCollisionEnter(Collision other)
    {
        // ���� ���� ������ �������� ǥ��
        ScoreManager.instance.Score++;

        // ���� ȿ�� ���忡�� ���� ȿ���� �ϳ� �����.
        GameObject explosion = Instantiate(explosionFactory);

        // ���� ȿ�� �߻���ġ
        explosion.transform.position = transform.position;

        // �ε��� ��ü�� �Ѿ��̶��
        if (other.gameObject.name.Contains("Bullet"))
        {
            // �ε��� ��ü�� ��Ȱ��ȭ
            other.gameObject.SetActive(false);

            PlayerShot player = GameObject.Find("Player").
                GetComponent<PlayerShot>();

            // ����Ʈ�� �Ѿ� ����
            player.bulletObjectPool.Add(other.gameObject);
        }

        // �ε��� ��ü�� �Ѿ��� �ƴ϶�� ����
        else
        {
            // �����
            Destroy(other.gameObject);
        }

        EnemyManager manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        // ����Ʈ�� �Ѿ� ����
        manager.enemyObjectPool.Add(gameObject);

        // �Ѿ˻����        
        gameObject.SetActive(false);
    }
}
