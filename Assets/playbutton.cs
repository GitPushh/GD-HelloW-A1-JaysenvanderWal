using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class playbutton : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Cursor.lockState = CursorLockMode.None;

    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(1);
    }
}
