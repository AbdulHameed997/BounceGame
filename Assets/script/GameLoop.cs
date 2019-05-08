using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameLoop : MonoBehaviour
{
    public GameObject gamoverui;
    public Text livesui;
    public Text scoreui;
    public GameObject ingameui;
    public GameObject completeui;


    public GameObject player;
    public int livees;
    public int score;
    int ringtoremove;

    public GameObject[] morelivesarray;
    public GameObject[] uirings;

    public GameObject[] ringsarray;

    public Transform startpoint;

    public Transform restorepoint;
    public Transform[] revivalpoints;
    //public GameObject[] addlives;

    // Use this for initialization
    void Start()
    {
        //	gm=GetComponents
        updatelivedisplay();

        restorepoint = startpoint;
        ringtoremove = uirings.Length;
        ringtoremove--;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void killed()
    {
        //
        if (checklives())
        {

            player.transform.position = restorepoint.position;

        }


    }

    bool checklives()
    {
        if (livees > 0)
        {
            livees--;
            updatelivedisplay();

            return true;
        }
        else
        {
            ingameui.SetActive(false);
            gamoverui.SetActive(true);
            gamoverui.transform.GetChild(2).GetComponent<Text>().text = "Score " + score.ToString();

            return false;
        }

    }
    void addnewlives()
    {
        livees++;
        updatelivedisplay();

    }

    public void ringstouched(int ri)
    {
        //remove rings
        uirings[ringtoremove].gameObject.SetActive(false);
        ringtoremove--;


        score = score + ri;
        updateScore();
        Debug.Log("ring");


    }

    public void setrestorepoint(Transform trans)
    {
        restorepoint = trans;
        score = score + 200;
        updateScore();

    }
    void updatelivedisplay()
    {
        livesui.text = "" + livees;

    }
    void updateScore()
    {
        scoreui.text = "" + score;

    }


    public void addmorelives(int ri)
    {
        livees++;
        updatelivedisplay();
        score = score + ri;
        updateScore();
    }


    public void reseteverything()
    {

        ringtoremove = uirings.Length;
        ringtoremove--;
        player.SetActive(true);

        ingameui.SetActive(true);
        //restorepoint.position = startpoint.position;
        player.GetComponent<PlayerPlatformerController>().Deflateball();
        gamoverui.SetActive(false);
        livees = 3;
        score = 0;
        updateScore();
        updatelivedisplay();

        player.transform.position = startpoint.position;

        foreach (GameObject t in morelivesarray)
        {
            t.gameObject.GetComponent<MoreLives>().reset();
        }

        foreach (GameObject ri in ringsarray)
        {
            ri.gameObject.GetComponent<Rings>().reset();
        }

        foreach (Transform re in revivalpoints)
        {
            re.gameObject.GetComponent<RestoreScript>().reset();
        }
        foreach (GameObject uir in uirings)
        {
            uir.gameObject.SetActive(true);
        }

    }


    public void levelcompleted()
    {
        player.SetActive(false);

        ingameui.SetActive(false);
        completeui.SetActive(true);
        completeui.transform.GetChild(0).GetComponent<Text>().text = "Score " + score.ToString();




    }
    public void loadsceneselection()
    {

        Application.LoadLevel(0);
    }
}
