using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BathroomBrushTaskController : MonoBehaviour
{

	public Texture2D texture;
	public Countdown countdown;
	public ProgressBar progressBar;
	public int audioID;
	public float audioLength;
	private float audioTimer = 0;
	private SpriteMask mask;
	private Color[] colors;
	private int maskWidth;
	private int maskHeight;
	private int acc = 0;
	private int goal = 0;
	private bool isMoving = false;
	private bool isValid = false;
	private float timer = 0;

	void Start() 
	{
		mask = GetComponent<SpriteMask>();
		Texture2D textureClone = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
		Graphics.CopyTexture(texture, textureClone);
		mask.sprite = Sprite.Create(textureClone, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
		colors = mask.sprite.texture.GetPixels();
		maskWidth = mask.sprite.texture.width;
		maskHeight = mask.sprite.texture.height;
		for (int i=0;i<colors.Length;i++) {
			if (colors[i].a > 0.5f) {
				goal++;
			}
		}
		audioTimer = audioLength + 1;
	}

	void Update() {
		if (isMoving) {
			timer += Time.deltaTime;
			if (timer > 0.1f) {
				isMoving = false;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().pauseClip(audioID);
				audioTimer = audioLength + 1;
			}
		}
		progressBar.updateBar(acc / (goal / 2f));
		if (acc >= goal / 2f) {
			countdown.addCount();
			Destroy(this);
		}
		audioTimer += Time.deltaTime;
	}
	
	private void DrawCircleOnMask(int cx, int cy, int r) {
		if (cx < 0 || cx >= maskWidth || cy < 0 || cy >= maskHeight) {
			return;
		}
		for (int x = 0; x <= r; x++) {
			int d = (int)Mathf.Ceil(Mathf.Sqrt(r * r - x * x));
			for (int y = 0; y <= d; y++) {
				DrawPixelOnMask(cx + x, cy + y);
				DrawPixelOnMask(cx + x, cy - y);
				DrawPixelOnMask(cx - x, cy + y);
				DrawPixelOnMask(cx - x, cy - y);
			}
		}
		mask.sprite.texture.SetPixels(colors);
		mask.sprite.texture.Apply(false);
	}

	private void DrawPixelOnMask(int x, int y) {
		if (x < 0 || x >= maskWidth || y < 0 || y >= maskHeight) {
			return;
		}
		if (colors[x + maskWidth * y].a > 0.1f) {
			acc++;
		}
		colors[x + maskWidth * y] = new Color(1, 1, 1, 0);
	}

	void OnMouseDrag() {
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}
		if (isValid) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			int x = (int)((mousePosition - mask.transform.position).x * mask.sprite.pixelsPerUnit / transform.localScale.x + maskWidth / 2f);
			int y = (int)((mousePosition - mask.transform.position).y * mask.sprite.pixelsPerUnit / transform.localScale.y + maskHeight / 2f);
			DrawCircleOnMask(x, y, 50);
			isMoving = true;
			timer = 0;
			if (audioTimer > audioLength) {
				audioTimer = 0;
				GameObject.Find("AudioManager").GetComponent<AudioManager>().playClip(audioID);
			}
		}
	}

	void OnMouseEnter() {
		isValid = true;
	}

	void OnMouseExit() {
		isValid = false;
	}

}