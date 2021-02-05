using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
	internal static class CurrentStateInfoBufferHelper
	{
		internal static void UpdateBufferFromAnimator(Animator animator, DynamicBuffer<CurrentStateInfo> buffer)
		{
			var layerCount = animator.layerCount;
			for (var i = 0; i < layerCount; i++)
			{
				var info = animator.GetCurrentAnimatorStateInfo(i);

				var bufferElement = new CurrentStateInfo
				{
					NormalizedTime = info.normalizedTime,
					FullPathHash = info.fullPathHash,
					ShortNameHash = info.shortNameHash,
					IsLooping = info.loop,
					Speed = info.speed,
					SpeedMultiplier = info.speedMultiplier,
					Length = info.length,
					TagHash = info.tagHash
				};
				
				// Add or set dynamically depending on current layer count
				if (buffer.Length > i)
				{
					buffer[i] = bufferElement;
				}
				else
				{
					buffer.Add(bufferElement);
				}
			}
		}
	}
}