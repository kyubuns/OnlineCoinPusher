using UnityEngine;
using UnityEngine.UI;
using CoinPusher;

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

		public void Update()
		{
			Text.text = "";
			Text.text += string.Format("Players({0})\n", PhotonNetwork.playerList.Length);
			foreach (var player in PhotonNetwork.playerList)
			{
				var go = GameObject.Find("Player_" + player.ID);
				var coin = 0;
				if (go != null)
				{
					coin = go.GetComponent<CoinSpawner>().Coin;
				}
				Text.text += string.Format("- {0}: {1}\n", player.NickName, coin);
			}
		}
	}
}