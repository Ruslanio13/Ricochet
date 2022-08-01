using UnityEngine;

[DisallowMultipleComponent]
public class Particles : MonoBehaviour


/**
 * Changes only Start Color in all child Particle Systems.
 * It doesn't change "Color over Lifetime" or "Color by Speed"
 * 
 * Made by: The Developer
 * YouTube Channel: https://www.youtube.com/channel/UCwO0k5dccZrTW6-GmJsiFrg
 * Website: https://thedevelopers.tech
 */
{
    #region Fields
    [Tooltip("Current \"Main\" color of all particle systems")]
    public Color currentColor;
    [Tooltip("New \"Main\" color of all particle systems")]
    public Color newColor;

    private Color currentHSV; // r -> H; g -> S; b -> V (not a really correct way to do it :D)
    private Color newHSV; // r -> H; g -> S; b -> V (not a really correct way to do it :D)

    [SerializeField] private ParticleSystem system;

    #endregion

    #region Methods
    /**
        Update colors of all child systems
    */
    public void ChangeColor(Color color)
    {
        newColor = color;
        Color.RGBToHSV(this.currentColor, out this.currentHSV.r, out this.currentHSV.g, out this.currentHSV.b);
        Color.RGBToHSV(this.newColor, out this.newHSV.r, out this.newHSV.g, out this.newHSV.b);

        var main = system.main;
        switch (main.startColor.mode)
        {
            case ParticleSystemGradientMode.Color:
                main.startColor = new ParticleSystem.MinMaxGradient(color);
                    
                break;
            default:
                break;

        }
    }


    /**
        Convert color from current color system to the new one
    */
    public Color ConvertCurrentToNew(Color color)
    {
        Color hsv = new Color();
        Color.RGBToHSV(color, out hsv.r, out hsv.g, out hsv.b);
        Color endRes = Color.HSVToRGB(
                Mathf.Clamp01(Mathf.Abs(this.newHSV.r + (this.currentHSV.r - hsv.r))),
                hsv.g,
                hsv.b
            );
        endRes.a = color.a;
        return endRes;
    }
    #endregion
}
