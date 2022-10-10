using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForum.Common
{
    public class ForumConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string DefaultExchangeType = "direct";

        public const string UserExchangeName = "UserExchange";
        public const string UserEmailChangedQueueName = "UserEmailChangeQueue";


        //Create Fav
        public const string FavExchangeName = "FavExchangeName";
        public const string CreateEntryCommentFavQueueName = "CreateEntryCommentFavQueue";

        //Create Vote
        public const string VoteExchangeName = "VoteExchangeName";
        public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";

        //Delete Fav
        public const string DeleteEntryFavQueueName = "DeleteEntryFavQueue";

        //Delete Fav from Entry Comment
        public const string DeleteEntryCommentFavQueueName = "DeleteEntryCommentFavQueue"; 
        
        //Delete Vote from Entry Comment
        public const string DeleteEntryCommentVoteQueueName = "DeleteEntryCommentVoteQueue";

        //Delete Vote
        public const string DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";

        //Create Vote to Comment
        public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";


    }
}
