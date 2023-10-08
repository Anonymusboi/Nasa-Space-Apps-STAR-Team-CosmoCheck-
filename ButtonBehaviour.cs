using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] string SceneName;
    public Animator ButtonAnimator;
    public PilotScript pilot;
    public int StateID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeVariable()
    {
        pilot.ChangeState(StateID);
    }
    public void StartExitAnim()
    {
        ButtonAnimator.SetTrigger("Exit");
    }
    public void SwitchScenes()
    {
        SceneManager.LoadScene(sceneName: SceneName);
    }
}
