using UnityEngine;

public class InputReader : MonoBehaviour
{
    public bool GetInputShoot()
    {
        int valueButton = 0;

        return Input.GetMouseButtonDown(valueButton);
    }

    public bool GetInputMove()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
