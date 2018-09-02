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

	public void GuestSignIn() {
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

	// TODO Unused...
	public void GoogleSignIn() {
		string googleIdToken = "";
		string googleAccessToken = null;
		Firebase.Auth.Credential credential =
			Firebase.Auth.GoogleAuthProvider.GetCredential(googleIdToken, googleAccessToken);
		this.auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
			if (task.IsCanceled) {
				string errorMsg = "SignInWithCredentialAsync was canceled.";
				Debug.LogError(errorMsg);
				this.infoText.text = errorMsg;
				return;
			}
			if (task.IsFaulted) {
				string errorMsg = "SignInWithCredentialAsync encountered an error: " + task.Exception;
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

	// User creation with email
	public void EmailSignIn() {
		string user = "javifont@gmail.com";
		string password = "CoolPassword1";
		auth.CreateUserWithEmailAndPasswordAsync(user, password).ContinueWith(task => {
			if (task.IsCanceled) {
				string errorMsg = "CreateUserWithEmailAndPasswordAsync was canceled.";
				Debug.LogError(errorMsg);
				this.infoText.text = errorMsg;
				return;
			}
			if (task.IsFaulted) {
				string errorMsg = "CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception;
				Debug.LogError(errorMsg);
				this.infoText.text = errorMsg;
				return;
			}

			// Firebase user has been created.
			Firebase.Auth.FirebaseUser newUser = task.Result;
			Debug.LogFormat("Firebase user created successfully: {0} ({1})",
				newUser.DisplayName, newUser.UserId);
			this.infoText.text = "User signed in successfully: " + newUser.UserId;
			});		
	}


	public void EmailLogIn() {
		string user = "javifont@gmail.com";
		string password = "CoolPassword1";
		this.auth.SignInWithEmailAndPasswordAsync(user, password).ContinueWith(task => {
		if (task.IsCanceled) {
			string errorMsg = "SignInWithEmailAndPasswordAsync was canceled.";
			Debug.LogError(errorMsg);
			this.infoText.text = errorMsg;
			return;
		}
		if (task.IsFaulted) {
			string errorMsg = "SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception;
			Debug.LogError(errorMsg);
			this.infoText.text = errorMsg;
			return;
		}

		Firebase.Auth.FirebaseUser newUser = task.Result;
		Debug.LogFormat("User signed in successfully: {0} ({1})",
			newUser.DisplayName, newUser.UserId);
		this.infoText.text = "User logged in successfully: " + newUser.UserId;
		});
	}

	public void LogOut() {
		this.auth.SignOut();
		string errorMsg = "User logged out";
		this.infoText.text = errorMsg;
	}

	
/*
	public string GetGoogleTokenID() {
		PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
					.RequestIdToken()
					.Build();
		PlayGamesPlatform.InitializeInstance(config);
		PlayGamesPlatform.Activate();		
		return "";
	}
*/
}
