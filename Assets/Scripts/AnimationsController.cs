using UnityEngine;

namespace Scripts
{
    public class AnimationsController : MonoBehaviour
    {
        private Animator _animator;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void SwitchWalkAnimationOn()
        {
            _animator.SetTrigger(GlobalConstants.ANIMATOR_TRIGGER_WALK);
            _animator.ResetTrigger(GlobalConstants.ANIMATOR_TRIGGER_IDLE);
            _animator.ResetTrigger(GlobalConstants.ANIMATOR_TRIGGER_RUN);
        }
        
        public void SwitchRunAnimationOn()
        {
            _animator.SetTrigger(GlobalConstants.ANIMATOR_TRIGGER_RUN);
            _animator.ResetTrigger(GlobalConstants.ANIMATOR_TRIGGER_IDLE);
            _animator.ResetTrigger(GlobalConstants.ANIMATOR_TRIGGER_WALK);
        }
        
        public void SwitchIdleAnimationOn()
        {
            _animator.SetTrigger(GlobalConstants.ANIMATOR_TRIGGER_IDLE);
            _animator.ResetTrigger(GlobalConstants.ANIMATOR_TRIGGER_WALK);
            _animator.ResetTrigger(GlobalConstants.ANIMATOR_TRIGGER_RUN);
        }
        
        public void SwitchHookAnimationOn()
        {
            _animator.SetTrigger(GlobalConstants.ANIMATOR_TRIGGER_HOOK);
            _animator.SetTrigger(GlobalConstants.ANIMATOR_TRIGGER_WALK);
            _animator.ResetTrigger(GlobalConstants.ANIMATOR_TRIGGER_IDLE);
            _animator.ResetTrigger(GlobalConstants.ANIMATOR_TRIGGER_RUN);
        }

        public AnimationClip GetCurrentAnimationClip()
        {
            return _animator.GetCurrentAnimatorClipInfo(0)[0].clip;
        }
    }
}