using UnityEngine;
using System.Collections; // required for Coroutines

/// <summary>
/// Fades the screen from black after a new scene is loaded.
/// </summary>
public class movimiento : MonoBehaviour
{
	/// <summary>
	/// How long it takes to fade.
	/// </summary>
	public float fadeTime = 5.0f;
	public float time = 35.0f;
	public float timeFinal = 40.0f;
	public float timeDoor = 15.0f;
	public float timeArrow = 5.0f;
	public Animation door;
	public Animation arrow;
	public GameObject arrow1;
	/// <summary>
	/// The initial screen color.
	/// </summary>
	public Color fadeColor = new Color(0.01f, 0.01f, 0.01f, 1.0f);
	
	private Material fadeMaterial = null;
	private bool isFading = false;
	/// <summary>
	/// Initialize.
	/// </summary>
	void Awake()
	{
		// create the fade material
		fadeMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
	}

	void Start(){

		//arrow1.SetActive (false);
		door.Stop ();
		arrow.Stop();

	}
	void Update(){
		if (Input.GetKey(KeyCode.Z)) {
			
			Debug.Log("activo");
			time -= Time.deltaTime;
			timeFinal -= Time.deltaTime;
			timeDoor -= Time.deltaTime;
			timeArrow -= Time.deltaTime;
			if (time <= 0) {
				
				time = 0;
				StartCoroutine(FadeIn());
			}
			if (timeFinal == 0) {
				
				timeFinal =0;
				Time.timeScale = 0;
				Debug.Log("Teriminado");
				StartCoroutine(FadeOut());
			}
			if (timeDoor <= 0) {
				Time.timeScale =1;
				timeDoor = 0;
				arrow1.SetActive (true);
				arrow.Play();
				door.Play();
				Debug.Log("15");
				if(timeFinal <= 20){
					timeArrow=0;
					Time.timeScale =1;
				//	arrow1.SetActive(false);	
				}
				
			}	
		}	

		Reiniciar ();
	}

	void Inicio(){

	}
	/// <summary>
	/// Starts the fade in
	/// </summary>

	void Reiniciar(){

		if (Input.GetKey (KeyCode.Space)) {
		
			Application.LoadLevel("Helicoptero");
		}



	}

	void OnEnable()
	{
		StartCoroutine(FadeOut());
	}
	
	/// <summary>
	/// Starts a fade in when a new level is loaded
	/// </summary>
	void OnLevelWasLoaded(int level)
	{
		StartCoroutine(FadeIn());
	}
	
	/// <summary>
	/// Cleans up the fade material
	/// </summary>
	void OnDestroy()
	{
		if (fadeMaterial != null)
		{
			Destroy(fadeMaterial);
		}
	}
	
	/// <summary>
	/// Fades alpha from 1.0 to 0.0
	/// </summary>
	IEnumerator FadeIn()
	{
		float elapsedTime = 0.0f;
		fadeMaterial.color = fadeColor;
		Color color = fadeColor;
		isFading = true;
		while (elapsedTime < fadeTime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			color.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
			fadeMaterial.color = color;
		}
		isFading = false;
	}

	IEnumerator FadeOut()
	{
		float elapsedTime = 1.0f;
		fadeMaterial.color = fadeColor;
		Color color = fadeColor;
		isFading = true;
		while (elapsedTime < fadeTime)
		{
			yield return new WaitForEndOfFrame();
			elapsedTime += Time.deltaTime;
			color.a = 1.0f - Mathf.Clamp01(elapsedTime / fadeTime);
			fadeMaterial.color = color;
		}
		isFading = false;
	}
	/// <summary>
	/// Renders the fade overlay when attached to a camera object
	/// </summary>
	void OnPostRender()
	{
		if (isFading)
		{
			fadeMaterial.SetPass(0);
			GL.PushMatrix();
			GL.LoadOrtho();
			GL.Color(fadeMaterial.color);
			GL.Begin(GL.QUADS);
			GL.Vertex3(0f, 0f, -12f);
			GL.Vertex3(0f, 1f, -12f);
			GL.Vertex3(1f, 1f, -12f);
			GL.Vertex3(1f, 0f, -12f);
			GL.End();
			GL.PopMatrix();
		}
	}
}