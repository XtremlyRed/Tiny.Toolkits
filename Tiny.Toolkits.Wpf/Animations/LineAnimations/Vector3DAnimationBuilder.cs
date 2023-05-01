using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Tiny.Toolkits
{
    /// <summary>																											
    /// a class of <see cref="Vector3DAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class Vector3DAnimationBuilder<T> : AnimationBuilderBase<Vector3DAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Vector3D? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Vector3D? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Vector3D? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Vector3DAnimationBuilder<T> From(Vector3D? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Vector3DAnimationBuilder<T> By(Vector3D? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Vector3DAnimationBuilder<T> To(Vector3D? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Vector3DAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public Vector3DAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private AnimationPlayer player;
        /// <summary> 																										
        /// build animation player.  																										
        /// </summary>       																										
        public IAnimationPlayer BuildAnimation()
        {
            Vector3DAnimation animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue)
            {
                animation.From = fromValue;
            }

            if (byValue.HasValue)
            {
                animation.By = byValue;
            }

            if (toValue.HasValue)
            {
                animation.To = toValue;
            }

            if (boolValue.HasValue)
            {
                animation.IsCumulative = boolValue.Value;
            }

            if (easingFunction != null)
            {
                animation.EasingFunction = easingFunction;
            }

            return player = new AnimationPlayer(animation);
        }
    }
}
