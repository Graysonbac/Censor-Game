using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float playerMoralScore = 0;

    public Queue<PostData> postQueue;

    public static GameManager s;

    public Canvas DisciplineMenu;

    // Start is called before the first frame update
    void Start()
    {
        s = this;
        DisciplineMenu.enabled = false;

        postQueue = new Queue<PostData>();
        PopulatePostQueue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// SOME NOTES ON THE INTENDED PROPERTIES OF THE POST QUEUE POPULATION
    /// - A player can Ban a user, which means all posts for that user need to be removed from collections
    /// - It could be worth it to add some randomness to the order, rather than just iterating through the Post Library
    /// - Eventually, the game will be broken into a few "phases" to help progress the plot
    /// - Some posts will require the player to be above, below, or between certain scores to exist.
    /// </summary>

    void PopulatePostQueue()
    {
        foreach (PostData post in PostLibrary.s.postsInUse)
        {
            postQueue.Enqueue(post);
        }
    }

    //Our basic functions for discipline are removing the post or banning the user (also removes the post)
    //TODO: Add a "fact check" button?
    public void OpenDisciplineMenu()
    {
        DisciplineMenu.enabled = true;
    }

    public void CloseDisciplineMenu()
    {
        DisciplineMenu.enabled = false;
    }
}
