using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinColor : MonoBehaviour
{

    public static SkinColor instance;
    private Sprite skinColorSprite;
    private Texture2D skinColorTexture;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        skinColorSprite = Resources.Load("RacialSkinTone", typeof(Sprite)) as Sprite;
        skinColorTexture = skinColorSprite.texture;
    }

    public Color32 GetSkinColor(float SkinTone)
    {
        Color32 mycolor = skinColorTexture.GetPixel((int)((512 / 4) * SkinTone), 64);
        return mycolor;
    }
}
