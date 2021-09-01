using FluentMigrator;

namespace WebAPI.Migrations
{
    [Migration(20200830164500)]
    public class Migration_20200830164500 : Migration
    {
        public override void Down()
        {
            Delete.Table("category");
        }

        public override void Up()
        {
            Create.Table("category")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("parentid").AsInt32().Nullable();

            Create.ForeignKey() 
                .FromTable("category").ForeignColumn("parentid")
                .ToTable("category").PrimaryColumn("id");
        }
    }
}
