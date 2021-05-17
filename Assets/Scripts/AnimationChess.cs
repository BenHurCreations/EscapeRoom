using System.Collections;
using UnityEngine;

public class AnimationChess : MonoBehaviour
{
    public Animator BoardAnimator;
    public GameObject RookLight1;
    public GameObject RookDark;

    // Music variables
    public GameObject firstSong;
    public GameObject secondSong;

    // Solved activator
    public SolvedActivator solved;


    void Start()
    {
        BoardAnimator = GetComponent<Animator>();
        BoardAnimator.GetComponent<Animator>().enabled = false;
    }


    public void ActivateAnima()
    {
        StartCoroutine(StartMove());
        BoardAnimator.GetComponent<Animator>().enabled = true;
    }


    IEnumerator StartMove()
    {
        yield return new WaitForSeconds(1.7f);
        RookLight1.SetActive(false);
        yield return new WaitForSeconds(1.6f);
        RookDark.SetActive(false);
        yield return new WaitForSeconds(1.52f);
        BoardAnimator.GetComponent<Animator>().enabled = false;
        solved.SetColors();
        changeMusic();
    }

    void changeMusic()
    {
        firstSong.SetActive(false);
        secondSong.SetActive(true);
    }
}
