using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	public GameObject informationbar; // using because cannot find Information when it is deactivated

	private bool isClicked = false;

	public static bool multicards = false;

	public static bool play = true;

	public static bool plane = true;

    public static bool explode = false;

	public Sprite spriteon;
	public Sprite spriteoff;

    private AsyncOperation async = null;
    private GameObject Bar;
    private GameObject PB;
    private GameObject percentage;
    private int onetime = 0;


    /*private IEnumerator LoadALevel(int levelName)
    {
        async = Application.LoadLevelAsync(levelName);
        yield return async;
    }*/
    /*void OnGUI()
    {
        if (async != null)
        {
            gameObject.GetComponent<Image>().fillAmount = async.progress;
        }
    }*/

    public void LoadScene(int level)
	{
        //Application.LoadLevel(level);
       // onetime = onetime + 1;
        //if(onetime == 1)
        //{
            async = Application.LoadLevelAsync(level);
        //}
        

        if(level == 0)
        {
            onetime = 0;
            //Bar.GetComponent<Button>().interactable = true;
        }
        if(level == 1)
        { onetime = 1; }
        /*Bar = GameObject.Find("ProgressRadialHollow");

        while (async.progress != 1)
        {
            if (Bar != null && async != null)
            {
                Bar.GetComponent<Image>().fillAmount = async.progress;
            }
        }*/
    }

	public void Info()
	{
		isClicked = !isClicked;


		GameObject Information = GameObject.Find("ScrollView");

		if(isClicked)
		{
			informationbar.SetActive(false);
		}
		else 
		{
			informationbar.SetActive(true);
		}
	}

	public void MultiButton()
	{
		multicards = !multicards;
	}

	public void Sound()
	{
		play = !play;
		GameObject button = GameObject.Find("Button(4)");

        

		if(play == true)
		{
            //button.GetComponent<AudioSource>().Play();
            button.GetComponent<Image>().sprite = spriteon;
		}
		else{
            //button.GetComponent<AudioSource>().Pause();
            button.GetComponent<Image> ().sprite = spriteoff;
        }

	}
	public void OnClickPlanar()
	{
		plane = !plane;
	}

    public void Explode()
    {
        explode = !explode;
    }

    void Start()
    {
        Bar = GameObject.Find("ProgressRadialHollow");
        PB = GameObject.FindGameObjectWithTag("PB");

        
        percentage = GameObject.FindGameObjectWithTag("Finish");
        if(PB != null)
        {
            //Debug.Log(percentage.GetComponent<Text>().text);
            PB.SetActive(false);
        }
        
       
    }

    void Update()
    {
        if(async != null && PB != null && Bar != null )
        {
            //Debug.Log("progress is " + async.progress);
            PB.SetActive(true);
            Bar.GetComponent<Image>().fillAmount = async.progress;
            percentage.GetComponent<Text>().text = Mathf.Round((100 * async.progress)).ToString() + " %";
            /*if (async.progress >= 0.9)
            {
                onetime = 0;
            }
            Debug.Log(async.progress);*/
            if (onetime == 0 && Bar != null)
            {
                Bar.GetComponent<Button>().interactable = true;
            }
        }
        
    }

}
