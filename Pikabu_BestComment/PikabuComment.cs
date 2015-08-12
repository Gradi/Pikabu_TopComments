using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pikabu_BestComment
{
    public sealed class PikabuComment
    {
        public string PostLink { get; set; }
        public string PostName { get; set; }
        public int CommentLikes { get; set; }
        public string CommentAuthor { get; set; }
        public string CommentText { get; set; }

        public override bool Equals(object obj)
        {
            PikabuComment anotherComment = obj as PikabuComment;
            return this.PostName.Equals(anotherComment.PostName) && this.CommentText.Equals(anotherComment.CommentText);
        }
    }
}
