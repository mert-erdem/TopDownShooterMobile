using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void GameOver()
    {
        StartCoroutine(LoadEnd());
    }

    IEnumerator LoadEnd()
    {
        CanvasController canvasController = GameObject.FindGameObjectWithTag("ui").GetComponent<CanvasController>();
        canvasController.TimeStop();

        PlayerPrefs.SetString("TIME", canvasController.timeText.text);

        //get and save the score;
        /*
        string time = canvasController.timeText.text;
        time=time.Trim(':');
        */
        if((int)canvasController.time>PlayerPrefs.GetInt("SCORE", 0))
        {
            PlayerPrefs.SetInt("SCORE", (int)canvasController.time);
            PlayerPrefs.SetString("SCORETEXT", canvasController.timeText.text);
        }
        
        
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("EndScene");
    }
}
