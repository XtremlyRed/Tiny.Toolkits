using System.ComponentModel;
using System.Windows.Media.Animation;

namespace Tiny.Toolkits
{
    /// <summary>
    /// animation player
    /// </summary>
    public interface IAnimationPlayer
    {
        /// <summary>
        /// play animation
        /// </summary>
        void Play();


        /// <summary>
        /// get current animation
        /// </summary>
        /// <returns></returns>
        Timeline GetAnimation();

    }


    internal class AnimationPlayer : IAnimationPlayer
    {
        internal Timeline timeline;
        internal AnimationPlayer(Timeline timeline)
        {
            this.timeline = timeline;
        }

        void IAnimationPlayer.Play()
        {
            Storyboard storyboard = new();
            storyboard.Children.Add(timeline);
            storyboard.Begin();
        }

        Timeline IAnimationPlayer.GetAnimation()
        {
            return timeline;
        }
         
    }
}
