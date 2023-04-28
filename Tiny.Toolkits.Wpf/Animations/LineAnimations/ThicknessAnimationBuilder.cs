using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Tiny.Toolkits
{
    /// <summary>																											
    /// a class of <see cref="ThicknessAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class ThicknessAnimationBuilder<T> : AnimationBuilderBase<ThicknessAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Thickness? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Thickness? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Thickness? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public ThicknessAnimationBuilder<T> From(Thickness? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public ThicknessAnimationBuilder<T> By(Thickness? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public ThicknessAnimationBuilder<T> To(Thickness? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public ThicknessAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public ThicknessAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ThicknessAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="QuaternionAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class QuaternionAnimationBuilder<T> : AnimationBuilderBase<QuaternionAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Quaternion? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Quaternion? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Quaternion? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public QuaternionAnimationBuilder<T> From(Quaternion? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public QuaternionAnimationBuilder<T> By(Quaternion? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public QuaternionAnimationBuilder<T> To(Quaternion? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public QuaternionAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public QuaternionAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private QuaternionAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="ByteAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class ByteAnimationBuilder<T> : AnimationBuilderBase<ByteAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Byte? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Byte? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Byte? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public ByteAnimationBuilder<T> From(Byte? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public ByteAnimationBuilder<T> By(Byte? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public ByteAnimationBuilder<T> To(Byte? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public ByteAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public ByteAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ByteAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="ColorAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class ColorAnimationBuilder<T> : AnimationBuilderBase<ColorAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Color? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Color? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Color? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public ColorAnimationBuilder<T> From(Color? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public ColorAnimationBuilder<T> By(Color? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public ColorAnimationBuilder<T> To(Color? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public ColorAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public ColorAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private ColorAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="DecimalAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class DecimalAnimationBuilder<T> : AnimationBuilderBase<DecimalAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Decimal? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Decimal? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Decimal? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public DecimalAnimationBuilder<T> From(Decimal? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public DecimalAnimationBuilder<T> By(Decimal? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public DecimalAnimationBuilder<T> To(Decimal? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public DecimalAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public DecimalAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private DecimalAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="DoubleAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class DoubleAnimationBuilder<T> : AnimationBuilderBase<DoubleAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Double? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Double? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Double? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public DoubleAnimationBuilder<T> From(Double? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public DoubleAnimationBuilder<T> By(Double? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public DoubleAnimationBuilder<T> To(Double? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public DoubleAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public DoubleAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private DoubleAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="Int16AnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class Int16AnimationBuilder<T> : AnimationBuilderBase<Int16AnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int16? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int16? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int16? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Int16AnimationBuilder<T> From(Int16? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Int16AnimationBuilder<T> By(Int16? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Int16AnimationBuilder<T> To(Int16? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Int16AnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public Int16AnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int16Animation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="Int32AnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class Int32AnimationBuilder<T> : AnimationBuilderBase<Int32AnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int32? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int32? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int32? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> From(Int32? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> By(Int32? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> To(Int32? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public Int32AnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int32Animation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="Int64AnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class Int64AnimationBuilder<T> : AnimationBuilderBase<Int64AnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int64? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int64? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int64? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Int64AnimationBuilder<T> From(Int64? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Int64AnimationBuilder<T> By(Int64? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Int64AnimationBuilder<T> To(Int64? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Int64AnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public Int64AnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Int64Animation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="Point3DAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class Point3DAnimationBuilder<T> : AnimationBuilderBase<Point3DAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point3D? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point3D? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point3D? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Point3DAnimationBuilder<T> From(Point3D? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Point3DAnimationBuilder<T> By(Point3D? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Point3DAnimationBuilder<T> To(Point3D? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Point3DAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public Point3DAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point3DAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="PointAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class PointAnimationBuilder<T> : AnimationBuilderBase<PointAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Point? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> From(Point? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> By(Point? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> To(Point? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public PointAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private PointAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="RectAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class RectAnimationBuilder<T> : AnimationBuilderBase<RectAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Rect? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Rect? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Rect? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public RectAnimationBuilder<T> From(Rect? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public RectAnimationBuilder<T> By(Rect? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public RectAnimationBuilder<T> To(Rect? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public RectAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public RectAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private RectAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="Rotation3DAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class Rotation3DAnimationBuilder<T> : AnimationBuilderBase<Rotation3DAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Rotation3D fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Rotation3D byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Rotation3D toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Rotation3DAnimationBuilder<T> From(Rotation3D fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Rotation3DAnimationBuilder<T> By(Rotation3D byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public Rotation3DAnimationBuilder<T> To(Rotation3D toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public Rotation3DAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public Rotation3DAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Rotation3DAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue != null) { animation.From = fromValue; }
            if (byValue != null) { animation.By = byValue; }
            if (toValue != null) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="SingleAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class SingleAnimationBuilder<T> : AnimationBuilderBase<SingleAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Single? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Single? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Single? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public SingleAnimationBuilder<T> From(Single? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public SingleAnimationBuilder<T> By(Single? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public SingleAnimationBuilder<T> To(Single? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public SingleAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public SingleAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private SingleAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="SizeAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class SizeAnimationBuilder<T> : AnimationBuilderBase<SizeAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Size? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Size? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Size? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> From(Size? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> By(Size? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> To(Size? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public SizeAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private SizeAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
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
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Vector3DAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
    /// <summary>																											
    /// a class of <see cref="VectorAnimationBuilder{T}"/>																											
    /// </summary>																											
    /// <typeparam name="T">dependencyObject type</typeparam>																											
    public class VectorAnimationBuilder<T> : AnimationBuilderBase<VectorAnimationBuilder<T>, T> where T : DependencyObject
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Vector? fromValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Vector? byValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private Vector? toValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private bool? boolValue;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private IEasingFunction easingFunction;

        /// <summary>                                                                                                                            
        /// animation's starting value.                                                                                                          
        /// </summary>                                                                                                                           
        /// <param name="fromValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public VectorAnimationBuilder<T> From(Vector? fromValue)
        {
            this.fromValue = fromValue;
            return this;
        }
        /// <summary>                                                                                                                            
        /// the total amount by which the animation changes its starting value.                                                                  
        /// </summary>                                                                                                                           
        /// <param name="byValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public VectorAnimationBuilder<T> By(Vector? byValue)
        {
            this.byValue = byValue;
            return this;
        }

        /// <summary>                                                                                                                            
        /// the animation's ending value.                                                                                                        
        /// </summary>                                                                                                                           
        /// <param name="toValue"></param>                                                                                                       
        /// <returns></returns>                                                                                                                  
        public VectorAnimationBuilder<T> To(Vector? toValue)
        {
            this.toValue = toValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// a value that specifies whether the animation's value accumulates when it repeats.                                                    
        /// </summary>                                                                                                                           
        /// <param name="boolValue"></param>                                                                                                     
        /// <returns></returns>                                                                                                                  
        public VectorAnimationBuilder<T> IsCumulative(bool boolValue)
        {
            this.boolValue = boolValue;
            return this;
        }


        /// <summary>                                                                                                                            
        /// the easing function applied to this animation.                                                                                       
        /// </summary>                                                                                                                           
        /// <param name="easingFunction"></param>                                                                                                
        /// <returns></returns>                                                                                                                  
        public VectorAnimationBuilder<T> EasingFunction(IEasingFunction easingFunction)
        {
            this.easingFunction = easingFunction;
            return this;
        }
        /// <summary> 																										
        /// begin animation.  																										
        /// </summary>       																										
        public void Begin()
        {
            if (animation is null)
            {
                throw new InvalidOperationException("build the animation first");
            }

            Storyboard storyboard = new();
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private VectorAnimation animation;
        /// <summary> 																										
        /// build animation.  																										
        /// </summary>       																										
        public void BuildAnimation()
        {
            animation = new();
            base.BuildAnimation(animation);
            if (fromValue.HasValue) { animation.From = fromValue; }
            if (byValue.HasValue) { animation.By = byValue; }
            if (toValue.HasValue) { animation.To = toValue; }
            if (boolValue.HasValue) { animation.IsCumulative = boolValue.Value; }
            if (easingFunction != null) { animation.EasingFunction = easingFunction; }
        }
    }
}
