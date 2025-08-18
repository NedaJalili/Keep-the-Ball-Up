using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Sprite[] ballSkins;

    public void SelectSkin(int skinIndex)
    {
        PlayerPrefs.SetInt("SelectedSkin", skinIndex);
        PlayerPrefs.Save();
    }
}


