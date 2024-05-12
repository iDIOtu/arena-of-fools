using UnityEngine.SceneManagement;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    private string _menuSceneName = "Menu";

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != _menuSceneName)
        {
            Cursorlock();
        }
        else
        {
            CursorUnlock();
        }
    }

    public void Cursorlock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
