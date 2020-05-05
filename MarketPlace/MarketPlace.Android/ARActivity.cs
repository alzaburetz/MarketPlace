using Android.App;
using Android.Support.V7.App;
using Android.Widget;
using Android.OS;
using Android.Opengl;
using Google.AR.Core;
using Android.Util;
using Java.Interop;
using Javax.Microedition.Khronos.Opengles;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Support.V4.Content;
using Android.Support.V4.App;
using Javax.Microedition.Khronos.Egl;
using System.Collections.Concurrent;
using System;
using Google.AR.Core.Exceptions;

using Org.Tensorflow.Types;
using Org.Tensorflow.Contrib.Android;


namespace MarketPlace.Droid
{
    [Activity(Label = "ARActivity")]
    public class ARActivity : AppCompatActivity, GLSurfaceView.IRenderer, Android.Views.View.IOnTouchListener
    {
        TensorFlowInferenceInterface inferenceInterface;
        
        public void OnDrawFrame(IGL10 gl)
        {
            throw new NotImplementedException();
        }

        public void OnSurfaceChanged(IGL10 gl, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void OnSurfaceCreated(IGL10 gl, Javax.Microedition.Khronos.Egl.EGLConfig config)
        {
            throw new NotImplementedException();
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
        }
    }
}