using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If there is a time passing mechanic, there will be multiple lists of posts stored here for each day
public class PostLibrary : MonoBehaviour
{
    public static PostLibrary s;
    public List<PostData> postsInUse;

    private void Start()
    {
        s = this;
    }
}
