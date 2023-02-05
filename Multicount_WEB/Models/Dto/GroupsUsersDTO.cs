using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Multicount_WEB.Models.Dto
{
    public class GroupsUsersDTO
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }
        public float Amount { get; set; }
    }
}