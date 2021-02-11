using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Post : MonoBehaviour
{
    public TextMeshProUGUI posterName;
    public TextMeshProUGUI postBody;
    public Image profilePic;
    public Text numCommentsSpace;
    public Text numLikesSpace;

    public PostData postData;
    public bool interacted = false; //Set true when player takes action (including ignore)
    public bool initSync = false; //Set true after the first post is generated from data

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!initSync || interacted)
        {
            GetNewPost();
        }
    }

    //Until I get around to adding a proper feed for posts to scroll through, the single post on-screen will turn into another post once interacted with

    void GetNewPost()
    {
        if(GameManager.s.postQueue.Count > 0)
        {
            postData = GameManager.s.postQueue.Dequeue();
            SyncToPostData();
        } else
        {
            Debug.LogError("No more posts!");
        }
    }

    //TODO: Refactor PostData to include image posting, then rewrite this function to adjust formatting as needed
    void SyncToPostData()
    {
        GameManager.s.DisciplineMenu.enabled = false;
        posterName.text = "@" + postData.Poster;
        postBody.text = postData.Text;
        profilePic.sprite = postData.profilePic;
        numCommentsSpace.text = postData.numComments.ToString();
        numLikesSpace.text = postData.numLikes.ToString();

        if(!initSync)
        {
            initSync = true;
        }

        interacted = false;
    }

    #region button interactions
    //liking a post will add the post's morality score to the player's score
    public void LikePost()
    {
        GameManager.s.playerMoralScore += postData.moralScore;
        interacted = true;
    }

    //deleting a post will subtract the post's morality score from the player's score
    public void DeletePost()
    {
        GameManager.s.playerMoralScore -= postData.moralScore;
        interacted = true;
    }

    //banning a user will subtract twice the post's morality score, as well as scrub the post library of posts from that user.
    //TODO: remove a user from the post library on a ban
    public void BanUser()
    {
        GameManager.s.playerMoralScore += ((postData.moralScore * -2) + 1); //+1 because banning a neutral post should skew order
        interacted = true;
    }

    #endregion

}
