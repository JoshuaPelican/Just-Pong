using UnityEngine;
using UnityEngine.UI;

public class PlayerColorizer : MonoBehaviour
{
    public Player player;

    new SpriteRenderer renderer;
    Image image;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();

        if (player)
            player.OnColorChange.AddListener(UpdateColor);

        UpdateColor();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
        UpdateColor();
    }

    void UpdateColor()
    {
        Color pColor = player ? player.Color : Color.white;
        if (renderer) renderer.color = new Color(pColor.r, pColor.g, pColor.b, renderer.color.a);
        if (image) image.color = new Color(pColor.r, pColor.g, pColor.b, image.color.a);
    }
}
