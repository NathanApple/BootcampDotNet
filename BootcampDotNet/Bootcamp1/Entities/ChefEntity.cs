
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bootcamp1.Entities
{
    public class ChefEntity
    {
        public int ChefID { get; set; }
        public string ChefName { get; set; }
        public List<FoodEntity> Foods { get; set; }

    }

    public class ChefEntityModelBuilder : IEntityTypeConfiguration<ChefEntity>
    {
        public void Configure(EntityTypeBuilder<ChefEntity> entity)
        {
            entity.HasKey(e => e.ChefID);
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
