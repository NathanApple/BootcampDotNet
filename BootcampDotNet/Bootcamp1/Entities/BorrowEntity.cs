
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp1.Entities
{
    public class BorrowEntity
    {
        public int BorrowID { get; set; }
        public int BookID { get; set; }
        public BookEntity Book { get; set; }

        public int UserID { get; set; }
        public UserEntity User { get; set; }

    }

    public class BorrowEntityModelBuilder : IEntityTypeConfiguration<BorrowEntity>
    {
        public void Configure(EntityTypeBuilder<BorrowEntity> entity)
        {
            entity.HasKey(e => e.BorrowID);
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
