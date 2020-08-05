using Android.Content;
using ToDoApp.Droid.Renderers;
using ToDoApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NonCapsTextButton), typeof(NonCapsTextButtonRender))]
namespace ToDoApp.Droid.Renderers
{   
    public class NonCapsTextButtonRender: ButtonRenderer
    {
        public NonCapsTextButtonRender(Context context)
            :base (context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e); 
            if (Control is Android.Widget.Button button)
            {
                button.SetAllCaps(false);
            }       
        }

    }
}