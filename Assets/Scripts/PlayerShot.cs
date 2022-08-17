using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject bulletFactory;    

    // źâ�� ���� �� �ִ� �Ѿ��� ����
    public int poolSize = 1000;

    // ������Ʈ Ǯ �迭
    public List<GameObject> bulletObjectPool;

    
    private void Start()
    {
        // źâ�� �Ѿ��� ������ �ִ� ũ��� �����.
        bulletObjectPool = new List<GameObject>();

        // źâ�� ���� �Ѿ� ������ŭ �ݺ�
        for (int i = 0; i < poolSize; i++)
        {
            // �Ѿ� ���忡�� �Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory);

            // �Ѿ��� ������Ʈ Ǯ�� �ְ� �ʹ�.
            bulletObjectPool.Add(bullet);

            // ��Ȱ��ȭ ��Ű��
            bullet.SetActive(false);
        }

        // ����Ǵ� �÷����� �ȵ���̵��� ��� ���̽�ƽ�� Ȱ��ȭ ��Ų��.
        #if UNITY_ANDROID
            GameObject.Find("Joystick canvas XYBZ").SetActive(true);
        #elif UNITY_EDITOR || UNITY_STANDALONE
            GameObject.Find("Joystick canvas XYBZ").SetActive(false);
        #endif
    }

    void Update()
    {
        // ����Ƽ �����Ϳ� PCȯ���϶� �۵��Ѵ�.
#if UNITY_EDITOR || UNITY_STANDALONE
        // �߻� ��ư�� ������.
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        // źâ �ȿ� �ִ� �Ѿ��� �ִٸ�
        if (bulletObjectPool.Count > 0)
        {
            // ��Ȱ��ȭ �� �Ѿ��� �ϳ� �����´�.
            GameObject bullet = bulletObjectPool[0];

            // �Ѿ��� �߻��ϰ� �ʹ�.(Ȱ��ȭ��Ų��.)
            bullet.SetActive(true);

            // ������ƮǮ���� �Ѿ� ����
            bulletObjectPool.Remove(bullet);

            // �Ѿ��� ��ġ ��Ű��
            bullet.transform.position = transform.position;
        }
    }
}
