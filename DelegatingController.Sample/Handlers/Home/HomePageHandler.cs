namespace DelegatingController.Sample.Handlers.Home
{
    public class HomePageHandler : IModelBuilder<HomeIndexViewModel>
    {
        public HomeIndexViewModel Build()
        {
            return new HomeIndexViewModel()
            {
                Welcome = "You have been delegated!"
            };
        }
    }
}