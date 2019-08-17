using System.Collections;
using System.Collections.Generic;
using Common.MDSService;

namespace Common.Model
{

    // This is the class to store the security information
    public class SecurityInformation
    {
        public SecurityInformation()
        {
            
        }
        public SecurityInformation(IEnumerable<User> users)
        {
            Users = (List<User>) users;
        }

        public SecurityInformation(IEnumerable<User> users, IEnumerable<Group> groups)
        {
            Users = (List<User>)users;
            Groups = (List<Group>)groups;
        }

        public List<User> Users { get; set; }

        public List<Group> Groups { get; set; }
    }
}
