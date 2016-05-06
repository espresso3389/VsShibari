using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Xamarin.Forms;

namespace XamApp
{
	public class App : Application
	{
#if __IOS__
        public const string CPPMODULENAME = "__Internal";
#elif __ANDROID__
        public const string CPPMODULENAME = "libCppModule.so";
#endif

        [DllImport(CPPMODULENAME)]
        static extern IntPtr AllocCppString();
        [DllImport(CPPMODULENAME)]
        static extern void FreeCppString(IntPtr str);

        static string GetCppString()
        {
            var p = AllocCppString();
            var s = Marshal.PtrToStringAnsi(p); // UTF-8
            FreeCppString(p);
            return s;
        }

        public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = GetCppString()
                        }
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
    }
}
