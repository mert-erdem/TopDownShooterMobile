using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI time;
    
    void Start()
    {
        time.text = PlayerPrefs.GetString("TIME");

        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("MainMenu");
    }
}
