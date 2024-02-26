using TestProject.Data;
using Umbraco.Cms.Core.Services;

namespace TestProject.Services
{
    public class FussballContentService : IFussballContentService
    {
        private readonly IContentService _contentService;

        public FussballContentService(IContentService contentService)
        {
            _contentService = contentService;
        }

        public void CreateContent<T>(string nodeName, int parentId, string contentType, T contentData = default)
        {
            switch (contentType)
            {
                case "match":
                    if (contentData is Match matchData)
                    {
                        AddMatchProperties(matchData);
                    }

                    break;
            }

            //var content = _contentService.Create(nodeName, parentId, contentType);

            //_contentService.SaveAndPublish(content);
        }

        private void AddMatchProperties(Match matchData)
        {
            var match = _contentService.Create("Match", matchData.Team1Id, "match");

            var team1 = _contentService.GetById(matchData.Team1Id);
            var team2 = _contentService.GetById(matchData.Team2Id);

            match.SetValue("team1", team1);
            match.SetValue("team2", team2);

            match.SetValue("team1Score", matchData.Team1Score);
            match.SetValue("team2Score", matchData.Team2Score);

            match.SetValue("date", matchData.MatchDate);

            ////_contentService.SaveAndPublish(match);
        }

        public void CreateContent()
        {
            throw new NotImplementedException();
        }
    }
}