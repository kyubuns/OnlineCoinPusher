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

		[SerializeField]
		private Toggle OfflineToggle;

		public void Start()
		{
			ConnectButton.onClick.AddListener(OnClickConnectButton);
		}

		private void OnClickConnectButton()
		{
			var playerName = NameText.text;
			if (string.IsNullOrEmpty(playerName)) return;

			PhotonNetwork.offlineMode = OfflineToggle.isOn;
			PhotonNetwork.playerName = playerName;

			ConnectButton.interactable = false;
			OfflineToggle.interactable = false;
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
			PhotonNetwork.automaticallySyncScene = true;

			if (PhotonNetwork.isMasterClient)
			{
				PhotonNetwork.LoadLevel("Main");
			}
		}
	}
}