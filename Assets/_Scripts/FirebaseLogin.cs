using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirebaseLogin : MonoBehaviour {

	public Text infoText;
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
				string errorMsg = "SignInAnonymouslyAsync was canceled.";
				Debug.LogError(errorMsg);
				this.infoText.text = errorMsg;
				return;
			}
			if (task.IsFaulted) {
				string errorMsg = "SignInAnonymouslyAsync encountered an error: " + task.Exception;
				Debug.LogError(errorMsg);
				this.infoText.text = errorMsg;
				return;
			}

			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("User signed in successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
			this.infoText.text = "User signed in successfully: " + newUser.UserId;
			});
	}
}
