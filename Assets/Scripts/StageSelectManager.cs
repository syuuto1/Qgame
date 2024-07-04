using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    public static int lastStageID; // 直前のシーンIDを保存する静的変数


    public void OnStageSelectButtonPressed(int stageID)
    {
        // シーン切り替え
        SceneManager.LoadScene(stageID);

        // 直前のシーンIDを保存
        lastStageID = SceneManager.GetActiveScene().buildIndex;
    }

}
