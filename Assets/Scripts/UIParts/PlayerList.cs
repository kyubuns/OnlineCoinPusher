using UnityEngine;
using UnityEngine.UI;

namespace UIParts
{
	[RequireComponent(typeof(Text))]
	public class PlayerList : Photon.PunBehaviour
	{
		private Text Text;

		public void Awake()
		{
			Text = GetComponent<Text>();
		}

		public void Start()
		{
			UpdateText();
		}

		public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
		{
			UpdateText();
		}

		public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
		{
			UpdateText();
		}

		public void UpdateText()
		{
			Text.text = "";
			Text.text += string.Format("Players({0})\n", PhotonNetwork.playerList.Length);
			foreach (var player in PhotonNetwork.playerList)
			{
				Text.text += string.Format("- {0}\n", player.NickName);
			}
		}
	}
}