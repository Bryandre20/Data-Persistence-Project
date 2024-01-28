using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] Text PlayerNameInput;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    public void SetPlayerName()
    {
        PlayerDataHandle.Instance.playerName = PlayerNameInput.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
