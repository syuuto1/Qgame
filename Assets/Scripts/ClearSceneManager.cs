using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearSceneManager : MonoBehaviour
{

    // �O�̃V�[���ɖ߂�{�^���̃C�x���g�n���h��
    public void OnPreviousStageButtonPressed()
    {
        // ���O�̃V�[���ɖ߂�
        SceneManager.LoadScene(StageSelectManager.lastStageID);
    }

    // ���̃V�[���Ɉړ�����{�^���̃C�x���g�n���h��
    public void OnNextStageButtonPressed()
    {

        // ���̃V�[��ID���v�Z
        int nextSceneIndex = (StageSelectManager.lastStageID) + 1;

        // ���̃V�[���Ɉړ�
        SceneManager.LoadScene(nextSceneIndex);
    }
}
