using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bootcamp1.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Ranking { get; set; }
        public string BirthDateString => BirthDate.ToLongDateString();

    }
    public class UserModelBuilder : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> entity)
        {
           entity.HasKey(e => e.UserID);
        }
    }
}
