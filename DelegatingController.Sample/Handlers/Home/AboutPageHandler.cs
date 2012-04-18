namespace DelegatingController.Sample.Handlers.Home
{
    public class AboutPageHandler : IModelCommand<AboutPageInputModel>, IModelBuilder<string, AboutPageViewModel>
    {
        public void Execute(AboutPageInputModel command)
        {
            //Send an email
            //Save to the database
        }

        public AboutPageViewModel Build(string input)
        {
            return new AboutPageViewModel()
            {
                TermsForDisplay = input
            };
        }
    }
}