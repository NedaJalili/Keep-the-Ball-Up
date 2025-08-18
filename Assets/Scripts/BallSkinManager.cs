using UnityEngine;

public class BallSkinManager : MonoBehaviour
{
    public Sprite[] ballSkins;
    public SpriteRenderer ballRenderer;

    void Start()
    {
        int selectedSkin = PlayerPrefs.GetInt("SelectedSkin", 0);
        ballRenderer.sprite = ballSkins[selectedSkin];
    }
}

