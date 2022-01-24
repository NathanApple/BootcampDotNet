
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp1.Entities
{
    public class UserEntity
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Ranking { get; set; }
        public string BirthDateString => BirthDate.ToLongDateString();

    }

    public class UserEntityModelBuilder : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> entity)
        {
            entity.HasKey(e => e.UserID);
        }
    }

    //template model builder
    //public class [EntityName]ModelBuilder : IEntityTypeConfiguration<[EntityName]>
    //{
    //    public void Configure(EntityTypeBuilder<[EntityName]> entity)
    //    {
    //        entity.HasKey(e => e.[PropertyName}]);
    //    }
    //}



}
