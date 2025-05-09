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

            if(OverlayControl.ConvoIndex == 2)// when script is on the 2nd sentence
            {
                LeftSideChar.SetActive(true);//show char
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
