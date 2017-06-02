using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;
using KillerAppSharingPlatform.Classes;

namespace KillerAppSharingPlatform.Dal.Data
{
    interface IProfileContext
    {

        bool AddFriend(string username, int userId);
        void AcceptFriend(string username, int userId);
        void AddBlock(string username, int userId);
        void AddFollow(string username, int userId);
        void SendMessage(Message message);
        void getUserId(string query, string username);
        List<string> LUserList();
        List<string> LFriendList(int IdGebruiker, string Gebruikersnaam);
        List<string> LFriendPendingList(int IdGebruiker);
        List<string> LBlockList(int IdGebruiker);
        List<string> LFollowList(int IdGebruiker);
        List<Message> LmessageList(int IdOntvanger);

    }
}
