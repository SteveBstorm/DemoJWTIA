using Demo_ASP_MVC_06_Session.Domain.Entities;
using DemoJWTIA.Models;

namespace DemoJWTIA.Mappers
{
    public static class Mappers
    {
        public static Member ToBLL(this AuthRegisterViewModel f)
        {
            return new Member
            {
                Email = f.Email,
                Password = f.Password,
                Pseudo = f.Pseudo
            };
        }

        public static ConnectedUserDTO ToDTO(this Member member)
        {
            return new ConnectedUserDTO
            {
                Email = member.Email,
                Pseudo = member.Pseudo,
                MemberId = member.MemberId
            };
        }
    }
}
