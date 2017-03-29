using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NewBehaviourScript : MonoBehaviour
{

    private AudioClip audio_clip;
    private AudioSource audio_source;

    // Arrays of text
    private int[] karmaArr_A;
    private int[] moneyArr_A;
    private int[] karmaArr_B;
    private int[] moneyArr_B;

    private bool bool_intro_0, bool_intro_1, bool_intro_2;
    private string game_intro_0, game_intro_1, audio_intro_0, audio_intro_1;

    private string[] introArr;
    private string[] outroArr;
    private string[] textA_Arr;
    private string[] textB_Arr;
    private string[] audioIntro_Arr;
    private string[] audioOutroA;
    private string[] audioOutroB;

    private string finalDialog;

    public GameObject player;

    public Button large_Button;
    public Text large_Button_Text;
    public Button intro_Button;
    public Text intro_Button_Text;

    public Button choiceA_Text_Button;
    public Button choiceB_Text_Button;
    public Button choiceA_Button;
    public Button choiceB_Button;
    public Text choiceA_Text_Button_Text;
    public Text choiceB_Text_Button_Text;
    public Text choiceA_Button_Text;
    public Text choiceB_Button_Text;
    private int stage = 0;
    private int displacement = 7000;

    // Use this for initialization
    void Start()
    {
        audio_clip = new AudioClip();
        audio_source = GetComponent<AudioSource>();
        audio_source.ignoreListenerVolume = true;

        karmaArr_A = new int[6];
        moneyArr_A = new int[6];
        karmaArr_B = new int[6];
        moneyArr_B = new int[6];

        karmaArr_A[0] = -2;
        karmaArr_A[1] = 3;
        karmaArr_A[2] = -2;
        karmaArr_A[3] = 3;
        karmaArr_A[4] = 3;
        karmaArr_A[5] = -2;

        karmaArr_B[0] = 2;
        karmaArr_B[1] = -2;
        karmaArr_B[2] = 2;
        karmaArr_B[3] = -2;
        karmaArr_B[4] = 3;
        karmaArr_B[5] = -3;

        moneyArr_A[0] = 550000;
        moneyArr_A[1] = -600000;
        moneyArr_A[2] = 550000;
        moneyArr_A[3] = -1250000;
        moneyArr_A[4] = -300000;
        moneyArr_A[5] = -1800000;

        moneyArr_B[0] = 0;
        moneyArr_B[1] = 800000;
        moneyArr_B[2] = 0;
        moneyArr_B[3] = -750000;
        moneyArr_B[4] = -250000;
        moneyArr_B[5] = -1250000;

        introArr = new string[6];
        outroArr = new string[6];
        textA_Arr = new string[6];
        textB_Arr = new string[6];
        audioIntro_Arr = new string[6];
        audioOutroA = new string[6];
        audioOutroB = new string[6];

        // begin intro for stage 0
        //someText = new UnityEngine.UI.Text("");
        bool_intro_0 = bool_intro_1 = bool_intro_2 = true;
        game_intro_0 = "You’re in early, did you sleep here last night?";
        game_intro_1 = "You should take a look at these. They came in this morning.";
        audio_intro_0 = "001_001";
        audio_intro_1 = "001_002";

        introArr[0] = "Creating infrastructure encourages tourism but destroys natural land.";
        outroArr[0] = "Thank you, I’ve got it from here.";
        textA_Arr[0] = "We should fund new infrastructure at the national park.";
        textB_Arr[0] = "The land is sacred to the local tribes.";
        audioIntro_Arr[0] = "001_003";
        audioOutroA[0] = "001_004_p";
        audioOutroB[0] = "001_004_p";

        introArr[1] = "Here’s another one. It looks like a few energy companies want input.";
        outroArr[1] = "I’ll let them know!";
        textA_Arr[1] = "Clean energy is cost effective but expensive to install.";
        textB_Arr[1] = "Staying with fossil fuels is cheap and efficient in the short-term.";
        audioIntro_Arr[1] = "002_001";
        audioOutroA[1] = "002_002_p";
        audioOutroB[1] = "002_002_p";

        introArr[2] = "There are resources to build a hydroelectric dam, should we?";
        outroArr[2] = "Thank you, you’ve worked hard today.";
        textA_Arr[2] = "Hydroelectric power is cheap and renewable.";
        textB_Arr[2] = "We would flood large areas of land putting species at risk.";
        audioIntro_Arr[2] = "003_001";
        audioOutroA[2] = "003_002";
        audioOutroB[2] = "003_002";

        introArr[3] = "Our only prison in the city is overflowing. We need new prisons.";
        outroArr[3] = "Thank you, I’ve got it from here.";
        textA_Arr[3] = "Having a public prison keeps long-term costs lower.";
        textB_Arr[3] = "Private prisons are easier to fund, but ignores rights of inmates.";
        audioIntro_Arr[3] = "004_001";
        audioOutroA[3] = "004_002_p";
        audioOutroB[3] = "004_002_p";

        introArr[4] = "There are starving familys and the homless dont have winter clothes.";
        outroArr[4] = "I’ll let them know!";
        textA_Arr[4] = "Feeding famillies will improve the general health.";
        textB_Arr[4] = "Winter is coming, the homless will freeze to death.";
        audioIntro_Arr[4] = "005_001";
        audioOutroA[4] = "005_002_p";
        audioOutroB[4] = "005_002_p";

        introArr[5] = "We're told to aid in deporting illiegal immigrants or build a wall.";
        outroArr[5] = "Thank you, you’ve worked hard today.";
        textA_Arr[5] = "Building a wall secures our border and create jobs.";
        textB_Arr[5] = "Deporting immigrants will create jobs but spike food costs.";
        audioIntro_Arr[5] = "006_001";
        audioOutroA[5] = "006_002";
        audioOutroB[5] = "006_002";
        finalDialog = "Hey your election results are in!";


        Vector3 v = intro_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        intro_Button.GetComponent<Transform>().transform.position = v;
        //v = large_Button.GetComponent<Transform>().transform.position;
        //v.x = v.x - displacement;
        //large_Button.GetComponent<Transform>().transform.position = v;

        v = choiceA_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        choiceA_Button.GetComponent<Transform>().transform.position = v;
        v = choiceB_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        choiceB_Button.GetComponent<Transform>().transform.position = v;
        v = choiceA_Text_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        choiceA_Text_Button.GetComponent<Transform>().transform.position = v;
        v = choiceB_Text_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        choiceB_Text_Button.GetComponent<Transform>().transform.position = v;

        large_Button.GetComponent<Image>().enabled = false;
        large_Button.enabled = false;
        large_Button_Text.text = "";

        choiceA_Text_Button.GetComponent<Image>().enabled = false;
        choiceA_Text_Button_Text.text = "";
        choiceB_Text_Button.GetComponent<Image>().enabled = false;
        choiceB_Text_Button_Text.text = "";

        choiceA_Button.GetComponent<Image>().enabled = false;
        choiceA_Button_Text.text = "";
        choiceB_Button.GetComponent<Image>().enabled = false;
        choiceB_Button_Text.text = "";
        ExecuteIntro();
    }

    // Update is called once per frame
    void Update()
    {
        // 

    }

    void Awake()
    {

    }

    public void ExecuteIntro()
    {
        audio_source.Stop();
        MoveInIntroButton();
        // Disable OutroButton
        large_Button.GetComponent<UnityEngine.UI.Button>().enabled = false;
        large_Button.GetComponent<UnityEngine.UI.Image>().enabled = false;
        large_Button.GetComponent<Button>().interactable = false;
        large_Button_Text.text = "";
        if (stage >= 6)
        {
            intro_Button_Text.text = finalDialog;
        }
        else if (bool_intro_0)
        {
            intro_Button_Text.text = game_intro_0;
            bool_intro_0 = false;
            audio_clip = Resources.Load<AudioClip>("Voice_Clips/" + audio_intro_0);
            audio_source.PlayOneShot(audio_clip);
        }
        else
        {
            // Fill intro button with stage's intro text
            intro_Button_Text.text = introArr[stage];
            audio_clip = Resources.Load<AudioClip>("Voice_Clips/" + audioIntro_Arr[stage]);
            audio_source.PlayOneShot(audio_clip);
        }


        // Make intro button clickable
        Debug.Log("Intro");
    }

    public void PresentChoices()
    {
        audio_source.Stop();
        if (stage >= 6)
        {
            GoToEnd();
        }
        else if (bool_intro_1)
        {
            intro_Button_Text.text = game_intro_1;
            bool_intro_1 = false;
            audio_clip = Resources.Load<AudioClip>("Voice_Clips/" + audio_intro_1);
            audio_source.PlayOneShot(audio_clip);
        }
        else if (bool_intro_2)
        {
            intro_Button_Text.text = introArr[stage];
            bool_intro_2 = false;
            audio_clip = Resources.Load<AudioClip>("Voice_Clips/" + audioIntro_Arr[stage]);
            audio_source.PlayOneShot(audio_clip);
        }
        else
        {

            MoveAwayIntroButton();
            MoveInChoiceButtons();

            choiceA_Text_Button_Text.text = textA_Arr[stage];
            choiceB_Text_Button_Text.text = textB_Arr[stage];
            choiceA_Button_Text.text = ("This proposal will result in $" + moneyArr_A[stage].ToString());
            choiceB_Button_Text.text = ("This proposal will result in $" + moneyArr_B[stage].ToString());
            Debug.Log("PresentChoices");
        }
    }

    void PresentChoiceDetails(string str)
    {
        MoveInIntroButton();
        MoveAwayChoiceButtons();
        intro_Button_Text.text = str;
        Debug.Log("PresentChoiceDetails");
    }

    public void ExecuteOutro()
    {
        MoveAwayChoiceButtons();

        // Fill intro button with stage's outro text
        large_Button_Text.text = outroArr[stage];

        // Make outro button clickable
        large_Button.GetComponent<UnityEngine.UI.Button>().enabled = true;
        large_Button.GetComponent<UnityEngine.UI.Image>().enabled = true;
        large_Button.GetComponent<Button>().interactable = true;
        //v = large_Button.GetComponent<Transform>().transform.position;
        //v.x = v.x + displacement;
        //large_Button.GetComponent<Transform>().transform.position = v;
        if (player.GetComponent<PlayerStuff>().money <= 0)
            SceneManager.LoadScene("Bankrupt");
        else
            ++stage;
        Debug.Log("ExecuteOutro");
    }

    public void Choice_A_Chosen()
    {
        player.GetComponent<PlayerStuff>().addKarma(karmaArr_A[stage]);
        player.GetComponent<PlayerStuff>().addMoney(moneyArr_A[stage]);
        audio_clip = Resources.Load<AudioClip>("Voice_Clips/" + audioOutroA[stage]);
        audio_source.PlayOneShot(audio_clip);
        ExecuteOutro();
    }

    public void Choice_B_Chosen()
    {
        player.GetComponent<PlayerStuff>().addKarma(karmaArr_B[stage]);
        player.GetComponent<PlayerStuff>().addMoney(moneyArr_B[stage]);
        audio_clip = Resources.Load<AudioClip>("Voice_Clips/" + audioOutroB[stage]);
        audio_source.PlayOneShot(audio_clip);
        ExecuteOutro();
    }

    public void Show_Choice_A()
    {
        PresentChoiceDetails(textA_Arr[stage]);
    }

    public void Show_Choice_B()
    {
        PresentChoiceDetails(textB_Arr[stage]);
    }

    public void largeDialog()
    {
        ExecuteIntro();
    }
    public void toPresentChoices()
    {
        PresentChoices();
    }

    void MoveAwayIntroButton()
    {
        intro_Button.GetComponent<Button>().enabled = false;
        intro_Button.GetComponent<Image>().enabled = false;
        intro_Button.GetComponent<Button>().interactable = false;
        Vector3 v = intro_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        intro_Button.GetComponent<Transform>().transform.position = v;
    }
    void MoveInIntroButton()
    {
        intro_Button.GetComponent<Button>().enabled = true;
        intro_Button.GetComponent<Image>().enabled = true;
        intro_Button.GetComponent<Button>().interactable = true;
        Vector3 v = intro_Button.GetComponent<Transform>().transform.position;
        v.x = v.x + displacement;
        intro_Button.GetComponent<Transform>().transform.position = v;
    }

    void MoveAwayOutroButton()
    {
        Vector3 v;// = large_Button.GetComponent<Transform>().transform.position;
        //v.x = v.x - displacement;
        //large_Button.GetComponent<Transform>().transform.position = v;

        // Disable OutroButton
        large_Button.GetComponent<UnityEngine.UI.Button>().enabled = false;
        large_Button.GetComponent<UnityEngine.UI.Image>().enabled = false;
        large_Button.GetComponent<Button>().interactable = false;
        large_Button_Text.text = "";
    }
    void MoveInOutroButton()
    {
        Vector3 v;// = large_Button.GetComponent<Transform>().transform.position;
        //v.x = v.x - displacement;
        //large_Button.GetComponent<Transform>().transform.position = v;

        // Disable OutroButton
        large_Button.GetComponent<UnityEngine.UI.Button>().enabled = true;
        large_Button.GetComponent<UnityEngine.UI.Image>().enabled = true;
        large_Button.GetComponent<Button>().interactable = true;
        large_Button_Text.text = "";
    }

    void MoveAwayChoiceButtons()
    {
        Vector3 v = choiceA_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        choiceA_Button.GetComponent<Transform>().transform.position = v;
        v = choiceB_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        choiceB_Button.GetComponent<Transform>().transform.position = v;
        v = choiceA_Text_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        choiceA_Text_Button.GetComponent<Transform>().transform.position = v;
        v = choiceB_Text_Button.GetComponent<Transform>().transform.position;
        v.x = v.x - displacement;
        choiceB_Text_Button.GetComponent<Transform>().transform.position = v;

        // Make A and B pages clickable
        choiceA_Text_Button.GetComponent<Button>().enabled = false;
        choiceB_Text_Button.GetComponent<Button>().enabled = false;
        choiceA_Button.GetComponent<Button>().enabled = false;
        choiceB_Button.GetComponent<Button>().enabled = false;
        choiceA_Text_Button_Text.text = "";
        choiceB_Text_Button_Text.text = "";
        // Make A and B pages visible
        choiceA_Text_Button.GetComponent<Image>().enabled = false;
        choiceB_Text_Button.GetComponent<Image>().enabled = false;
        choiceA_Button.GetComponent<Image>().enabled = false;
        choiceB_Button.GetComponent<Image>().enabled = false;
        choiceA_Button_Text.text = "";
        choiceB_Button_Text.text = "";
    }
    void MoveInChoiceButtons()
    {
        Vector3 v = choiceA_Button.GetComponent<Transform>().transform.position;
        v.x = v.x + displacement;
        choiceA_Button.GetComponent<Transform>().transform.position = v;
        v = choiceB_Button.GetComponent<Transform>().transform.position;
        v.x = v.x + displacement;
        choiceB_Button.GetComponent<Transform>().transform.position = v;
        v = choiceA_Text_Button.GetComponent<Transform>().transform.position;
        v.x = v.x + displacement;
        choiceA_Text_Button.GetComponent<Transform>().transform.position = v;
        v = choiceB_Text_Button.GetComponent<Transform>().transform.position;
        v.x = v.x + displacement;
        choiceB_Text_Button.GetComponent<Transform>().transform.position = v;

        // Make A and B pages clickable
        choiceA_Button.GetComponent<Button>().enabled = true;
        choiceA_Button.GetComponent<Image>().enabled = true;
        choiceA_Button.GetComponent<Button>().interactable = true;

        choiceB_Button.GetComponent<Button>().enabled = true;
        choiceB_Button.GetComponent<Image>().enabled = true;
        choiceB_Button.GetComponent<Button>().interactable = true;

        // Make A and B pages clickable
        choiceA_Text_Button.GetComponent<Button>().enabled = true;
        choiceA_Text_Button.GetComponent<Image>().enabled = true;
        choiceA_Text_Button.GetComponent<Button>().interactable = true;

        choiceB_Text_Button.GetComponent<Button>().enabled = true;
        choiceB_Text_Button.GetComponent<Image>().enabled = true;
        choiceB_Text_Button.GetComponent<Button>().interactable = true;
    }

    void GoToEnd()
    {
        if (player.GetComponent<PlayerStuff>().karma >= 6 && player.GetComponent<PlayerStuff>().money > 1000)
            SceneManager.LoadScene("Victory");
        else
            SceneManager.LoadScene("Lose");
    }

}
