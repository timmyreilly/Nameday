using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Nameday
{
    [TypeConstraint(typeof(ListViewBase))]
    class AutoScrollToSelectedItemBehavior : DependencyObject, IBehavior
    {
        private ListViewBase AssociatedListView => AssociatedObject as ListView; 


        public DependencyObject AssociatedObject { get; private set; }


        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;

            if (AssociatedListView != null)
                AssociatedListView.SelectionChanged += ListViewOnSelectionChanged; 
        }

        private void ListViewOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AssociatedListView.SelectedItem == null)
            {
                return; 
            }

            AssociatedListView.ScrollIntoView(AssociatedListView.SelectedItem); 
        }

        public void Detach()
        {
            if (AssociatedListView != null)
                AssociatedListView.SelectionChanged -= ListViewOnSelectionChanged; 
        }


    }
}
