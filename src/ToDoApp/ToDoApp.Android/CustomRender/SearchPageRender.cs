using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Plugin.CurrentActivity;
using ToDoApp.Droid.CustomRender;
using ToDoApp.Interfaces;
using ToDoApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ItemQueryPage), typeof(SearchPageRender))]
namespace ToDoApp.Droid.CustomRender
{
    public class SearchPageRender : PageRenderer
    {
        public SearchPageRender(Context context) : base(context)
        {

        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            if (Element is ISearchPage
                && Element is Page page
                && page.Parent is NavigationPage navigationPage)
            {
                //Workaround to re-add the SearchView when navigating back to an ISearchPage, because Xamarin.Forms automatically removes it
                navigationPage.Popped += HandleNavigationPagePopped;
                navigationPage.PoppedToRoot += HandleNavigationPagePopped;
            }
        }

        //Adding the SearchBar in OnSizeChanged ensures the SearchBar is re-added after the device is rotated, because Xamarin.Forms automatically removes it
        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);

            if (Element is ISearchPage && Element is Page page && page.Parent is NavigationPage navigationPage && navigationPage.CurrentPage is ISearchPage)
            {
                AddSearchToToolbar(page.Title);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (GetToolbar() is Android.Support.V7.Widget.Toolbar toolBar)
                toolBar.Menu?.RemoveItem(Resource.Menu.mainmenu);

            base.Dispose(disposing);
        }

        //Workaround to re-add the SearchView when navigating back to an ISearchPage, because Xamarin.Forms automatically removes it
        void HandleNavigationPagePopped(object sender, NavigationEventArgs e)
        {
            if (sender is NavigationPage navigationPage
                && navigationPage.CurrentPage is ISearchPage)
            {
                AddSearchToToolbar(navigationPage.CurrentPage.Title);
            }
        }

        void AddSearchToToolbar(string pageTitle)
        {
            if (GetToolbar() is Android.Support.V7.Widget.Toolbar toolBar
            && toolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.
            JavaCast<Android.Support.V7.Widget.SearchView>().GetType()
            != typeof(Android.Support.V7.Widget.SearchView))
            {
                toolBar.Title = pageTitle;
                toolBar.InflateMenu(Resource.Menu.mainmenu);

                if (toolBar.Menu?.FindItem(Resource.Id.action_search)?.ActionView?.
                    JavaCast<Android.Support.V7.Widget.SearchView>() is
                     Android.Support.V7.Widget.SearchView searchView)
                {
                    searchView.QueryTextChange += SearchView_QueryTextChange;
                    searchView.ImeOptions = (int)ImeAction.Search;
                    searchView.InputType = (int)InputTypes.TextVariationFilter;
                    searchView.MaxWidth = int.MaxValue;
                }
            }
        }

        private void SearchView_QueryTextChange(object sender, Android.Support.V7.Widget.SearchView.QueryTextChangeEventArgs e)
        {
            if (Element is ISearchPage searchPage)
                searchPage.OnSearchBarTextChanged(e.NewText);
        }

        private static Android.Support.V7.Widget.Toolbar GetToolbar() => (CrossCurrentActivity.Current?.Activity as MainActivity)?.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
    }
}