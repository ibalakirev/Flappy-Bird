using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    public override void Close()
    {
        CanvasGame.gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGame.gameObject.SetActive(true);
    }

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
