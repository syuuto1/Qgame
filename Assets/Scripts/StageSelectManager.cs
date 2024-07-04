using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public static int lastStageID; // ���O�̃V�[��ID��ۑ�����ÓI�ϐ�


    public void OnStageSelectButtonPressed(int stageID)
    {
        // �V�[���؂�ւ�
        SceneManager.LoadScene(stageID);

        // ���O�̃V�[��ID��ۑ�
        lastStageID = SceneManager.GetActiveScene().buildIndex;
    }

}
