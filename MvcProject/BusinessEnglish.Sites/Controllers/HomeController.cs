namespace BusinessEnglish.Sites.Controllers
{
    using Models;
    using Resources;
    using Services;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly TopicService topicService;
        private readonly SectionService sectionService;
        private readonly PhraseService phraseService;

        public HomeController()
        {
            topicService = new TopicService();
            sectionService = new SectionService();
            phraseService = new PhraseService();
        }

        public ActionResult Index()
        {
            return View(new HomeViewModel
            {
                Topics = topicService.GetAll()
            });
        }

        public ActionResult Contents(int? sectionId, int? topicId)
        {
            if ((sectionId == null) || (topicId == null))
            {
                return RedirectToAction("Index");
            }

            var topics = topicService.GetAll();
            var sections = sectionService.GetAll();
            var phrases = phraseService.GetAll();

            sections = sectionService.FilterSectionsByTopicId(sections, (int)topicId);
            sections = sectionService.FilterSectionsById(sections, (int)sectionId);

            var currentSection = sections.First();
            currentSection.Phrases = phraseService.FilterPhrasesBySectionId(phrases, (int)sectionId);

            return View(new HomeViewModel
            {
                Topics = topics,
                CurrentSection = currentSection,
                CurrentTopicId = (int)topicId,
                CurrentSectionId = (int)sectionId
            });
        }

        public ActionResult Search(string searchString, string searchType)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("Index", "Home");
            }

            var topics = topicService.GetAll();
            var searchResult = new SearchResult();

            if (searchType == null)
            {
                searchResult = SearchBySection(searchString);
            }
            else
            {
                if (searchType.Equals("section"))
                {
                    searchResult = SearchBySection(searchString);
                }

                if (searchType.Equals("phrase"))
                {
                    searchResult = SearchByPhrase(searchString);
                }

                if (searchType.Equals("example"))
                {
                    searchResult = SearchByExample(searchString);
                }
            }

            return View(new HomeViewModel
            {
                Topics = topics,
                CurrentSearch = searchResult
            });
        }

        [NonAction]
        public SearchResult SearchBySection(string searchString)
        {
            var searchResult = new SearchResult
            {
                SearchString = searchString,
                SearchType = "section"
            };

            var sections = sectionService.GetAll();
            sections = sectionService.FilterSectionsWithName(sections, searchString);

            searchResult.ResultLength = sections.Count();
            searchResult.ResultData = new List<SearchResultData>();

            foreach (var item in sections)
            {
                searchResult.ResultData.Add(new SearchResultData
                {
                    ResultTitle = StringResources.Topic.ToUpper() + ": " + item.Topic.Name,
                    ResultContent = StringResources.Section + " - " + item.Name,
                    TopicId = item.TopicId,
                    SectionId = item.Id
                });
            }

            return searchResult;
        }

        [NonAction]
        public SearchResult SearchByPhrase(string searchString)
        {
            var searchResult = new SearchResult
            {
                SearchString = searchString,
                SearchType = "phrase"
            };

            var phrases = phraseService.GetAll();
            phrases = phraseService.FilterPhrasesWithName(phrases, searchString);

            searchResult.ResultLength = phrases.Count();
            searchResult.ResultData = new List<SearchResultData>();

            foreach (var item in phrases)
            {
                var topic = topicService.Get(item.Section.TopicId);
                searchResult.ResultData.Add(new SearchResultData
                {
                    ResultTitle = topic.Name + " / " + item.Section.Name,
                    ResultContent = StringResources.Phrase + " - " + item.Name,
                    TopicId = topic.Id,
                    SectionId = item.Section.Id
                });
            }

            return searchResult;
        }

        [NonAction]
        public SearchResult SearchByExample(string searchString)
        {
            var searchResult = new SearchResult
            {
                SearchString = searchString,
                SearchType = "example"
            };

            var phrases = phraseService.GetAll();
            phrases = phraseService.FilterPhrasesWithName(phrases, searchString);

            searchResult.ResultLength = phrases.Count();
            searchResult.ResultData = new List<SearchResultData>();

            foreach (var item in phrases)
            {
                var topic = topicService.Get(item.Section.TopicId);
                searchResult.ResultData.Add(new SearchResultData
                {
                    ResultTitle = topic.Name + " / " + item.Section.Name + " / " + item.Name,
                    ResultContent = StringResources.Example + " - " + item.Example,
                    TopicId = topic.Id,
                    SectionId = item.Section.Id
                });
            }

            return searchResult;
        }
    }
}