using UnityEngine;
using UnityEngine.UI;

public class ChangeIconClick : MonoBehaviour
{
    private int iconNumber = 0;
    private Button iconChangeButton;

    public Texture2D[] markerTextures;
    public Texture2D currentTexture;

    private void Start()
    {
        currentTexture = markerTextures[iconNumber];
        iconChangeButton = GetComponent<Button>();
    }

    public void SetIconNumber()
    {
        if (iconNumber >= markerTextures.Length - 1)
        {
            iconNumber = 0;
        }

        else
        {
            iconNumber++;
        }

        currentTexture = markerTextures[iconNumber];
        iconChangeButton.image.sprite = Sprite.Create(currentTexture, new Rect(0f, 0f, currentTexture.width, currentTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        Debug.Log(currentTexture.name);

    }

}
