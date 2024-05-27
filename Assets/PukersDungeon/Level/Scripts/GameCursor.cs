using UnityEngine.SceneManagement;
using UnityEngine;

public class GameCursor : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
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
