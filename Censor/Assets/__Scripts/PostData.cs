using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Post Data")]
public class PostData : ScriptableObject
{
    public string Poster; //ignore the @ symbol
    public string Text;
    public Sprite profilePic;
    public float moralScore = 0; //Negative score = chaos, Positive score = order, neutral = 0
    public int numComments = 0; //Pretty much arbitrary flavor
    public int numLikes = 0; //^^
}
