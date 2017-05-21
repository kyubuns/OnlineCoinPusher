using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
	public class JumpInit : MonoBehaviour
	{
		public void Awake()
		{
			if (!PhotonNetwork.connected)
			{
				SceneManager.LoadScene("Init");
			}
		}
	}
}