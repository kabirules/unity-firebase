using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseLogin : MonoBehaviour {

	Firebase.Auth.FirebaseAuth auth;
	
	// Use this for initialization
	void Start () {
		this.auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GuestLogin() {
		this.auth.SignInAnonymouslyAsync().ContinueWith(task => {
			if (task.IsCanceled) {
				Debug.LogError("SignInAnonymouslyAsync was canceled.");
				return;
			}
			if (task.IsFaulted) {
				Debug.LogError("SignInAnonymouslyAsync encountered an error: " + task.Exception);
				return;
			}

			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("User signed in successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
			});
	}
}
