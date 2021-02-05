using Unity.Entities;
using UnityEngine;

namespace Parabole.AnimatorSystems
{
	internal static class CurrentStateInfoBufferHelper
	{
		internal static void UpdateBufferFromAnimator(Animator animator, DynamicBuffer<CurrentStateInfo> buffer)
		{
			var layerCount = animator.layerCount;

			if (layerCount > buffer.Length)
			{
				buffer.ResizeUninitialized(layerCount);
			}
			
			for (var i = 0; i < layerCount; i++)
			{
				var info = animator.GetCurrentAnimatorStateInfo(i);

				buffer[i] = new CurrentStateInfo
				{
					LayerIndex = i,
					NormalizedTime = info.normalizedTime,
					FullPathHash = info.fullPathHash,
					ShortNameHash = info.shortNameHash,
					IsLooping = info.loop,
					Speed = info.speed,
					SpeedMultiplier = info.speedMultiplier,
					Length = info.length,
					TagHash = info.tagHash
				};
			}
		}
	}
}