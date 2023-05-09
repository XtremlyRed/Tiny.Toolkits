using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;


namespace Tiny.Toolkits
{

    /// <summary>
    ///  a class of <see cref="AnimationAssist"/>
    /// </summary>
    public static class AnimationAssist
    {

        /// <summary>																											
        /// Attach <see cref="ThicknessAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ThicknessAnimationBuilder<T> WithThicknessAnimation<T>(this T target) where T : DependencyObject
        {
            ThicknessAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }


        /// <summary>																											
        /// Attach <see cref="QuaternionAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static QuaternionAnimationBuilder<T> WithQuaternionAnimation<T>(this T target) where T : DependencyObject
        {
            QuaternionAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="ByteAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ByteAnimationBuilder<T> WithByteAnimation<T>(this T target) where T : DependencyObject
        {
            ByteAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="ColorAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ColorAnimationBuilder<T> WithColorAnimation<T>(this T target) where T : DependencyObject
        {
            ColorAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="DecimalAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static DecimalAnimationBuilder<T> WithDecimalAnimation<T>(this T target) where T : DependencyObject
        {
            DecimalAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="DoubleAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static DoubleAnimationBuilder<T> WithDoubleAnimation<T>(this T target) where T : DependencyObject
        {
            DoubleAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int16Animation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int16AnimationBuilder<T> WithInt16Animation<T>(this T target) where T : DependencyObject
        {
            Int16AnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int32Animation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int32AnimationBuilder<T> WithInt32Animation<T>(this T target) where T : DependencyObject
        {
            Int32AnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int64Animation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int64AnimationBuilder<T> WithInt64Animation<T>(this T target) where T : DependencyObject
        {
            Int64AnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Point3DAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Point3DAnimationBuilder<T> WithPoint3DAnimation<T>(this T target) where T : DependencyObject
        {
            Point3DAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="PointAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static PointAnimationBuilder<T> WithPointAnimation<T>(this T target) where T : DependencyObject
        {
            PointAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="RectAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static RectAnimationBuilder<T> WithRectAnimation<T>(this T target) where T : DependencyObject
        {
            RectAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Rotation3DAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Rotation3DAnimationBuilder<T> WithRotation3DAnimation<T>(this T target) where T : DependencyObject
        {
            Rotation3DAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="SingleAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static SingleAnimationBuilder<T> WithSingleAnimation<T>(this T target) where T : DependencyObject
        {
            SingleAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="SizeAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static SizeAnimationBuilder<T> WithSizeAnimation<T>(this T target) where T : DependencyObject
        {
            SizeAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Vector3DAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Vector3DAnimationBuilder<T> WithVector3DAnimation<T>(this T target) where T : DependencyObject
        {
            Vector3DAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="VectorAnimation"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static VectorAnimationBuilder<T> WithVectorAnimation<T>(this T target) where T : DependencyObject
        {
            VectorAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }



        /// <summary>																											
        /// Attach <see cref="ThicknessAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ThicknessKeyFrameAnimationBuilder<T> WithThicknessKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            ThicknessKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }

        /// <summary>																											
        /// Attach <see cref="BooleanAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static BooleanKeyFrameAnimationBuilder<T> WithBooleanKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            BooleanKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="ByteAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ByteKeyFrameAnimationBuilder<T> WithByteKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            ByteKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="CharAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static CharKeyFrameAnimationBuilder<T> WithCharKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            CharKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="ColorAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ColorKeyFrameAnimationBuilder<T> WithColorKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            ColorKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="DecimalAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static DecimalKeyFrameAnimationBuilder<T> WithDecimalKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            DecimalKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="DoubleAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static DoubleKeyFrameAnimationBuilder<T> WithDoubleKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            DoubleKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int16AnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int16KeyFrameAnimationBuilder<T> WithInt16KeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            Int16KeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int32AnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int32KeyFrameAnimationBuilder<T> WithInt32KeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            Int32KeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Int64AnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Int64KeyFrameAnimationBuilder<T> WithInt64KeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            Int64KeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="MatrixAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static MatrixKeyFrameAnimationBuilder<T> WithMatrixKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            MatrixKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="ObjectAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static ObjectKeyFrameAnimationBuilder<T> WithObjectKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            ObjectKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Point3DAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Point3DKeyFrameAnimationBuilder<T> WithPoint3DKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            Point3DKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="PointAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static PointKeyFrameAnimationBuilder<T> WithPointKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            PointKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="QuaternionAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static QuaternionKeyFrameAnimationBuilder<T> WithQuaternionKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            QuaternionKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="RectAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static RectKeyFrameAnimationBuilder<T> WithRectKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            RectKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Rotation3DAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Rotation3DKeyFrameAnimationBuilder<T> WithRotation3DKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            Rotation3DKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="SingleAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static SingleKeyFrameAnimationBuilder<T> WithSingleKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            SingleKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="SizeAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static SizeKeyFrameAnimationBuilder<T> WithSizeKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            SizeKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="StringAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static StringKeyFrameAnimationBuilder<T> WithStringKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            StringKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="Vector3DAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static Vector3DKeyFrameAnimationBuilder<T> WithVector3DKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            Vector3DKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }
        /// <summary>																											
        /// Attach <see cref="VectorAnimationUsingKeyFrames"/> to dependencyObject object																											
        /// </summary>																											
        /// <typeparam name="T">dependencyObject type</typeparam>																											
        public static VectorKeyFrameAnimationBuilder<T> WithVectorKeyFrameAnimation<T>(this T target) where T : DependencyObject
        {
            VectorKeyFrameAnimationBuilder<T> builder = new();
            return builder.Target(target);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="animationPlayers"></param> 
        public static void PlayAnimations(params IAnimationPlayer[] animationPlayers)
        {
            PlayAnimations(animationPlayers, null);
        }

         

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animationPlayers"></param>
        /// <param name="playCompleteCallback"></param>
        public static void PlayAnimations(this ICollection<IAnimationPlayer>  animationPlayers, Action playCompleteCallback = null)
        {
            animationPlayers = animationPlayers?.Where(i => i != null).ToArray();

            if (animationPlayers == null || animationPlayers.Count == 0)
            {
                return;
            }

            Storyboard storyboard = new();

            if (playCompleteCallback != null)
            {
                storyboard.Completed += (s, e) => playCompleteCallback.Invoke();
            }

            foreach (IAnimationPlayer item in animationPlayers)
            {
                if (item != null)
                {
                    storyboard.Children.Add(item.GetAnimation());
                }
            }

            storyboard.Begin();
        }
    }
}
