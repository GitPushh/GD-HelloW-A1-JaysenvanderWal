using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playbutton2 : MonoBehaviour
{
    public Button yourButton;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;

    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(1);
    }
}
