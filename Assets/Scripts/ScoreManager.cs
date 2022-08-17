using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // �������� UI
    public Text currentScoreUI;

    // ��������
    private int currentScore;

    // �ְ����� UI
    public Text bestScoreUI;

    // �ְ�����
    private int bestScore;

    // �̱��� ��ü
    public static ScoreManager instance = null;

    public int Score
    {
        get
        {
            return currentScore;
        }
        set
        {
            currentScore = value;

            // ȭ�鿡 ���� ���� ǥ���ϱ�
            currentScoreUI.text = "�������� : " + currentScore;

            // ���� ���������� �ִ������� �ʰ� �ߴٸ�
            if (currentScore > bestScore)
            {
                // �ְ����� ����
                bestScore = currentScore;

                // �ְ����� UI ǥ��
                bestScoreUI.text = "�ְ����� : " + bestScore;

                // ��ǥ���� ����
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }        
    }

    private void Start()
    {
        // �ְ����� �ҷ�����
        bestScore = PlayerPrefs.GetInt("Best Score", 0);

        // �ְ����� ȭ�鿡 ǥ���ϱ�
        bestScoreUI.text = "�ְ����� : " + bestScore;
    }

    //public void SetScore(int value)
    //{
    //    // 3.ScoreManager Ŭ������ �Ӽ��� ���� �Ҵ� �Ѵ�.
    //    currentScore = value;
    //    // 4.ȭ�鿡 ���� ���� ǥ���ϱ�
    //    currentScoreUI.text = "�������� : " + currentScore;

    //    //��ǥ: �ְ� ������ ǥ���ϰ� �ʹ�.
    //    //1.���� ������ �ְ� ���� ���� ũ�ϱ�
    //    //  -> ���� ���� ������ �ְ� ������ �ʰ� �Ͽ��ٸ顱
    //    if (currentScore > bestScore)
    //    {
    //        //2.�ְ� ������ ���� ��Ų��.
    //        bestScore = currentScore;
    //        //3.�ְ� ���� UI �� ǥ��
    //        bestScoreUI.text = "�ְ����� : " + bestScore;
    //        // ��ǥ : �ְ������� �����ϰ�ʹ�.
    //        PlayerPrefs.SetInt("Best Score", bestScore);
    //    }
    //}

    //// currentScore �� ��������
    //public int GetScore()
    //{
    //    return currentScore;
    //}
}
