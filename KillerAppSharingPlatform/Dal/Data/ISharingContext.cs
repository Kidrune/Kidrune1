using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerAppSharingPlatform.Classes;

namespace KillerAppSharingPlatform.Dal.Data
{
    interface ISharingContext
    {
        List<Topic> GetListTopics();
        void CreateTopic(Topic topic);

        List<Post> GetListPosts(int id);
        void CreatePost(Post post);

        List<Reaction> GetListReactions(int id);
        void CreateReaction(Reaction reaction);

    }
}
