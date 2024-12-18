using UwaziTech.Core.Models.request;
using System.Diagnostics.CodeAnalysis;

namespace UwaziTech.API.Model.Request
{
    public class UserRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string Reference {  get; set; }
        public string? BranchName { get; set; }

        public static implicit operator UserDetails([NotNull] UserRequest request)
        {
            return new UserDetails
            {
                Password = request.Password,
                Username = request.Username,
                Reference = request.Reference,
                BranchName = request.BranchName,
            };
        }
    }
}
