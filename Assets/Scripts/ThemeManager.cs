using UnityEngine;

public class ThemeManager : MonoBehaviour
{
    public SpriteRenderer ballSpriteRenderer;
    public SpriteRenderer backgroundSpriteRenderer;

    public Sprite[] ballSkins;     
    public Sprite[] backgroundSkins;  

    private int currentThemeIndex = -1; 

    public void CheckScore(int score)
    {
        int newThemeIndex = -1;

        if (score >= 200)
            newThemeIndex = 1;
        else if (score >= 100)
            newThemeIndex = 0;

        if (newThemeIndex != currentThemeIndex && newThemeIndex != -1)
        {
            Debug.Log($"Theme index changed from {currentThemeIndex} to {newThemeIndex}");
            currentThemeIndex = newThemeIndex;
            ApplyTheme(currentThemeIndex);
        }
    }

    void ApplyTheme(int index)
    {
        Debug.Log($"ApplyTheme called with index {index}");

        if (ballSkins != null && index < ballSkins.Length)
        {
            AdjustSpriteScale(ballSpriteRenderer, ballSkins[index]);
            ballSpriteRenderer.sprite = ballSkins[index];
        }

        if (backgroundSkins != null && index < backgroundSkins.Length)
        {
            AdjustSpriteScale(backgroundSpriteRenderer, backgroundSkins[index]);
            backgroundSpriteRenderer.sprite = backgroundSkins[index];
        }
    }

    private void AdjustSpriteScale(SpriteRenderer targetRenderer, Sprite newSprite)
    {
        if (targetRenderer.sprite == null)
        {
            targetRenderer.transform.localScale = Vector3.one;
            return;
        }

        Vector2 oldSize = targetRenderer.sprite.bounds.size;
        Vector2 newSize = newSprite.bounds.size;

        if (newSize.x == 0 || newSize.y == 0)
        {
            Debug.LogWarning("New sprite has zero size! Scale not adjusted.");
            return;
        }

        float scaleX = (oldSize.x * targetRenderer.transform.localScale.x) / newSize.x;
        float scaleY = (oldSize.y * targetRenderer.transform.localScale.y) / newSize.y;
        float uniformScale = (scaleX + scaleY) / 2f;

        targetRenderer.transform.localScale = new Vector3(uniformScale, uniformScale, targetRenderer.transform.localScale.z);
    }
}
