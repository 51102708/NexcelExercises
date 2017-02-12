namespace BusinessEnglish.Sites.Controllers
{
    using Models;
    using Services;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private TopicService topicService;
        private SectionService sectionService;
        private PhraseService phraseService;

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

            var searchResult = new SearchResultModel
            {
                SearchString = searchString,
                SearchType = searchType
            };

            var topics = topicService.GetAll();
            string[] modelTypes = { "sections", "phrases", "examples" };

            if (searchType == null)
            {
                searchType = string.Empty;
            }

            if (!modelTypes.Any(searchType.Equals))
            {
                searchType = "sections";
            }

            searchType = searchType.ToLower();

            if (searchType.Equals("sections"))
            {
                var sections = sectionService.GetAll();
                sections = sectionService.FilterSectionsWithName(sections, searchString);

                searchResult.ResultLength = sections.Count();
                searchResult.SearchType = searchType;
                searchResult.ResultDatas = new List<ResultData>();
                foreach (var item in sections)
                {
                    searchResult.ResultDatas.Add(new ResultData
                    {
                        ResultTitle = "TOPIC: " + item.Topic.Name,
                        ResultContent = "Section - " + item.Name,
                        TopicId = item.TopicId,
                        SectionId = item.Id
                    });
                }
            }

            if (searchType.Equals("phrases") || searchType.Equals("examples"))
            {
                var phrases = phraseService.GetAll();
                phrases = phraseService.FilterPhrasesWithName(phrases, searchString);

                searchResult.ResultLength = phrases.Count();
                searchResult.SearchType = searchType;
                searchResult.ResultDatas = new List<ResultData>();
                foreach (var item in phrases)
                {
                    var topic = topics.Where(s => s.Id == item.Section.TopicId).First();
                    searchResult.ResultDatas.Add(new ResultData
                    {
                        ResultTitle = topic.Name + " / " + item.Section.Name + (searchType.Equals("phrases") ? string.Empty : (" / " + item.Name)),
                        ResultContent = searchType.Equals("phrases") ? ("Phrase - " + item.Name) : ("Example - " + item.Example),
                        TopicId = topic.Id,
                        SectionId = item.Section.Id
                    });
                }
            }

            return View(new HomeViewModel
            {
                Topics = topics,
                CurrentSearch = searchResult
            });
        }
    }
}