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



        #region hide base function

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"> The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        ///  Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }


        #endregion
    }
}
