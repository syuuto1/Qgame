using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearSceneManager : MonoBehaviour
{

    // 前のシーンに戻るボタンのイベントハンドラ
    public void OnPreviousStageButtonPressed()
    {
        // 直前のシーンに戻る
        SceneManager.LoadScene(StageSelectManager.lastStageID);
    }

    // 次のシーンに移動するボタンのイベントハンドラ
    public void OnNextStageButtonPressed()
    {

        // 次のシーンIDを計算
        int nextSceneIndex = (StageSelectManager.lastStageID) + 1;

        // 次のシーンに移動
        SceneManager.LoadScene(nextSceneIndex);
    }
}
