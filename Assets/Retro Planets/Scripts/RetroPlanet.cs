using UnityEngine;
using System.Collections;

public class RetroPlanet : PixelAsset {

	public int radius = 32;
    public Color highlightColor = Color.black;
	public Color shadeColor = Color.black;
	[Range(0f, 2.01f)]
	public float shadeWidth = 0.7f;

	protected override void SetupTexture (){
        //randomise radius
        radius = (int)Random.Range(32, 128);
		texDimensions = (radius*2)+10;
		base.SetupTexture ();
	}

	public override void Draw (){
		int centerX = texture.width/2;
		int centerY = texture.height/2;

        //get random shade width
        shadeWidth = Random.Range(0.1f, 2f);

		PixelTool.DrawFilledCircle(texture, shadeColor, new Vector2(centerX, centerY), radius);

        //set up random color
        Color32 color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        highlightColor = color;
        //print(color.r + " " + color.g + " " + color.b);
        GetHighlight light = FindObjectOfType(typeof(GetHighlight)) as GetHighlight;
        light.m_lightColor = color;
        light.ChangeColor();

        for (int y = -radius; y <= radius; y++) {
			int x1 = (int)Mathf.Sqrt(radius * radius - y * y);
			for(int x = -x1; x <= x1; x++) {
				float n = Random.Range(0, x1) * (2.01f-shadeWidth);
				if (n > x1 + x) {
					texture.SetPixel(x+centerX, y+centerY, highlightColor);
				}
				
			}
		}
	}

	public void PlaySecondAnimation()
	{
		GetComponent<Animator> ().SetBool ("Fly", false);
	}
}
