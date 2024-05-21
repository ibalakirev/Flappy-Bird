using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    private const string Level1 = nameof(Level1);

    public void RestartLevel()
    {
        SceneManager.LoadScene(Level1);
    }
}
