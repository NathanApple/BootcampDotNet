
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp1.Entities
{
    public class BookEntity
    {
        public int BookID { get; set; }
        public string BookTitle { get; set; } 
        public string BookDescription { get; set; } 
        public int Quantity { get; set; }


    }

    public class BookEntityModelBuilder : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> entity)
        {
            entity.HasKey(e => e.BookID);
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
