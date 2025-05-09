using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class DemoSceneEvent : MonoBehaviour
{
    public GameObject LeftSideChar;
    public GameObject RightSideChar;
    public AudioSource BGM;
    public UIOverlayEvents OverlayControl;
    public GameObject LoadBlocker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartScene();
        //StartedEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Modetn Style of handling event based on Time of the I/O handler (Device's Internal timer)
    /// </summary>
    public async void StartScene()
    {
        Debug.Log("DemoSceneEvent > StartScene adding events...");
        OverlayControl.SetNextButtonEvent(() =>
        {
            Debug.Log("DemoSceneEvent NextButton clicked");
            OverlayControl.TextDelay = 0;
            OverlayControl.NextDialogue(DialogueSequence.Scene01);
            //OverlayControl.TextDelay = 1500;//revert it back

            if (OverlayControl.ConvoIndex == 1)// when script is on the 1st sentence
            {
                LeftSideChar.transform.Find("JavierSleepy").gameObject.SetActive(true);
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelAngryTalk").gameObject.SetActive(true);
            }

            if (OverlayControl.ConvoIndex == 2)// when script is on the 2nd sentence
            {
                LeftSideChar.transform.Find("JavierSleepyTalk").gameObject.SetActive(true);
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelAngry").gameObject.SetActive(true);
            }

            if (OverlayControl.ConvoIndex == 3)// when script is on the 3rd sentence
            {
                LeftSideCharReset();
                LeftSideChar.transform.Find("JavierNeutral").gameObject.SetActive(true);
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelAngryTalk").gameObject.SetActive(true);
            }

            if (OverlayControl.ConvoIndex == 5)// when script is on the 5th sentence
            {
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelPout").gameObject.SetActive(true);
            }
            if (OverlayControl.ConvoIndex == 6)// when script is on the 6th sentence
            {
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelPoutTalk").gameObject.SetActive(true);
            }
            if (OverlayControl.ConvoIndex == 7)// when script is on the 7th sentence
            {
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelSmile").gameObject.SetActive(true);
            }
            if (OverlayControl.ConvoIndex == 8)
            {
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelNervous").gameObject.SetActive(true);
            }
            if (OverlayControl.ConvoIndex == 11)
            {
                LeftSideCharReset();
                LeftSideChar.transform.Find("JavierSeriousTalk").gameObject.SetActive(true);
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelPout").gameObject.SetActive(true);
            }
            if (OverlayControl.ConvoIndex == 12)
            {
                LeftSideCharReset();
                LeftSideChar.transform.Find("JavierSerious").gameObject.SetActive(true);
                RightSideCharReset();
                RightSideChar.transform.Find("RafaelSmile").gameObject.SetActive(true);
            }

        });

        Debug.Log("DemoSceneEvent > StartScene Start Music");
        BGM.Play();
        LoadBlocker.SetActive(true);

        StartDialogue();

        if (OverlayControl.AutoRun)
        {
            AutoScenario();
        }
        
    }

    public async void StartDialogue()
    {
        Debug.Log("DemoSceneEvent > StartDialogue Clearing variables...");
        OverlayControl.DialogueIndex = 0;//reset the dialogue from the top
        OverlayControl.ConvoIndex = 0;//reset the conversation from the top
        OverlayControl.TalkingChar.text = "";
        OverlayControl.DialogueText.text = "";
        Debug.Log("DemoSceneEvent > StartDialogue Conversation started...");
       
        //auto convo started
        await Task.Delay(2000);//wait for 2 sec
        LoadBlocker.SetActive(false);
        RightSideChar.SetActive(true);//show char
        RightSideChar.transform.Find("RafaelAngry").gameObject.SetActive(true);

        await OverlayControl.RunDialogue(DialogueSequence.Scene01);//read dialogue
    }


    /// <summary>
    /// This plays the basic scenario without basic input
    /// </summary>
    public async void AutoScenario()
    {
        Debug.Log("DemoSceneEvent > StartScene Auto Conversation continued...");
        LeftSideChar.SetActive(true);//show char
        await OverlayControl.RunDialogue(DialogueSequence.Scene01);
        await Task.Delay(1000);
        await OverlayControl.RunDialogue(DialogueSequence.Scene01);
        await Task.Delay(1000);
        await OverlayControl.RunDialogue(DialogueSequence.Scene01);
    }


    public void RightSideCharReset()
    {
        RightSideChar.transform.Find("RafaelAngry").gameObject.SetActive(false);
        RightSideChar.transform.Find("RafaelAngryTalk").gameObject.SetActive(false);
        RightSideChar.transform.Find("RafaelNervous").gameObject.SetActive(false);
        RightSideChar.transform.Find("RafaelPout").gameObject.SetActive(false);
        RightSideChar.transform.Find("RafaelPoutTalk").gameObject.SetActive(false);
        RightSideChar.transform.Find("RafaelSmile").gameObject.SetActive(false);
    }
    public void LeftSideCharReset()
    {
        LeftSideChar.transform.Find("JavierNeutral").gameObject.SetActive(false);
        LeftSideChar.transform.Find("JavierNeutralTalk").gameObject.SetActive(false);
        LeftSideChar.transform.Find("JavierSerious").gameObject.SetActive(false);
        LeftSideChar.transform.Find("JavierSeriousTalk").gameObject.SetActive(false);
        LeftSideChar.transform.Find("JavierSleepy").gameObject.SetActive(false);
        LeftSideChar.transform.Find("JavierSleepyTalk").gameObject.SetActive(false);
        LeftSideChar.transform.Find("JavierSmile").gameObject.SetActive(false);
        LeftSideChar.transform.Find("JavierSmileTalk").gameObject.SetActive(false);
    }

    /// <summary>
    /// Old style of handling event based from the frame count,read out as list/array, and return each frame 
    /// </summary>
    /// <returns></returns>
    IEnumerator StartedEvent()
    {
        yield return new WaitForSeconds(5);
        RightSideChar.SetActive(true);
    }
}
