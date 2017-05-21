using UnityEngine;
using UnityEngine.UI;

namespace Scene
{
	public class Title : Photon.PunBehaviour
	{
		[SerializeField]
		private Button ConnectButton;

		[SerializeField]
		private InputField NameText;

		public void Start()
		{
			ConnectButton.onClick.AddListener(OnClickConnectButton);
		}

		private void OnClickConnectButton()
		{
			var playerName = NameText.text;
			if (string.IsNullOrEmpty(playerName)) return;
			PhotonNetwork.playerName = playerName;

			ConnectButton.interactable = false;
			ConnectButton.GetComponentInChildren<Text>().text = "Connecting...";
			PhotonNetwork.ConnectUsingSettings(Game.Version);
		}

		public override void OnJoinedLobby()
		{
			Debug.Log("OnJoinedLobby");
			PhotonNetwork.JoinRandomRoom();
		}

		public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
		{
			Debug.Log("OnPhotonRandomJoinFailed");
			var roomOptions = new RoomOptions();
			roomOptions.MaxPlayers = 16;
			PhotonNetwork.CreateRoom("Random" + Random.Range(0, 100000), roomOptions, TypedLobby.Default);
		}

		public override void OnJoinedRoom()
		{
			Debug.Log("OnJoinedRoom");
			if (PhotonNetwork.isMasterClient)
			{
				PhotonNetwork.automaticallySyncScene = true;
				PhotonNetwork.LoadLevel("Main");
			}
		}
	}
}