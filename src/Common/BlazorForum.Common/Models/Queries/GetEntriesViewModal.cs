using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Common.Models.Queries
{
    public class GetEntriesViewModal
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public int CommentCount { get; set; }
    }
}
