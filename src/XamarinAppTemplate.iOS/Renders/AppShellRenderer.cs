using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinAppTemplate;
using XamarinAppTemplate.iOS.Renders;

[assembly: ExportRenderer(typeof(AppShell), typeof(AppShellRenderer))]

namespace XamarinAppTemplate.iOS.Renders
{
    public class AppShellRenderer : ShellRenderer
    {
        public AppShellRenderer()
        {

        }

		private void UpdateLayoutDirection()
		{
		//	//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//	//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//	//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//	//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//	UISemanticContentAttribute semanticContentAttribute = UISemanticContentAttribute.ForceLeftToRight;

		//	((UIView)((UIViewController)this).NavigationController.()).set_SemanticContentAttribute(semanticContentAttribute);
		//	foreach (object item in (UIView)((UINavigationController)this).get_NavigationBar())
		//	{
		//		UIView val;
		//		if ((val = (item as UIView)) != null)
		//		{
		//			val.SetNeedsLayout();
		//			foreach (object item2 in val)
		//			{
		//				UIView val2;
		//				if ((val2 = (item2 as UIView)) != null)
		//				{
		//					val2.SetNeedsLayout();
		//				}
		//			}
		//		}
		//	}
		//((UIView)((UINavigationController)this).get_NavigationBar()).SetNeedsLayout();
		//	if (((UIViewController)this).get_View() != null)
		//	{
		//		((UIViewController)this).get_View().set_SemanticContentAttribute(semanticContentAttribute);
		//	}
		}
	}
}