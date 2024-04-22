using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
        [Header("Canvas")]
        public GameObject CanvaGame;
        public GameObject CanvaRestart;

        [Header("CanvasRestart")]
        public GameObject BlueWinTxt;
        public GameObject PurpleWinTxt;

        [Header("Other")]
        public TrackerScript trackerScript;

        public void showRestart(bool PurpleWin)
        {
            Time.timeScale = 0;

            CanvaGame.SetActive(false);
            CanvaRestart.SetActive(true);

            if (PurpleWin)
            {
                BlueWinTxt.SetActive(false);
                PurpleWinTxt.SetActive(true);
            }
            else
            {
                BlueWinTxt.SetActive(true);
                PurpleWinTxt.SetActive(false);
            }
        }

        public void RestartGame()
        {
            Time.timeScale = 1;

            CanvaGame.SetActive(true);
            CanvaRestart.SetActive(false);

            trackerScript.ResetScores();
        }
    }
