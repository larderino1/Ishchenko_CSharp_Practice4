using System;
using IshchenkoKMAPractice4.Views;

namespace IshchenkoKMAPractice4.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Input:
                    ViewsDictionary.Add(viewType, new InputView());
                    break;
                case ViewType.Main:
                    ViewsDictionary.Add(viewType, new ListView());
                    break;
                case ViewType.Edit:
                    ViewsDictionary.Add(viewType, new EditView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}