using UnityEngine;
using UnityEngine.UI;

namespace UIParts
{
	[RequireComponent(typeof(Text))]
	public class VersionText : MonoBehaviour
	{
		public void Start()
		{
			GetComponent<Text>().text = Game.Version;
		}
	}
}