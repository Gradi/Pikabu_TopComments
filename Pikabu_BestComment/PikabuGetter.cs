using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Pikabu_BestComment
{
    public sealed class PikabuGetter
    {
        private const string SITE_URL = "http://pikabu.ru";
        public Status status { get; set; }
        public Exception lastException { get; set; }
        public List<PikabuComment> comments { get; set; }
        private Settings settings;

        public PikabuGetter(Settings settings)
        {
            this.comments = new List<PikabuComment>();
            this.settings = settings;
        }

        private PikabuComment getCurrentTopComment()
        {
            try
            {
                string result = Utils.getWebPage(SITE_URL);
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(result);
                HtmlNode table = document.DocumentNode.SelectNodes("//table[@class='best_comm']")[0];
                HtmlNode storyLinkDiv = table.SelectNodes("//div[@class='menu-story-link']")[0];
                HtmlNode commentInfoDiv = table.SelectNodes("//div[@class='info info_c menu-comm-head']")[0];
                HtmlNode commentMsgDiv = table.SelectNodes("//div[@class='comment_msg comment_desc menu-comm-desc']")[0];
                PikabuComment comment = new PikabuComment();
                comment.PostName = Utils.cleanString(storyLinkDiv.InnerText);
                comment.PostLink = storyLinkDiv.SelectNodes("./a")[0].Attributes["href"].Value;
                comment.CommentLikes = Int32.Parse(Utils.cleanString(commentInfoDiv.SelectNodes("./h6")[0].InnerText.Replace("+", "")));
                comment.CommentAuthor = Utils.cleanString(commentInfoDiv.SelectNodes("./a")[0].InnerText);
                comment.CommentText = Utils.cleanString(commentMsgDiv.InnerText);
                status = Status.OK;
                return comment;
            }
            catch(Exception exc)
            {
                status = Status.Error;
                lastException = exc;
            }
            return null;
        }

        /// <summary>
        /// Will return comment if there is new top comment.
        /// Otherwise it returns null
        /// </summary>
        /// <returns></returns>
        public PikabuComment updateComments()
        {
            PikabuComment latestCom = this.getCurrentTopComment();
            PikabuComment resultComment = null;
            if (latestCom == null)
                return null;
            int comCount = comments.Count;
            if (comCount != 0)
            {
                if (comments[comCount - 1].Equals(latestCom))
                    comments[comCount - 1].CommentLikes = latestCom.CommentLikes;
                else
                {
                    int diff = comCount - settings.CommentsCount;
                    if (diff > 0)
                    {
                        for (int i = 0; i < diff; i++)
                        {
                            comments.RemoveAt(comCount - 1 - i);
                        }
                    }
                    comments.Add(latestCom);
                    resultComment = latestCom;
                }
            }
            else
            {
                comments.Add(latestCom);
                resultComment = latestCom;
            }
            return resultComment;
        }

        public PikabuComment getLastComment()
        {
            if (comments.Count != 0)
                return comments[comments.Count - 1];
            else
                return null;
        }

        public void saveComments()
        {
            if (!Directory.Exists(Settings.SaveDirPath))
            {
                Directory.CreateDirectory(Settings.SaveDirPath);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<PikabuComment>));
            using(XmlTextWriter writer = new XmlTextWriter(Settings.CommentsSavePath, Encoding.Unicode))
            {
                writer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, comments);
            }
        }

        public void tryLoadComments()
        {
            try
            {
                if (!Directory.Exists(Settings.SaveDirPath) || !File.Exists(Settings.CommentsSavePath))
                    return;
                XmlSerializer serializer = new XmlSerializer(typeof(List<PikabuComment>));
                using(XmlReader reader = new XmlTextReader(Settings.CommentsSavePath))
                {
                    comments = serializer.Deserialize(reader) as List<PikabuComment>;
                }
            }
            catch (Exception exc)
            {
                comments = new List<PikabuComment>();
            }           
        }
    }

    public enum Status
    {
        Error, OK
    }
}
