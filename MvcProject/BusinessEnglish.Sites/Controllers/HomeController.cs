namespace BusinessEnglish.Sites.Controllers
{
    using System.Linq;
    using System.Data;
    using System.Web.Mvc;
    using Services;
    using Models;
    using BusinessEnglish.Models;
    using System.Collections.Generic;

    public class HomeController : Controller
    {
        private TopicService topicService;
        private SectionService sectionService;
        private PharseService pharseService;

        public HomeController()
        {
            topicService = new TopicService();
            sectionService = new SectionService();
            pharseService = new PharseService();
        }

        public ActionResult Index()
        {
            return View(new HomeViewModel
            {
                Topics = (IEnumerable<Topic>)topicService.GetAll()
            });
        }

        public ActionResult Contents(int? sectionId, int? topicId)
        {
            if ((sectionId == null) || (topicId == null))
            {
                return RedirectToAction("Index");
            }

            var topics = (IEnumerable<Topic>)topicService.GetAll();
            var sections = (IEnumerable<Section>)sectionService.GetAll();
            var pharses = (IEnumerable<Pharse>)pharseService.GetAll();
            sections = (IEnumerable<Section>)sectionService.FilterSectionsByTopicId(sections, (int)topicId);
            sections = (IEnumerable<Section>)sectionService.FilterSectionsById(sections, (int)sectionId);

            var currentSection = sections.First();
            currentSection.Pharses = (IEnumerable<Pharse>)pharseService.FilterPharsesBySectionId(pharses, (int)sectionId);

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

            var topics = (IEnumerable<Topic>)topicService.GetAll();
            string[] modelTypes = { "sections", "pharses", "examples" };
            if (searchType == null) { searchType = ""; }
            if (!modelTypes.Any(searchType.Equals))
            {
                searchType = "sections";
            }
            searchType = searchType.ToLower();

            if (searchType.Equals("sections"))
            {
                var sections = (IEnumerable<Section>)sectionService.GetAll();
                sections = (IEnumerable<Section>)sectionService.FilterSectionsWithName(sections, searchString);

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

            if (searchType.Equals("pharses") || searchType.Equals("examples"))
            {
                var pharses = (IEnumerable<Pharse>)pharseService.GetAll();
                pharses = (IEnumerable<Pharse>)pharseService.FilterPharsesWithName(pharses, searchString);

                searchResult.ResultLength = pharses.Count();
                searchResult.SearchType = searchType;
                searchResult.ResultDatas = new List<ResultData>();
                foreach (var item in pharses)
                {
                    var topic = topics.Where(s => s.Id == item.Section.TopicId).First();
                    searchResult.ResultDatas.Add(new ResultData
                    {
                        ResultTitle = topic.Name + " / " + item.Section.Name + (searchType.Equals("pharses") ? "" : (" / " + item.Name)),
                        ResultContent = (searchType.Equals("pharses") ? ("Pharse - " + item.Name) : ("Example - " + item.Example)),
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